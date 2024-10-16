using Domain.Authentication;
using Microsoft.EntityFrameworkCore;
using PassionPortal.Application.Commons.Interfaces;
using PassionPortal.Application.Commons.Interfaces.Authentication;
using PassionPortal.Infrastracture;

namespace PassionPortal.Infrastructure.Repositories.Authentication
{
    public class UserRepository : BaseRepository<User>, IUserRepository 
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserRepository(DatingAppDbContext dbcontext, IUnitOfWork unitOfWork) : base(dbcontext) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User?> GetByUsername(string username, CancellationToken cancellationToken)
        {
            return await SetWithIncludes()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower(), cancellationToken);
        }

        public override IQueryable<User> SetWithIncludes()
        {
            return base.SetWithIncludes();
        }
    }
}
