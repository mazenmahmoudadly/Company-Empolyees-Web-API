using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            // Use fixed Id and ConcurrencyStamp values to avoid dynamic values
            // being generated on each model build which triggers the
            // PendingModelChangesWarning from EF Core.
            builder.HasData
                   (
                     new IdentityRole
                     {
                         Id = "b1f5c9d2-3a4e-4d6b-9f2a-1c7e8d9a0b11",
                         Name = "Manager",
                         NormalizedName = "MANAGER",
                         ConcurrencyStamp = "b1f5c9d2-3a4e-4d6b-9f2a-1c7e8d9a0b11"
                     },
                    new IdentityRole
                    {
                        Id = "c2a6d8e3-5b7f-41c2-8a3e-2d9b0f1c2a22",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR",
                        ConcurrencyStamp = "c2a6d8e3-5b7f-41c2-8a3e-2d9b0f1c2a22"
                    }
              );
        }
    }
}
