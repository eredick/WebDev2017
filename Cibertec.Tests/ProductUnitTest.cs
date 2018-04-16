using System;
using System.Configuration;
using System.Linq;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cibertec.Tests
{
    [TestClass]
    public class ProductUnitTest
    {
        private readonly IUnitOfWork _unit;
        public ProductUnitTest()
        {
            _unit = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }
        [TestMethod]
        public void GetProductsTest()
        {
            var result = _unit.Products.GetList();
            Assert.AreEqual(77, result.Count());
        }
    }
}
