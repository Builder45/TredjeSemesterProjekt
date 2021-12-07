using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;
using System.Text.Json;
using BeboerWeb.API.Contract;

namespace BeboerWeb.MVC.Services.LejemaalService
{
    public class LejemaalService : ILejemaalService
    {
        private readonly LejemaalServiceConfig _lejemaalApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public LejemaalService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _lejemaalApiConfig = options.Value.LejemaalServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<LejemaalDTO>> GetLejemaalsAsync() =>
            await _httpClient.GetFromJsonAsync<List<LejemaalDTO>>(_lejemaalApiConfig.ServiceUrl);

        public async Task<List<LejemaalDTO>> GetLejemaalsByBrugerAsync(Guid id) =>
            await _httpClient.GetFromJsonAsync<List<LejemaalDTO>>(_lejemaalApiConfig.ServiceUrl + $"/ByBruger/{id}");

        public async Task<LejemaalDTO> GetLejemaalAsync(Guid id) =>
           await _httpClient.GetFromJsonAsync<LejemaalDTO>(_lejemaalApiConfig.ServiceUrl + $"/{id}");

        public async Task CreateLejemaalAsync(LejemaalDTO dto) =>
            await _httpClient.PostAsJsonAsync(_lejemaalApiConfig.ServiceUrl, dto);

        public async Task UpdateLejemaalAsync(LejemaalDTO dto) =>
            await _httpClient.PutAsJsonAsync(_lejemaalApiConfig.ServiceUrl, dto);
    }
}
