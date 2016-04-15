using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Authentication.Front.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            ViewBag.Country = claimsIdentity.FindFirst(ClaimTypes.Country).Value;
            var roles = claimsIdentity.FindAll(ClaimTypes.Role);
            var str = "";
            foreach ( var c in roles)
            {
                str += "," + c.Value;
                ViewBag.Roles = str.Substring(1);
            }
            return View();
        }
	}
}