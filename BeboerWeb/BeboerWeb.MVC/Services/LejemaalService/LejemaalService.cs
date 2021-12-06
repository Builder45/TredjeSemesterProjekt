using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;
using System.Text.Json;
using BeboerWeb.API.Contract;

namespace BeboerWeb.MVC.Services.LejemaalService
{
    public class LejemaalService : ILejemaalService
    {
        private readonly LejemaalServiceConfig _lejemaalServiceConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public LejemaalService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _lejemaalServiceConfig = options.Value.LejemaalServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<LejemaalDTO>> GetLejemaalAsync() =>
            await _httpClient.GetFromJsonAsync<List<LejemaalDTO>>(_lejemaalServiceConfig.ServiceUrl);

         public async Task<LejemaalDTO> GetLejemaalByLejemaalIdAsync(Guid id) =>
           await _httpClient.GetFromJsonAsync<LejemaalDTO>(_lejemaalServiceConfig.ServiceUrl+$"/{id}");

        public async Task CreateLejemaal(LejemaalDTO dto)
        {
            await _httpClient.PostAsJsonAsync(_lejemaalServiceConfig.ServiceUrl, dto);
        }

        public async Task UpdateLejemaalAsync(LejemaalDTO dto) =>
            await _httpClient.PutAsJsonAsync(_lejemaalServiceConfig.ServiceUrl, dto);

        public async Task<List<LejemaalDTO>> GetLejerLejemaal(Guid id) =>
            await _httpClient.GetFromJsonAsync<List<LejemaalDTO>>(_lejemaalServiceConfig.ServiceUrl + $"/Lejer/{id}");
    }
}
