using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs.Requests
{
    public class CreateStoryRequest
    {
        
        public long user_id { get; set; }
        
        [Required]
        public string title { get; set; }

        
        public string description { get; set; }

    }
}
