using NetCoreAngularTemplate.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAngularTemplate.Data.Maps
{
    public class TestTableMap
    {
        public TestTableMap(EntityTypeBuilder<TestTable> entityBuilder)
        {
            entityBuilder.ToTable("TestTable");
            entityBuilder.HasKey(t => t.id);
            entityBuilder.Property(t => t.Test);
        }
    }
}

    //public class TestTableMap : EntityTypeConfiguration<TestTable>
    //{
    //    public TestTableMap()
    //    {
    //        // Primary Key
    //        //this.HasKey(t => t.ID);

    //        // Properties
    //        //this.Property(t => t.ID)
    //        //   .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
    //        // Table & Column Mappings
    //        this.ToTable("City");
    //        this.Property(t => t.ID).HasColumnName("ID");
            
    //    }
    //}
