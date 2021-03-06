using BeboerWeb.MVC.Services.BookingService;
using BeboerWeb.MVC.Services.EjendomService;
using BeboerWeb.MVC.Services.LejerService;
using BeboerWeb.MVC.Services.LokaleService;
using BeboerWeb.MVC.Services.OpslagService;
using BeboerWeb.MVC.Services.VicevaertService;

namespace BeboerWeb.MVC.Services
{
    public class ApiConfig
        {
            public string BaseUrl { get; set; }
            public PersonServiceConfig PersonServiceConfig { get; set; }
            public EjendomServiceConfig EjendomServiceConfig { get; set; }
            public BookingServiceConfig BookingServiceConfig { get; set; }
            public LejemaalServiceConfig LejemaalServiceConfig { get; set; }
            public LejerServiceConfig LejerServiceConfig { get; set; }
            public LokaleServiceConfig LokaleServiceConfig { get; set; }
            public VicevaertServiceConfig VicevaertServiceConfig { get; set; }
            public OpslagServiceConfig OpslagServiceConfig { get; set; }
        }
    }