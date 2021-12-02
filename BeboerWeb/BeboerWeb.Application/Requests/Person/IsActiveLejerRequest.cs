using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Person
{
    public class IsActiveLejerRequest
    {
        public Guid Id;

        public IsActiveLejerRequest(Guid id)
        {
            Id = id;
        }
    }
}
