using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejemaalEjendommeViewModel
    {
        public LejemaalViewModel Lejemaal { get; set; }
        public List<EjendomViewModel> Ejendomme { get; set;}

        public LejemaalDTO GetLejemaalDTO()
        {
            return new LejemaalDTO()
            {
                Id = Lejemaal.Id,
                Adresse = Lejemaal.Adresse,
                Areal = Lejemaal.Areal,
                Etage = Lejemaal.Etage,
                Husleje = Lejemaal.Husleje,
                Badevaerelse = Lejemaal.Badevaerelse,
                Koekken = Lejemaal.Koekken,
                EjendomId = Lejemaal.EjendomId
            };
        }
    }
}
