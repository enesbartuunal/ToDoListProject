using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using MZKWebApplication.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(MZKWebApplication.Startup))]
namespace MZKWebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));



            if (!roleManager.RoleExists("Admin"))
            {


                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

            }

                var user = new ApplicationUser();
                user.UserName = "adminastor";
                user.Email = "adminastor@gmail.com";

                string userPWD = "Ebu2040+-";

                var chkUser = UserManager.Create(user, userPWD);


                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            


            if (!roleManager.RoleExists("User"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "User";
                roleManager.Create(role);

            }


        }
    }
}
