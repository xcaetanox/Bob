using Bobson.Core.DAO;
using Bobson.UI.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bobson.UI.Web.Controllers
{
    public class SharedController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? new ApplicationRoleManager(new MySql.AspNet.Identity.MySqlRoleStore<MySql.AspNet.Identity.IdentityRole>());
            }
            private set
            {
                _roleManager = value;
            }
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {

            return View("~/Views/Shared/_MenuPartial.cshtml", GetRoles());
        }


        [ChildActionOnly]
        public ActionResult Login()
        {

            return View("~/Views/Shared/_LoginPartial.cshtml", isManager());
        }

        public IList<String> GetRoles()
        {
            if (User.Identity.IsAuthenticated)
            {
                return UserManager.GetRoles(User.Identity.GetUserId());
            }
            return new List<String>();

        }
        public Boolean HasRole(string role)
        {
            if (User.Identity.IsAuthenticated)
            {
                var roles = UserManager.GetRoles(User.Identity.GetUserId());
                return roles.Contains(role);
            }
            return false;
        }

        public Boolean isManager()
        {
            return HasRole("Gerente");
        }

    }
}