namespace GamerSchool.Data.Seed
{
    using System;
    using System.Linq;
    using GamerSchool.Common;
    using GamerSchool.Data.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AdminsSeeder : IDataSeeder
    {
        public void Seed(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
          //  var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Users.Any(u => u.UserName == "PavelPavlov"))
            {
                var user = new ApplicationUser
                {
                    Email = "pavel.pavlov@gmail.com",
                    UserName = "PavelPavlov",
                    CreatedOn = DateTime.Now
                };

                userManager.Create(user, "123456");

                userManager.AddToRoles(
                    user.Id,
                    ApplicationRoles.Admin,
                    ApplicationRoles.Artist,
                    ApplicationRoles.Designer,
                    ApplicationRoles.Regular,
                    ApplicationRoles.Seller,
                    ApplicationRoles.Student,
                    ApplicationRoles.Trainer);
            }
        }
    }
}
