using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using OnlineShop.Clients.MVC.Models;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineShop.Clients.MVC.Startup))]
namespace OnlineShop.Clients.MVC
{
    public partial class Startup
    {
        private const string adminRole = "admin";
        private const string adminMail = "admin@admin.com";
        private const string adminPass = "password";


        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            this.SeedAdminUser();
        }

        private void SeedAdminUser()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            
            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists(adminRole))
            {

                // first we create Admin rool   
                var role = new IdentityRole()
                {
                    Name = adminRole
                };
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser()
                {
                    UserName = adminMail,
                    Email = adminMail
                };
                string userPWD = adminPass;

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, adminRole);

                }
            }
        }
    }
}
