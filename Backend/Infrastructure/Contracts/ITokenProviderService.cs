using Domain.Authentication;

namespace Infrastructure.Contracts
{
    public interface ITokenProviderService
    {
        string CreateToken(User user);
    }
}
