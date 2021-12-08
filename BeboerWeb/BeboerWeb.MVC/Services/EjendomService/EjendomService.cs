using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BeboerWeb.MVC.Services.EjendomService
{
    public class EjendomService : IEjendomService
    {
        private readonly EjendomServiceConfig _ejendomApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public EjendomService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _ejendomApiConfig = options.Value.EjendomServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<EjendomDTO>> GetEjendommeAsync() =>
            await _httpClient.GetFromJsonAsync<List<EjendomDTO>>(_ejendomApiConfig.ServiceUrl);

        public async Task<List<EjendomDTO>> GetEjendommeWithLokalerAsync() =>
            await _httpClient.GetFromJsonAsync<List<EjendomDTO>>(_ejendomApiConfig.ServiceUrl + "/IncludeLokaler");

        public async Task<EjendomDTO> GetEjendomAsync(Guid Id) =>
            await _httpClient.GetFromJsonAsync<EjendomDTO>(_ejendomApiConfig.ServiceUrl + $"/{Id}");

        public async Task CreateEjendomAsync(EjendomDTO dto) =>
            await _httpClient.PostAsJsonAsync(_ejendomApiConfig.ServiceUrl, dto);

        public async Task UpdateEjendomAsync(EjendomDTO dto) =>
            await _httpClient.PutAsJsonAsync(_ejendomApiConfig.ServiceUrl, dto);
    } 
}
