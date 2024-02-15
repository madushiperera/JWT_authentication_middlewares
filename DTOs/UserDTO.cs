using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs
{
    public class UserDTO
    {
        [Required]
        public long id { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [Required]
        public DateTime created_at { get; set; }
        [Required]
        public DateTime updated_at { get; set;}

    }
}
