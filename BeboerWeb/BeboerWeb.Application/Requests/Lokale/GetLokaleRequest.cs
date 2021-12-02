using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Lokale
{
    public class GetLokaleRequest
    {
        public Guid LokaleId { get; set; }
        public Guid EjendomId { get; set; }
    }
}
