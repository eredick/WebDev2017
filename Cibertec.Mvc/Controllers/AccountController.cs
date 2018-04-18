using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cibertec.Models.ViewModels;
using Cibertec.UnitOfWork;
using log4net;

namespace Cibertec.Mvc.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ILog log, IUnitOfWork unit) : base(log, unit)
        {
        }
        
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            var user = _unit.Users.ValidateUser(model.Email, model.Password);
            if (user != null)
                return RedirectToAction("Index", "Customer");
            else
            {
                ModelState.AddModelError(string.Empty, "Correo y/o contraseña inválidos");
                return View(model);
            }
        }
    }
}