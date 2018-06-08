using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.IO;
using UTS.ProduceStore.WebFrontEnd.Models;

[assembly: OwinStartupAttribute(typeof(UTS.ProduceStore.WebFrontEnd.Startup))]
namespace UTS.ProduceStore.WebFrontEnd
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers(); 
        }

        

        /// <summary>
        /// This method hardcodes in Users with specific roles.
        /// This code uses the ApplicationDBContext model.
        /// This code was created by following the tutorial at 
        /// source https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97
        /// </summary>
        private void createRolesandUsers()   
        {   
            ApplicationDbContext context = new ApplicationDbContext();   
   
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));   
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));   
   
   
              
            if (!roleManager.RoleExists("Editor"))   
            {   
   
                  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();   
                role.Name = "Editor";   
                roleManager.Create(role);   
                    
   
                var user = new ApplicationUser();   
                user.UserName = "e@editor.com";   
                user.Email = "e@editor.com";   
   
                string userPWD = "Abc123!";   
   
                var chkUser = UserManager.Create(user, userPWD);   
   
                  
                if (chkUser.Succeeded)   
                {   
                    var result1 = UserManager.AddToRole(user.Id, "Editor");   
   
                }   
            }

            if (!roleManager.RoleExists("DataMaintainer"))
            {

              
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "DataMaintainer";
                roleManager.Create(role);

                                 

                var user = new ApplicationUser();
                user.UserName = "dm@datamaintainer.com";
                user.Email = "dm@datamaintainer.com";

                string userPWD = "Abc123!";

                var chkUser = UserManager.Create(user, userPWD);

                
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "DataMaintainer");

                }
            }

            if (!roleManager.RoleExists("Approver"))
            {

                  
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Approver";
                roleManager.Create(role);

                                

                var user = new ApplicationUser();
                user.UserName = "a@approver.com";
                user.Email = "a@approver.com";

                string userPWD = "Abc123!";

                var chkUser = UserManager.Create(user, userPWD);

                  
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Approver");

                }
            }

            
        } 
         
    }
}
