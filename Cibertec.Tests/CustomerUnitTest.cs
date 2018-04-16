using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Tests
{
    [TestClass]
    public class CustomerUnitTest
    {
        private readonly IUnitOfWork _unit;
        public CustomerUnitTest()
        {
            _unit = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        [TestMethod]
        public void GetAllTest()
        {
            var result = _unit.Customers.GetList();
            Assert.AreEqual(93, result.Count());
        }

        [TestMethod]
        public void Get()
        {
            var result = _unit.Customers.GetByStringId("ALFKI");
            Assert.AreEqual("Alfreds Futterkiste", result.CompanyName);
        }
    }
}
