using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Services.StoryService;
using JWT_TokenBased.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT_TokenBased.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoryController : ControllerBase
    {
        private readonly IStoryService storyService;

        public StoryController(IStoryService storyService)
        {
            this.storyService = storyService;
        }

        [HttpPost("CreateStory")]
        public BaseResponse CreateStory( CreateStoryRequest request)
        {
            return storyService.CreateStory(request);
        }

        [HttpGet("list")]
        public BaseResponse StoryList()
        {
            return storyService.StoryList();
        } 
    }
}
