using NetCoreAngularTemplate.Data.Maps;
using NetCoreAngularTemplate.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace NetCoreAngularTemplate.Data
{
    public partial class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new TestTableMap(modelBuilder.Entity<TestTable>());
        }
    }
}
