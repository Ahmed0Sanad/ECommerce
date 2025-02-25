using ECommerce.Core.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Repository.Identity
{
    public  class IdentityDataBase : IdentityDbContext<AppUser>
    {
        public IdentityDataBase(DbContextOptions<IdentityDataBase> options):base(options)
        {
            
        }

        
    }
}
