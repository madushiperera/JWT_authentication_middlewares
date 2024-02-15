using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs.Requests
{
    public class UserLoginRequest
    {
        [Required]
        public string username { get; set;}

        [Required]
        public string password { get; set;}
    }
}
