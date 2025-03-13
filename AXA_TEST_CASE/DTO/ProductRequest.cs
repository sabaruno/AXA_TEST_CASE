using System.ComponentModel.DataAnnotations;

namespace WebAPI.DTO
{
    public class ProductRequest
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }
    }
}
