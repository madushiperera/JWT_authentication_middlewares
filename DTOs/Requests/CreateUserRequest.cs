using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs.Requests
{
    public class CreateUserRequest
    {
        [Required]
        [NameValidationAttribute]
        public string first_name {  get; set; }

        [Required]
        [NameValidationAttribute]
        public string last_name { get; set; }

        [Required]
        [EmailValidationAttribute]
        public string email { get; set; }

        [Required]
        [UsernameValidationAttribute]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        [NameValidationAttribute]
        public string? calling_name { get; set; }    
        
    }
}
