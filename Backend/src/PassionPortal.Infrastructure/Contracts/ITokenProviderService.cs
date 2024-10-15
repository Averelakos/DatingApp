using Domain.Authentication;

namespace PassionPortal.Infrastracture.Contracts
{
    public interface ITokenProviderService
    {
        string CreateToken(User user);
    }
}
