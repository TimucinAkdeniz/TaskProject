using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Domain.Entities;

namespace TaskProject.Persistance.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasData(new List<AppUser> {
                new AppUser {Id=1, UserName="Admin",AppRoleId=1,Password="1234"},
                new AppUser {Id=2, UserName="Member",AppRoleId=2,Password="1234"}
            });

            builder.HasOne(x => x.AppRole).WithMany(x => x.AppUsers).HasForeignKey(x => x.AppRoleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
