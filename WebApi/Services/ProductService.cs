using System.Text.Json;
using WebApi.DTOs;
using WebApi.Helpers;
using WebApi.Models;

namespace WebApi.Services
{
    public class ProductService
    {
        private readonly GoldPriceService _goldPriceService;
        private readonly IWebHostEnvironment _env;

        public ProductService(GoldPriceService goldPriceService, IWebHostEnvironment env)
        {
            _goldPriceService = goldPriceService;
            _env = env;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            var goldPrice = await _goldPriceService.GetGoldPriceAsync();
            var jsonPath = Path.Combine(_env.ContentRootPath, "Data", "products.json");
            var json = await File.ReadAllTextAsync(jsonPath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var products = JsonSerializer.Deserialize<List<Product>>(json, options);

            if (products == null)
                return Enumerable.Empty<ProductDto>();

            return products.Select(p => new ProductDto
            {
                Name = p.Name,
                Weight = p.Weight,
                Images = p.Images,
                PopularityScoreOutOfFive = PriceCalculator.ConvertPopularityToFiveScale(p.PopularityScore),
                Price = PriceCalculator.CalculatePrice(p.PopularityScore, p.Weight, goldPrice)
            });
        }
    }
}
