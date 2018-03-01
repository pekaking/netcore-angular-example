using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NetCoreAngularTemplate.BussinesLogic;
using NetCoreAngularTemplate.BussinesLogic.Services;
using NetCoreAngularTemplate.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace NetCoreAngularTemplate.Web
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
      {
        options.AddPolicy("AllowAll",
            builder =>
            {
              builder
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials();
            });
      });

      services.AddMvc();

      services.AddScoped(typeof(GenericRepository<>), typeof(GenericRepository<>));

      services.AddScoped<TestService, TestService>();

      services.AddDbContext<TestContext>(options => options.UseSqlServer(Configuration.GetConnectionString("TestDb")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseCors("AllowAll");

      app.Use(async (context, next) =>
      {
        await next();
        if (context.Response.StatusCode == 404 &&
                 !Path.HasExtension(context.Request.Path.Value) &&
                 !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });
      app.UseMvcWithDefaultRoute();
      app.UseDefaultFiles();
      app.UseStaticFiles();
    }
  }
}
