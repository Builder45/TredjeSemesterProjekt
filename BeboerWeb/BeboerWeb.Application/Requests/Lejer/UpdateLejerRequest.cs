using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Lejer
{
    public class UpdateLejerRequest
    {
        public Guid Id { get; set; }
        public DateTime LejeperiodeStart { get; set; }
        public DateTime LejeperiodeSlut { get; set; }
        public Guid LejemaalId { get; set; }
        public UpdateLejerRequest(Guid id, DateTime lejeperiodeStart, DateTime lejeperiodeSlut, Guid lejemaalId)
        {
            Id = id;
            LejeperiodeStart = lejeperiodeStart;
            LejeperiodeSlut = lejeperiodeSlut;
            LejemaalId = lejemaalId;
        }
    }
}
