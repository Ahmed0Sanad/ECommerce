using cfCore_2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cfCore_2.AppConfiguration
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event_Class>
    {
        public void Configure(EntityTypeBuilder<Event_Class> builder)
        {
            
        }
    }
}
