using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeboerWeb.Application.Requests.Ejendom
{
    public class CreateEjendomRequest
    {
        public string Adresse { get; set; }
        public int Postnr { get; set; }
        public string By { get; set; }

        public CreateEjendomRequest(string adresse, int postnr, string by)
        {
            Adresse = adresse;
            Postnr = postnr;
            By = by;
        }
    }
}
