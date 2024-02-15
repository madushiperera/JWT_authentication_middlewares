using JWT_TokenBased.DTOs;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Helper.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Threading.Tasks;

namespace JWT_TokenBased.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            
            string? token = httpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")[1];

            if (token == null)
            {
                if (IsEnabledUnauthorizedRoute(httpContext))
                {
                    return _next(httpContext);
                }
                // BaseResponse response = new BaseResponse(StatusCodes.Status401Unauthorized, new LoginDetailDTO("Unauthorized"));
                BaseResponse response = new BaseResponse { status_code = StatusCodes.Status401Unauthorized, data = new MessageDTO("Unauthorized") };
                httpContext.Response.StatusCode = response.status_code;
                httpContext.Response.ContentType = "application/json";
                return httpContext.Response.WriteAsJsonAsync(response);
            }
            else
            {
                if (JwtUtils.ValidateJwtToken(token))
                {
                    return _next(httpContext);
                }
                else
                {
                    // BaseResponse response = new BaseResponse(StatusCodes.Status401Unauthorized, new LoginDetailDTO("Unauthorized"));
                    BaseResponse response = new BaseResponse { status_code = StatusCodes.Status401Unauthorized, data = new MessageDTO("Unauthorized") };
                    httpContext.Response.StatusCode = response.status_code;
                    httpContext.Response.ContentType = "application/json";
                    return httpContext.Response.WriteAsJsonAsync(response);

                }
            }
        }

        // <summary>
        //  </summary>

        /// <param name="httpContext">  </param>
        /// <returns></returns>


        private bool IsEnabledUnauthorizedRoute(HttpContext httpContext)
        {
            List<string> enabledRoutes = new List<string>
            {
            "/api/User/save",
            "/api/Auth/login"
            };

            bool isEnableUnauthorizedRoute = false;

            if (httpContext.Request.Path.Value is not null)
            {
                isEnableUnauthorizedRoute = enabledRoutes.Contains(httpContext.Request.Path.Value);
            }
            return isEnableUnauthorizedRoute;

        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class JwtMiddlewareExtensions
    {
        public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<JwtMiddleware>();
        }
    }
}



