using Application.Dtos.User;
using Microsoft.AspNetCore.Mvc;
using PassionPortal.Application.Authentications;
using System.Threading;

namespace PassionPortal.API.Controllers
{
    public class AuthController: BaseApiController
    {
        protected readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserTokenDto>> Register(UserRegisterDto userRegisterDto, CancellationToken cancellationToken)
        {
            var result = await _userService.CreateUser(userRegisterDto, cancellationToken);

            if (result is null) 
                return BadRequest();
            else
                return Ok();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserTokenDto>> Login(UserLoginDto userLoginDto, CancellationToken cancellationToken)
        {
            var result = await _userService.LoginUser(userLoginDto, cancellationToken);

            if (result is null)
                return BadRequest();
            else
                return Ok();
        }
    }
}
