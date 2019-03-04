using Bobson.Core.Base;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using MySql.AspNet.Identity;
using Owin;
using System.Web;

[assembly: OwinStartupAttribute(typeof(Bobson.UI.Web.Startup))]
namespace Bobson.UI.Web
{
    public partial class Startup
    {
        
       


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultRolesAndUsers();
        }

        private void CreateDefaultRolesAndUsers()
        {
            var roleManager = new ApplicationRoleManager(new MySqlRoleStore<IdentityRole>());
            var UserManager = new ApplicationUserManager(new MySqlUserStore<Models.ApplicationUser>());


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists(Config.Roles.Administrador))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = Config.Roles.Administrador;
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new Models.ApplicationUser();
                user.Email = "amf.paulo@gmail.com";
                user.UserName = user.Email;
                user.EmailConfirmed = true;

                var chkUser = UserManager.Create(user, "Amesm@01");

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, Config.Roles.Administrador);
                }
            }

            if (!roleManager.RoleExists(Config.Roles.Gerente))
            {

                // first we create Admin rool   
                var role = new IdentityRole();
                role.Name = Config.Roles.Gerente;
                roleManager.Create(role);
                
                //Here we create a Admin super user who will maintain the website                  

                var user = new Models.ApplicationUser();
                
                user.Email = "aros.bobson@gmail.com";
                user.UserName = user.Email;
                user.EmailConfirmed = true;

                var chkUser = UserManager.Create(user, "Alex2016");

                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, Config.Roles.Gerente);
                }
            }

            if (!roleManager.RoleExists(Config.Roles.Escritorio.Replace(",Admin", "")))
            {
                var role = new IdentityRole();
                role.Name = Config.Roles.Escritorio;
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists(Config.Roles.Comercial.Replace(",Admin", "")))
            {
                var role = new IdentityRole();
                role.Name = Config.Roles.Comercial;
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists(Config.Roles.Tecnico.Replace(",Admin", "")))
            {
                var role = new IdentityRole();
                role.Name = Config.Roles.Tecnico;
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists(Config.Roles.Cliente.Replace(",Admin", "")))
            {
                var role = new IdentityRole();
                role.Name = Config.Roles.Cliente;
                roleManager.Create(role);

            }


        }
    }
}
