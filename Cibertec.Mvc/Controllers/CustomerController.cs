using Cibertec.Models;
using Cibertec.Models.ViewModels;
using Cibertec.Mvc.ActionFilters;
using Cibertec.Repositories.Dapper.Northwind;
using Cibertec.UnitOfWork;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cibertec.Mvc.Controllers
{
    [ErrorActionFilter]
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork unit, ILog log) : base(log,unit)
        {}

        public ActionResult Detail(string id)
        {
            var viewModel = new CustomerDetailVM();
            viewModel.Customer = _unit.Customers.GetByStringId(id);
            viewModel.Orders = _unit.Orders.GetOrderByCustomer(id);
            return View(viewModel);
        }

        // GET: Customer
        public ActionResult Index()
        {
            _log.Info("error de customer");
            return View(_unit.Customers.GetList());
        }

        public ActionResult Error()
        {
            throw new Exception("Este es un error de PRUEBA");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.InsertCustomer(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        public ActionResult Edit(string id)
        {
            var customer = _unit.Customers.GetByStringId(id);
            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _unit.Customers.Update(customer);
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        [ActionName("Delete")]
        public ActionResult Delete(string id)
        {
            var customer = _unit.Customers.GetByStringId(id);
            return View("Delete", customer);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            var customer = _unit.Customers.GetByStringId(id);
            var elimino = _unit.Customers.Delete(customer);
            if (elimino) return RedirectToAction("Index");
            return View(customer);
        }
    }
}