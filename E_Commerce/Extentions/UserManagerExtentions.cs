using ECommerce.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_Commerce.Extentions
{
    public static class UserManagerExtentions
    {
        public static Task<AppUser> FindUserWithAddressAsync(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            var Email = user.FindFirstValue(ClaimTypes.Email);
            var userWithAddress = userManager.Users.Where(u=>u.Email == Email).Include(u=>u.addresses).SingleOrDefaultAsync();
            return userWithAddress;
        }
    }
}
