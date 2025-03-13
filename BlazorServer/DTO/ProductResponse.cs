using System.ComponentModel.DataAnnotations;

namespace BlazorServer.DTO
{
    public class ProductResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
    }
}
