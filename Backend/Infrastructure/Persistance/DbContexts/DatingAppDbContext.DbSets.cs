using Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;
public sealed partial class DatingAppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
}
