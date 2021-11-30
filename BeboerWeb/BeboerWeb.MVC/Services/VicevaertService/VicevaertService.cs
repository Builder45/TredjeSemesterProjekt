using System.Text.Json;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;

namespace BeboerWeb.MVC.Services.VicevaertService
{
    public class VicevaertService
    {
        private readonly VicevaertServiceConfig _vicevaertServiceConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public VicevaertService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _vicevaertServiceConfig = options.Value.VicevaertServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task LinkVicevaert(VicevaertDTO dto)
        {
            await _httpClient.PostAsJsonAsync(_vicevaertServiceConfig.ServiceUrl, dto);
        }

        public async Task UnlinkVicevaert(VicevaertDTO dto)
        {
            await _httpClient.DeleteAsync(_vicevaertServiceConfig.ServiceUrl + $"/{dto.PersonId}");
        }
    }
}
