using System.ComponentModel.DataAnnotations;

namespace BlazorServer.DTO
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
