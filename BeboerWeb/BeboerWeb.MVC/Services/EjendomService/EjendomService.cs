using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using BeboerWeb.MVC.Services;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System;


namespace BeboerWeb.MVC.Services.EjendomService
{
    public class EjendomService : IEjendomService
    {
        private readonly EjendomServiceConfig _ejendomServiceConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public EjendomService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _ejendomServiceConfig = options.Value.EjendomServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }
        public async Task<List<EjendomDTO>> GetEjendommeAsync() =>
     await _httpClient.GetFromJsonAsync<List<EjendomDTO>>(
           "api/Ejendom");
    } 
}
