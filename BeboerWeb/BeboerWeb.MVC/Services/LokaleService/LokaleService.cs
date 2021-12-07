using System.Text.Json;
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;

namespace BeboerWeb.MVC.Services.LokaleService
{
    public class LokaleService : ILokaleService
    {
        private readonly LokaleServiceConfig _lokaleApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public LokaleService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _lokaleApiConfig = options.Value.LokaleServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<LokaleDTO>> GetLokalerAsync() =>
            await _httpClient.GetFromJsonAsync<List<LokaleDTO>>(_lokaleApiConfig.ServiceUrl);

        public async Task<LokaleDTO> GetLokaleAsync(Guid id) =>
            await _httpClient.GetFromJsonAsync<LokaleDTO>(_lokaleApiConfig.ServiceUrl + $"/{id}");

        public async Task CreateLokaleAsync(LokaleDTO dto) =>
            await _httpClient.PostAsJsonAsync(_lokaleApiConfig.ServiceUrl, dto);

        public async Task UpdateLokaleAsync(LokaleDTO dto) =>
            await _httpClient.PutAsJsonAsync(_lokaleApiConfig.ServiceUrl, dto);
    }
}
