using ECommerce.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Core.Services.Contract
{
    public interface IAuthService
    {
        public Task<string> GenerateToke(AppUser appUser, UserManager<AppUser> userManager);
    }
}
