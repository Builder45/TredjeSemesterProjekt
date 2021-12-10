using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.API.Contract.DTO
{
    public class OpslagDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Besked { get; set; }
        public Guid EjendomId { get; set; }
    }
}
