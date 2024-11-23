using Application.Dtos.User;
using Domain.Authentication;
using PassionPortal.Application.Commons.Interfaces;
using PassionPortal.Application.Commons.Interfaces.Authentication;
using System.Security.Cryptography;
using System.Text;

namespace PassionPortal.Application.Authentications
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenProviderService _tokenProviderService;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, ITokenProviderService tokenProviderService)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _tokenProviderService = tokenProviderService;
        }

        public async Task<UserTokenDto> CreateUser(UserRegisterDto userRegisterDto, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository
                .GetByUsername(userRegisterDto.UserName, cancellationToken);

            if (userExists is not null)
                return null;

            using var hmac = new HMACSHA512();

            User newUser = new User
            {
                UserName = userRegisterDto.UserName.ToLower(),
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                FullName = userRegisterDto.FirstName + " " + userRegisterDto.LastName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key
            };

            await _userRepository.Add(newUser, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new UserTokenDto()
            {
                Token = _tokenProviderService.CreateToken(newUser)
            };
        }

        public async Task<UserTokenDto> LoginUser(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            var userExists = await _userRepository
                .GetByUsername(userLoginDto.UserName, cancellationToken);

            if (userExists is not null)
                return null;

            using var hmac = new HMACSHA512(userExists.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != userExists.PasswordHash[i])
                    return null;
            }

            return new UserTokenDto()
            {
                Token = _tokenProviderService.CreateToken(userExists)
            };
        }
    }
}
