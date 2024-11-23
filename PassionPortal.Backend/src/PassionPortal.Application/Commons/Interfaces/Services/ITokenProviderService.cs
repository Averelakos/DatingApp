using Domain.Authentication;

namespace PassionPortal.Application.Commons.Interfaces
{
    public interface ITokenProviderService
    {
        string CreateToken(User user);
    }
}
