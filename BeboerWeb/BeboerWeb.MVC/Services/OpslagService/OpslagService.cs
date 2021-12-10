using System.Text.Json;
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Services.LokaleService;
using Microsoft.Extensions.Options;

namespace BeboerWeb.MVC.Services.OpslagService
{
    public class OpslagService : IOpslagService
    {
        private readonly OpslagServiceConfig _opslagApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public OpslagService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _opslagApiConfig = options.Value.OpslagServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<OpslagDTO>> GetOpslagAsync() =>
            await _httpClient.GetFromJsonAsync<List<OpslagDTO>>(_opslagApiConfig.ServiceUrl);

        public async Task<OpslagDTO> GetOpslagAsync(Guid id) =>
            await _httpClient.GetFromJsonAsync<OpslagDTO>(_opslagApiConfig.ServiceUrl + $"/{id}");

        public async Task CreateOpslagAsync(OpslagDTO dto) =>
            await _httpClient.PostAsJsonAsync(_opslagApiConfig.ServiceUrl, dto);

        public async Task UpdateOpslagAsync(OpslagDTO dto) =>
            await _httpClient.PutAsJsonAsync(_opslagApiConfig.ServiceUrl, dto);

        public async Task DeleteOpslagAsync(Guid id) =>
            await _httpClient.DeleteAsync(_opslagApiConfig.ServiceUrl + $"/{id}");
    }
}
