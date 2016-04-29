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
                ConfirmPassword = user.Password,
                Tel = user.Tel
            };
            return View(uvm);
        }
        [HttpPost]
        public ActionResult UserEdit(UserVM uvm)
        {
            if (ModelState.IsValid)
            {
                var user = castVMtoUser(uvm);
                um.Update(user);
            }
            return RedirectToAction("User");
        }


        public ActionResult UserDelete(int id)
        {
            var user = um.GetbyId(id);
            var model = castUsertoVM(user);
            return View(model);
        }
        [HttpPost]
        public ActionResult UserDelete(UserVM uvm)
        {
            um.Delete(uvm.Id);
            var model = um.GetAll();
            return RedirectToAction("User");
            //return View("User",model);
        }


        private User castVMtoUser(UserVM uvm)
        {
            return new User
            {
                Id = uvm.Id,
                Email = uvm.Email,
                Password = uvm.Login,
                Tel = uvm.Tel,
                Login = uvm.Login
            };
        }

        private UserVM castUsertoVM(User uvm)
        {
            return new UserVM
            {
                Id = uvm.Id,
                Email = uvm.Email,
                Password = uvm.Password,
                ConfirmPassword = uvm.Password,
                Tel = uvm.Tel,
                Login = uvm.Login
            };
        }
        #endregion

        #region UserRole

        public ActionResult UserRole()
        {
            var model = new UserRoleVM();
            var users = um.GetAll();
            var roles = rm.GetAllRoles();
            model.Users = (from p in users
                           select new SelectListItem() { 
                               Text = p.Login, 
                               Value = p.Id.ToString()
                           });
            model.Roles = (from p in roles
                           select new SelectListItem
                           {
                               Text = p.Name,
                               Value = p.Id.ToString()
                           });
            return View(model);
        }
        [HttpPost]
        public ActionResult UserRole(UserRoleVM obj)
        {
            foreach(int userID in obj.SelectedUsers)
            {
                var user = um.GetbyId(userID);
                foreach(int roleId in obj.SelectedRoles)
                {
                    var role = rm.GetRolebyId(roleId);
                    user.Roles.Add(role);
                }
            }

            return RedirectToAction("UserRole");
        }

        #endregion
    }
}