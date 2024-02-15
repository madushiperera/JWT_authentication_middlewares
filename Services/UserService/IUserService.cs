using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;

namespace JWT_TokenBased.Services.UserService
{
    public interface IUserService
    {
        BaseResponse CreateUser(CreateUserRequest request);

    }
}
