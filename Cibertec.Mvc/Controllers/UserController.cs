using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cibertec.Models;
using Cibertec.Models.ViewModels;
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
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(UserVM model)
        {
            //if (ModelState.IsValid)
            //{
            //    _unit.Users.Insert(user);
            //    return RedirectToAction("Index");
            //}
            //return View(user);
            var newUser = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Roles = model.Roles
            };
            _unit.Users.Insert(newUser);
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
            return Json(new { option = "create" });
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var user = _unit.Users.GetById(id);
            var userVM = new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Roles = user.Roles
            };
            return PartialView("_Edit", userVM);
        }

        [HttpPost]
        public ActionResult Edit(UserVM model)
        {
            var updateUser = new User
            {
                Id = model.Id,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Password = model.Password,
                Roles = model.Roles
            };
            _unit.Users.Update(updateUser);
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
            return Json(new { option = "edit" });
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var user = _unit.Users.GetById(id);
            var userVM = new UserVM
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Roles = user.Roles
            };
            return PartialView("_Delete", userVM);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteUser = new User{ Id = id };
            _unit.Users.Delete(deleteUser);
            //return new HttpStatusCodeResult(HttpStatusCode.OK);
            return Json(new { option = "delete" });
        }
    }
}