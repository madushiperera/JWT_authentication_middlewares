using JWT_TokenBased.DTOs.Requests;
using JWT_TokenBased.DTOs.Responses;
using JWT_TokenBased.Models;
using JWT_TokenBased.DTOs;

namespace JWT_TokenBased.Services.StoryService
{
    public class StoryService : IStoryService
    {
        private readonly ApplicationDbContext context;

        public StoryService(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        public BaseResponse CreateStory(CreateStoryRequest request)
        {
            BaseResponse response;
            try
            {
                StoryModel newStory = new StoryModel();
                
                newStory.title = request.title;
                newStory.description = request.description;


                using (context)
                {
                    context.Add(newStory);
                    context.SaveChanges();
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { message = "Successfully created the new Story " }
                };

                return response;
            }

            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = ex.Message
                };
                return response;
            }
        }


        public BaseResponse StoryList()
        {
            BaseResponse response;

            try
            {
                List<StoryDTO> story = new List<StoryDTO>();

                foreach (var stories in context.Story.ToList())
                {
                    story.Add(new StoryDTO
                    {
                        id = stories.id,  
                        user_id= stories.user_id,
                        title = stories.title,
                        description = stories.description
                    }); ;
                }

                response = new BaseResponse
                {
                    status_code = StatusCodes.Status200OK,
                    data = new { story }
                };
            }
            catch (Exception ex)
            {
                response = new BaseResponse
                {
                    status_code = StatusCodes.Status500InternalServerError,
                    data = new { message = "Internal server error: " + ex.Message }
                };
            }

            return response;
        }

    }
}
