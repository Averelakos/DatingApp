using Domain;
using Microsoft.EntityFrameworkCore;
using PassionPortal.Infrastracture;

namespace PassionPortal.Infrastructure.Repositories
{
    public class BaseRepository<T> where T : BaseEntity
    {
        private readonly DatingAppDbContext _dbcontext;

        protected BaseRepository(DatingAppDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public virtual IQueryable<T> SetWithIncludes() 
        {
            return _dbcontext.Set<T>();
        }

        public DbSet<T> Set()
        {
            return _dbcontext.Set<T>();
        }

        public async Task Add(T entity, CancellationToken cancellationToken) 
        {
            if(entity is null) throw new ArgumentNullException(nameof(entity));

            await Set().AddAsync(entity, cancellationToken);
        }

        public async Task<bool> Update(T entity, CancellationToken cancellationToken)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            var entry = Set().Entry(entity);
            await Task.CompletedTask;
            return entry.State != EntityState.Unchanged;
        }

        public async Task Delete(long id, CancellationToken cancellationToken)
        {
            var entity = await Set()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity is null) throw new ArgumentNullException(nameof(entity));
            Set().Remove(entity);
        }
    }
}
