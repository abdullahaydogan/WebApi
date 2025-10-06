using WebApi.Models;

namespace WebApi.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double PopularityScoreOutOfFive { get; set; }
        public double Weight { get; set; }
        public ProductImage Images { get; set; }
    }
}
