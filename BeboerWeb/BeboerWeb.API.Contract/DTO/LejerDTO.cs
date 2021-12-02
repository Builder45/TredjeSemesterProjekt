using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.API.Contract.DTO
{
    public class LejerDTO
    {
        public Guid Id { get; set; }
        public DateTime LejeperiodeStart { get; set; }
        public DateTime LejeperiodeSlut { get; set; }
        public Guid LejemaalId { get; set; }
        public List<Guid> PersonIds { get; set; }

    }
}
