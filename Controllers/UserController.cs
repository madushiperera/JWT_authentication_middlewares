using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Models;
using JWT_TokenBased.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_TokenBased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        // end points
        

        [HttpPost("save")]
        public BaseResponse CreateUser(CreateUserRequest request)
        {
            return userService.CreateUser(request);
        }





    }

}


/*public IActionResult CreateUser([FromBody] UserModel user)//checks if there are any validation errors. If there, returns a BadRequest response to the client.
{
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    try
    {
        // Your logic for creating the user goes here
        // For example, you could save the user to the database
        // dbContext.Users.Add(user);
        // dbContext.SaveChanges();

        return Ok("User created successfully");
    }
    catch (Exception ex)
    {
        return StatusCode(500, "Internal server error");
    }
}

 public BaseResponse CreateUser(CreateUserRequest request)
        {
            return userService.CreateUser(request);
        }*/
