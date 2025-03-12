using System.ComponentModel.DataAnnotations;

namespace AXA_TEST_CASE.DTO
{
    public class UserAccount
    {
        public int ID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
