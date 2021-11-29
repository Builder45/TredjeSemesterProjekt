using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BeboerWeb.MVC.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly PersonServiceConfig _personServiceConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public PersonService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory) {
            _personServiceConfig = options.Value.PersonServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<PersonDTO>> GetPersonsAsync() =>
            await _httpClient.GetFromJsonAsync<List<PersonDTO>>("api/Person");

        public async Task<PersonDTO> GetPersonByUserIdAsync(Guid id) =>
           await _httpClient.GetFromJsonAsync<PersonDTO>($"api/Person/ByUser/{id}");

        public async Task<PersonDTO> GetPersonByPersonIdAsync(Guid id) =>
           await _httpClient.GetFromJsonAsync<PersonDTO>($"api/Person/{id}");

        public async Task CreatePerson(PersonDTO dto)
        {
            await _httpClient.PostAsJsonAsync(_personServiceConfig.ServiceUrl, dto);
        }

        public async Task UpdatePersonAsync(PersonDTO person) =>
            await _httpClient.PutAsJsonAsync("api/Person", person);
    }
}
