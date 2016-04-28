using Authentication.Model;
using Authentication.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication.Front.ViewModel;

namespace Authentication.Front.Controllers
{
    public class AdminController : Controller
    {
        #region Role

        RoleManager rm = new RoleManager();
        //
        // GET: /Admin/

        public ActionResult Role()
        {
            var roles = rm.GetAllRoles();
            return View(roles);
        }

        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole([Bind(Exclude="Id")]Role role)
        {
            rm.AddRole(role);
            var model = rm.GetAllRoles();
            return View("Role",model);
        }

        
        public ActionResult DeleteRole(int id)
        {
            var model = rm.GetRolebyId(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteRole(Role role)
        {
            rm.DeleteRole(role.Id);
            var model = rm.GetAllRoles();
            return View("Role", model);
        }

        //[ValidateAntiForgeryToken]
        public ActionResult EditRole(int id)
        {
            var model = rm.GetRolebyId(id);
            return View(model);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditRole(Role role)
        {
            rm.UpdateRole(role);
            var model = rm.GetAllRoles();
            return View("Role", model);
        }
        #endregion	
    
        #region User
        UserManager um = new UserManager();

        public ActionResult User()
        {
            var model = um.GetAll();
            return View(model);
        }

        public ActionResult UserDelete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserDelete(int id)
        {
            return View();
        }

        public ActionResult UserCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserCreate(UserVM user)
        {
            if (ModelState.IsValid)
            {
                var us = new Model.User
                {
                    Email = user.Email,
                    Login = user.Login,
                    Password = user.Password,
                    Tel = user.Tel
                };
                um.Add(us);
            }
            //var model = um.get
            return RedirectToAction("UserCreate");
        }

        public ActionResult UserEdit(int Id)
        {
            var user = um.GetbyId(Id);
            var uvm = new UserVM()
            {
                Id = user.Id,
                Login = user.Login,
                Email = user.Email,
                Password = user.Password,
                ConfirmPassword = user.Password
            };
            return View(uvm);
        }

        [HttpPost]
        public ActionResult UserEdit(UserVM uvm)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
        #endregion

    }
}