using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;

namespace JWT_TokenBased.Services.StoryService
{
    public interface IStoryService
    {
        BaseResponse CreateStory(CreateStoryRequest request);
        BaseResponse StoryList();
    }
}
