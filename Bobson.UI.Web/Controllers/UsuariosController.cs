using Bobson.Core.Base;
using Bobson.Core.DAO;
using Bobson.Core.DTO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bobson.UI.Web.Controllers
{
    public class UsuariosController : Controller
    {
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;

        // GET: Usuarios
        public ActionResult Index()
        {
            UsuariosViewModel model = new UsuariosViewModel();
            model.Usuarios = new UsuariosDAO().ListarUsuarios();

            return View("Index", model);
        }

        public ActionResult AtivarDesativar(string id,string status)
        {
            UsuariosViewModel model = new UsuariosViewModel();

            if (status != "X") {
                model.Usuarios = new UsuariosDAO().InativarAtivar(id);
            }
            else
            {
                model.Usuarios = new UsuariosDAO().Ativar(id);
            }

            return View("Index", model);
        }




        public ActionResult configemail(string id)
        {

            ConfigEmailViewModel model = new ConfigEmailViewModel();


            Session["UserId"] = id; 

            model.Roles = new ApplicationRoleManager(new MySql.AspNet.Identity.MySqlRoleStore<MySql.AspNet.Identity.IdentityRole>()).Roles.Select(r => new SelectListItem { Value = r.Name, Text = r.Name }).ToList();
            model.UserId = id;


                         
            return View("configemail", model);
        }


        public ActionResult SalvaConfig(ConfigEmailViewModel model)
        {
            ConfigEmailUsuarioDAO dao = new ConfigEmailUsuarioDAO();
            model.UserId = Session["UserId"].ToString();
            UserManager.RemoveFromRolesAsync(model.UserId, UserManager.GetRoles(model.UserId).ToArray());
            this.UserManager.AddToRoleAsync(model.UserId, model.Role);

            UsuariosViewModel modelIndex = new UsuariosViewModel();
            modelIndex.Usuarios = new UsuariosDAO().ListarUsuarios();


            return View("Index", modelIndex);
        }

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
          public ActionResult ResetPassword(string id)
        {
            UsuariosViewModel model = new UsuariosViewModel();

            model.Usuarios = new UsuariosDAO().resetSenha(id);


            return View("Index", model);
        }



    }
}