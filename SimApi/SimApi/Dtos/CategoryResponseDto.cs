using DataLayer.Models;

namespace SimodevApi.Dtos
{
    public class CategoryResponseDto
    {
        public string Name { get; set; }

        public  List<ProductResponseDto> products { get; set; } = new List<ProductResponseDto>();
    }
}
