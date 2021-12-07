using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BeboerWeb.MVC.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly PersonServiceConfig _personApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public PersonService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory) {
            _personApiConfig = options.Value.PersonServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<PersonDTO>> GetPersonerAsync() =>
            await _httpClient.GetFromJsonAsync<List<PersonDTO>>(_personApiConfig.ServiceUrl);

        public async Task<PersonDTO> GetPersonByBrugerAsync(Guid brugerId) =>
           await _httpClient.GetFromJsonAsync<PersonDTO>($"{_personApiConfig.ServiceUrl}/ByBruger/{brugerId}");

        public async Task<PersonDTO> GetPersonAsync(Guid id) =>
           await _httpClient.GetFromJsonAsync<PersonDTO>($"{_personApiConfig.ServiceUrl}/{id}");

        public async Task CreatePersonAsync(PersonDTO dto) =>
            await _httpClient.PostAsJsonAsync(_personApiConfig.ServiceUrl, dto);

        public async Task UpdatePersonAsync(PersonDTO dto) =>
            await _httpClient.PutAsJsonAsync(_personApiConfig.ServiceUrl, dto);
    }
}
