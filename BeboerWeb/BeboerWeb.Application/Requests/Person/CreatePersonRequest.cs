using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests
{
    public class CreatePersonRequest
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Telefonnr { get; set; }
        public Guid BrugerId { get; set; }

        public CreatePersonRequest(string fornavn, string efternavn, int telefonnr, Guid brugerId)
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            Telefonnr = telefonnr;
            BrugerId = brugerId;
        }
    }
}
