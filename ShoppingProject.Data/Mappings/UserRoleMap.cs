using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShoppingProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingProject.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");

            builder.HasData(new AppUserRole
            {
                UserId = Guid.Parse("ae6a5c1f-ad83-4cce-bf53-0739d89d3799"),
                RoleId = Guid.Parse("4c53cf2c-f856-4349-be2f-39e7525691c6")
            },
            new AppUserRole
            {
                UserId = Guid.Parse("681f79af-c484-4c9b-866c-6ca7d847d6a6"),
                RoleId = Guid.Parse("03b2227f-9a29-4c66-a2a5-c4e7c62dba11")
            });
            
        }
    }
}
