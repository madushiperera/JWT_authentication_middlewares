using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs
{
    public class LoginDetailDTO
    {
      
        [Required]
        public long user_id { get; set; }

        [Required]
        public string token { get; set; }
        
        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
