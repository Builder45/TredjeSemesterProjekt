using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.API.Contract.DTO
{
    public class ServiceOversigtDTO
    {
        public Guid PersonId { get; set; }
        public Guid EjendomId { get; set; }
    }
}
