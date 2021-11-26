using BeboerWeb.MVC.Services.EjendomService;

namespace BeboerWeb.MVC.Services
{
    public class ApiConfig
        {
            public string BaseUrl { get; set; }
            public PersonServiceConfig PersonServiceConfig { get; set; }
            public EjendomServiceConfig EjendomServiceConfig { get; set; }

        }
    }


