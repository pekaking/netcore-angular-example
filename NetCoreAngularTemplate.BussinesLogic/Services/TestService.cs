using NetCoreAngularTemplate.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetCoreAngularTemplate.BussinesLogic.Services
{
    public class TestService
    {
        private GenericRepository<TestTable> _testTables;

        public TestService(GenericRepository<TestTable> testTables)
        {
            _testTables = testTables;
        }

        public List<TestTable> testDB()
        {
            return _testTables.GetAll().ToList();
        }
    }
}
