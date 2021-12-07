using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LokaleEjendommeViewModel
    {
        public LokaleViewModel Lokale { get; set; }
        public List<EjendomViewModel> Ejendomme { get; set; }

        public LokaleDTO GetLokaleDTO()
        {
            return new LokaleDTO()
            {
                Id = Lokale.Id,
                Navn = Lokale.Navn,
                Adresse = Lokale.Adresse,
                Areal = Lokale.Areal,
                Etage = Lokale.Etage,
                Timepris = Lokale.Timepris,
                Badevaerelse = Lokale.Badevaerelse,
                Koekken = Lokale.Koekken,
                EjendomId = Lokale.EjendomId
            };
        }
    }
}
