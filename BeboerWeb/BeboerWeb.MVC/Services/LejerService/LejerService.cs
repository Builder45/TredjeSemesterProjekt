using System.Text.Json;
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;

namespace BeboerWeb.MVC.Services.LejerService
{
    public class LejerService : ILejerService
    {
        private readonly LejerServiceConfig _lejerApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public LejerService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _lejerApiConfig = options.Value.LejerServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<LejerDTO>> GetLejereByEjendomAsync(Guid id) =>
            await _httpClient.GetFromJsonAsync<List<LejerDTO>>($"{_lejerApiConfig.ServiceUrl}/ByEjendom/{id}");

        public async Task<List<LejerDTO>> GetLejereByLejemaalAsync(Guid id) =>
            await _httpClient.GetFromJsonAsync<List<LejerDTO>>($"{_lejerApiConfig.ServiceUrl}/ByLejemaal/{id}");

        public async Task<LejerDTO> GetLejerAsync(Guid id) =>
            await _httpClient.GetFromJsonAsync<LejerDTO>($"{_lejerApiConfig.ServiceUrl}/{id}");

        public async Task CreateLejerAsync(LejerDTO dto) =>
            await _httpClient.PostAsJsonAsync(_lejerApiConfig.ServiceUrl, dto);

        public async Task UpdateLejerAsync(LejerDTO dto) =>
            await _httpClient.PutAsJsonAsync(_lejerApiConfig.ServiceUrl, dto);
    }
}
