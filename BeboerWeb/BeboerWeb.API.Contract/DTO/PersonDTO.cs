using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.API.Contract.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Telefonnr { get; set; }
        public Guid BrugerId { get; set; }
    }
}
