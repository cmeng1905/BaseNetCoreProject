using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("AppUserRole");
            builder.HasKey(u => u.Id);
            builder.HasOne(s=>s.AppRole)
                     .WithMany(s=>s.AppUserRoles)
                     .HasForeignKey(ur => ur.RoleId);

        }
    }
}
