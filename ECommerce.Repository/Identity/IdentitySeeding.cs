using ECommerce.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Identity
{
    public static class IdentitySeeding
    {
      
        public static async Task Seed (UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    Email = "ahmedsanad880@gmail.com",
                    UserName = "AhmedSanad",
                    Fname = "Ahmed",
                    LName = "Sanad",
                    PhoneNumber = "01098689817"

                };
                await userManager.CreateAsync (user);
            }
        }
    }
}
