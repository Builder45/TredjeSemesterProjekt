using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Lejer
{
    public class GetLejerRequest
    {
        public Guid LejerId { get; set; }
        public Guid LejemaalId { get; set; }
        public Guid EjendomId { get; set; }
    }

}
