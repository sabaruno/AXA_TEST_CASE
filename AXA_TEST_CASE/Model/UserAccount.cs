using System.ComponentModel.DataAnnotations;

namespace WebAPI.Model
{
    public class UserAccount
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
