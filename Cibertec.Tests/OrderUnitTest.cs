using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cibertec.UnitOfWork;
using Cibertec.Repositories.Dapper.Northwind;
using System.Configuration;

namespace Cibertec.Tests
{
    /// <summary>
    /// Descripción resumida de OrderUnitTest
    /// </summary>
    [TestClass]
    public class OrderUnitTest
    {
        private readonly IUnitOfWork _unit;
        public OrderUnitTest()
        {
            _unit = new NorthwindUnitOfWork(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ToString());
        }

        [TestMethod]
        public void GetOrderByCustomer()
        {
            var result = _unit.Orders.GetOrderByCustomer("BOTTM");
            Assert.AreEqual(14, result.Count);
        }
    }
}
