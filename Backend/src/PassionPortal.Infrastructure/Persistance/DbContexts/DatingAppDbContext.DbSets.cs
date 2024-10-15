using Domain.Authentication;
using Microsoft.EntityFrameworkCore;

namespace PassionPortal.Infrastracture;
public sealed partial class DatingAppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
}
