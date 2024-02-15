using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;

namespace JWT_TokenBased.Services.LoginDetailsService
{
    public interface IAuthService
    {
        BaseResponse UserLogin(UserLoginRequest request);
        // BaseResponse AuthenticateUser(AuthenticateUserRequest request);

    }
}
