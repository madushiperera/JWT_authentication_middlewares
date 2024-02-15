using JWT_TokenBased.DTOs;
using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Helper;
using JWT_TokenBased.Helper.Utils;
using JWT_TokenBased.Models;
using JWT_TokenBased.Services.StoryService;
using Microsoft.AspNetCore.Hosting.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data.Common;

namespace JWT_TokenBased.Services.LoginDetailsService
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext context;


        public AuthService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse UserLogin(UserLoginRequest request)
        {
            try
            {
                UserModel user = context.User.FirstOrDefault(u => u.username == request.username);
                if (user == null)
                {
                    return new BaseResponse
                    {
                        status_code = StatusCodes.Status404NotFound, 
                        data = new MessageDTO("No user found with the provided username")
                    };
                }

                if (user.password != request.password)
                {
                    return new BaseResponse
                    {
                        status_code = StatusCodes.Status401Unauthorized,
                        data = new MessageDTO("Invalid password")
                    };
                }

                string jwt = JwtUtils.GenerateJwtToken(user);

                    // Save or update login detail
                LoginDetailModel loginDetail = context.LoginDetail.Where(id => id.user_id == user.id).FirstOrDefault();
                if (loginDetail == null)
                {
                     loginDetail = new LoginDetailModel
                     {
                            user_id = user.id,
                            token = jwt
                     };

                     context.LoginDetail.Add(loginDetail);
                }
                else
                {
                     loginDetail.token = jwt;
                }
                
                context.SaveChanges();

                return new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { token = jwt }
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new MessageDTO(ex.Message)
                };
            }

        }

        /*
        public BaseResponse AuthenticateUser(AuthenticateUserRequest request)
        {
            try
            {
                UserModel? user = context.User.Where(u => u.username == request.username).FirstOrDefault();
                if (user == null)
                {
                    return new BaseResponse 
                    { 
                        status_code = StatusCodes.Status401Unauthorized, 
                        data = new MessageDTO("Invalid user name or password") 
                    };
                }

                string md5Password = Supports.GenerateMD5(request.password);

                if (user.password == md5Password)
                {
                    string jwt = JwtUtils.GenerateJwtToken(user);

                    LoginDetailModel? LoginDetail = context.LoginDetail.Where(id => id.user_id == user.id).FirstOrDefault();
                    if (LoginDetail != null)
                    {
                        LoginDetail = new LoginDetailModel();
                        LoginDetail.user_id = user.id;
                        LoginDetail.token = jwt;

                        context.LoginDetail.Add(LoginDetail);
                    }
                    else
                    {
                        LoginDetail.token = jwt;
                    }

                    context.SaveChanges();

                    return new BaseResponse 
                    { 
                        status_code = StatusCodes.Status200OK, 
                        data = new { token = jwt } 
                    };
                }
                else
                {
                    return new BaseResponse 
                    { 
                        status_code = StatusCodes.Status401Unauthorized, 
                        data = new MessageDTO("Invalid user name or Password") 
                    };
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse 
                { 
                    status_code = StatusCodes.Status500InternalServerError, 
                    data = new MessageDTO(ex.Message) 
                };
            }

        }
        
       */
    }
}


