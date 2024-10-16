using Domain.Authentication;

namespace PassionPortal.Application.Commons.Interfaces.Authentication
{
    public interface IUserRepository
    {

        Task<User?> GetByUsername(string username, CancellationToken cancellationToken);
        Task Add(User user, CancellationToken cancellationToken);
        Task<bool> Update(User user, CancellationToken cancellationToken);
        Task Delete(long id, CancellationToken cancellationToken);
    }
}
