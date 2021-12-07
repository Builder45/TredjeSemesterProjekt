using System.Text.Json;
using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;

namespace BeboerWeb.MVC.Services.VicevaertService
{
    public class VicevaertService : IVicevaertService
    {
        private readonly VicevaertServiceConfig _vicevaertApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public VicevaertService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _vicevaertApiConfig = options.Value.VicevaertServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task LinkVicevaertAsync(VicevaertDTO dto) =>
            await _httpClient.PostAsJsonAsync(_vicevaertApiConfig.ServiceUrl, dto);

        public async Task UnlinkVicevaertAsync(Guid brugerId) =>
            await _httpClient.DeleteAsync(_vicevaertApiConfig.ServiceUrl + $"/{brugerId}");
    }
}
