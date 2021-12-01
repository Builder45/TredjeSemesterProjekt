using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Lejer
{
    public class CreateLejerRequest
    {
        public DateTime LejeperiodeStart { get; set; }
        public DateTime LejeperiodeSlut { get; set; }

        public Guid LejemaalId { get; set; }

        public CreateLejerRequest(DateTime lejeperiodeStart, DateTime lejeperiodeSlut, Guid lejemaalId)
        {
            LejeperiodeStart = lejeperiodeStart;
            LejeperiodeSlut = lejeperiodeSlut;
            LejemaalId = lejemaalId;
        }
    }
}
