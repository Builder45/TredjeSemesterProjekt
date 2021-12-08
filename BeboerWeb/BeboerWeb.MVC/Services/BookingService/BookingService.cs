using BeboerWeb.API.Contract;
using BeboerWeb.API.Contract.DTO;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace BeboerWeb.MVC.Services.BookingService
{
    public class BookingService : IBookingService
    {
        private readonly BookingServiceConfig _bookingApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _httpClient;

        public BookingService(IOptions<ApiConfig> options, IHttpClientFactory httpClientFactory)
        {
            _bookingApiConfig = options.Value.BookingServiceConfig;
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri(options.Value.BaseUrl);
        }

        public async Task<List<BookingDTO>> GetBookingerByLokaleAndSearchDateAsync(Guid lokaleId, DateTime searchDate)
        {
            var convertedSearch = ConvertDateTimeToApiDateTime(searchDate);
            return await _httpClient.GetFromJsonAsync<List<BookingDTO>>(_bookingApiConfig.ServiceUrl + $"/ByLokale/{lokaleId}/{convertedSearch}");
        }

        public async Task<List<BookingDTO>> GetBookingerByBrugerAsync(Guid brugerId) => 
            await _httpClient.GetFromJsonAsync<List<BookingDTO>>(_bookingApiConfig.ServiceUrl + $"/ByPerson/{brugerId}");

        public async Task CreateBookingAsync(BookingDTO dto) =>
            await _httpClient.PostAsJsonAsync(_bookingApiConfig.ServiceUrl, dto);
        
        public async Task DeleteBookingAsync(Guid id) =>
            await _httpClient.DeleteAsync(_bookingApiConfig.ServiceUrl+$"/{id}");

        private string ConvertDateTimeToApiDateTime(DateTime dateTime)
        {
            return dateTime.Year + "-" +
                   dateTime.Month.ToString().PadLeft(2, '0');
        }
    } 
}
