using System.Text.Json;

namespace WebApi.Services
{
    public class GoldPriceService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public GoldPriceService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<double> GetGoldPriceAsync()
        {
            await Task.Delay(10); // async uyumluluğu için küçük gecikme
            return 65.0; // gram başına altın fiyatı (USD)
        }
    }
}
