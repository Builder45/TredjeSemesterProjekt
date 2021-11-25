using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests
{
    public class UpdateEjendomRequest
    {
        public Guid Id { get; set; }
        public string Adresse { get; set; }
        public int Postnr { get; set; }
        public string By { get; set; }

        public UpdateEjendomRequest(Guid id, string adresse, int postnr, string by)
        {
            Id = id;
            Adresse = adresse;
            Postnr = postnr;
            By = by;
        }
    }
}
