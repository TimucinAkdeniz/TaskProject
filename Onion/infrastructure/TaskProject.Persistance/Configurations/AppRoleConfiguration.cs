using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.Entities;

namespace TaskProject.Persistance.Configurations
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        void IEntityTypeConfiguration<AppRole>.Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(new List<AppRole> {
                new AppRole {Id=1, Definition="Admin"},
                new AppRole {Id=2, Definition="Member"}
            });
        }
    }
}
