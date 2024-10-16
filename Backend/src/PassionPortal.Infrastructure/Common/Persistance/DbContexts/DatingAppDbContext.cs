using Microsoft.EntityFrameworkCore;

namespace PassionPortal.Infrastracture;

public sealed partial class DatingAppDbContext(DbContextOptions<DatingAppDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
