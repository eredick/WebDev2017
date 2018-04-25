using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.Models;
using Cibertec.Mvc.ActionFilters;
using Cibertec.UnitOfWork;
using log4net;

namespace Cibertec.Mvc.Controllers
{
    public class UserController : BaseController
    {
        public UserController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
        }

        // GET: User
        public ActionResult Index()
        {
            return View(_unit.Users.GetList());
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _unit.Users.Insert(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

    }
}