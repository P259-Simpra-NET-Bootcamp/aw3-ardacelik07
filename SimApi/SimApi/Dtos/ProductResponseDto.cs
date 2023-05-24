using DataLayer.Models;

namespace SimodevApi.Dtos
{
    public class ProductResponseDto
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

     

        public int categoryId { get; set; }
    }
}
