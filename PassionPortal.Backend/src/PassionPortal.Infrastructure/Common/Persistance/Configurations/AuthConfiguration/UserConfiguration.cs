using Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassionPortal.Infrastructure.Common.Persistance.Configurations;

namespace PassionPortal.Infrastructure.Common.Persistance.Configurations.AuthConfiguration;

public class UserConfiguration : BaseEntityConfiguration, IEntityTypeConfiguration<User>
{
    public UserConfiguration() : base() { }
    public void Configure(EntityTypeBuilder<User> builder)
    {
        ApplyConfiguration(builder);
        ConfigurationBase(builder);
    }

    public static void ApplyConfiguration(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.Property(p => p.UserName).HasMaxLength(255);
        builder.Property(p => p.FirstName).HasMaxLength(255);
        builder.Property(p => p.LastName).HasMaxLength(255);
        builder.Property(p => p.FullName).HasMaxLength(255);

        Seed(builder);
    }

    private static void Seed(EntityTypeBuilder<User> builder)
    {
        builder.HasData(new User()
        {
            Id = -1,
            UserName = "System",
            FirstName = "System",
            LastName = "Admin",
            FullName = "System Admin",
            PasswordHash = [],
            PasswordSalt = [],
        });
    }
}
