using BeboerWeb.MVC.Services.EjendomService;
using BeboerWeb.MVC.Services.LokaleService;
using BeboerWeb.MVC.Services.VicevaertService;

namespace BeboerWeb.MVC.Services
{
    public class ApiConfig
        {
            public string BaseUrl { get; set; }
            public PersonServiceConfig PersonServiceConfig { get; set; }
            public EjendomServiceConfig EjendomServiceConfig { get; set; }
            public LejemaalServiceConfig LejemaalServiceConfig { get; set; }
            public LokaleServiceConfig LokaleServiceConfig { get; set; }
            public VicevaertServiceConfig VicevaertServiceConfig { get; set; }

        }
    }


