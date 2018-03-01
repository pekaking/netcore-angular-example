using NetCoreAngularTemplate.Data.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCoreAngularTemplate.Data.Models
{
    public partial class TestTable : BaseEntity
    {
        public int id { get; set; }
        public string Test { get; set; }
    }
}
