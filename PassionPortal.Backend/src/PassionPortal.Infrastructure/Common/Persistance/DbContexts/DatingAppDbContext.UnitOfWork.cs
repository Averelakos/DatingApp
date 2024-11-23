using Microsoft.EntityFrameworkCore;
using PassionPortal.Application.Commons.Interfaces;

namespace PassionPortal.Infrastracture;

public sealed partial class DatingAppDbContext : DbContext, IUnitOfWork
{
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        try
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
            throw;
        }
    }
}
