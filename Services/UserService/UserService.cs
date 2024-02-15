using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Models;
using JWT_TokenBased.DTOs;

namespace JWT_TokenBased.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext applicationDbContext)
        {
            // get db context thru DI
            context = applicationDbContext;
        }

        public BaseResponse CreateUser(CreateUserRequest request)
        {
            BaseResponse response;
            try
            {
                UserModel newUser = new UserModel
                {
                    first_name = request.first_name,
                    last_name = request.last_name,
                    email = request.email,
                    username = request.username,
                    password = request.password
                   
                };

                using (context)
                { 
                    context.Add(newUser);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created new user " }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal Server Error:" + ex.Message }
                };
            }

            return response;
        }

    }
}
