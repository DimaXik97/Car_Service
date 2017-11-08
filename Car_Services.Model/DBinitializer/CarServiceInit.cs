using Car_Service.Model.EF;
using Car_Service.Model.Entities;
using Car_Service.Model.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Service.DAL.DBinitializer
{
    class CarServiceInit : CreateDatabaseIfNotExists<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));

            var user = new ApplicationUser { Email = "somemail@mail.ru", UserName = "somemail@mail.ru" };
            var result = userManager.CreateAsync(user, "12345qwerty");
            userManager.AddToRoleAsync(user.Id, "admin");
            base.Seed(context);
        }
    }
}
