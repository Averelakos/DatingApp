using Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public sealed partial class DatingAppDbContext(DbContextOptions<DatingAppDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
    }
}
