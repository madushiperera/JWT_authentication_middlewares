using System.ComponentModel.DataAnnotations;

namespace JWT_TokenBased.DTOs
{
    public class MessageDTO
    {
        public string Message {  get; set; }
        public MessageDTO(string message)
        {
            Message= message;
        }

    }
}

