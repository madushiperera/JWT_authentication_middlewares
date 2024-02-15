using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs
{
    public class StoryDTO
    {
        public long id {  get; set; }

        [Required]
        public string title { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public long user_id { get; set; }


    }
}
