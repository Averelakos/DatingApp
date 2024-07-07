using Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public sealed partial class DatingAppDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ModelCreating(modelBuilder);
    }

    public void ModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

