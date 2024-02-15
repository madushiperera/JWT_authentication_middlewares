using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Services.LoginDetailsService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_TokenBased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authenticationService;

        // constructor
        public AuthController(IAuthService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        // end points
        [HttpPost("login")]
        public BaseResponse UserLogin(UserLoginRequest request)
        {
            return authenticationService.UserLogin(request);
        }
    }
}
