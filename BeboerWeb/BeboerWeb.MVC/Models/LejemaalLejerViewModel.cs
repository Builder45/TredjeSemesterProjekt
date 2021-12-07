﻿using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejemaalLejerViewModel
    {
        //public Guid Id { get; set; }
        //public string Adresse { get; set; }
        //public string Etage { get; set; }
        //public double Husleje { get; set; }
        //public double Areal { get; set; }
        //public bool Koekken { get; set; }
        //public bool Badevaerelse { get; set; }

        public LejemaalViewModel Lejemaal { get; set; } = new LejemaalViewModel();
        public List<LejerViewModel> Lejere { get; set; } = new List<LejerViewModel>();

        //public LejemaalDTO GetLejemaalDTO()
        //{
        //    return new LejemaalDTO()
        //    {
        //        Id = Lejemaal.Id,
        //        Adresse = Lejemaal.Adresse,
        //        Areal = Lejemaal.Areal,
        //        Etage = Lejemaal.Etage,
        //        Husleje = Lejemaal.Husleje,
        //        Badevaerelse = Lejemaal.Badevaerelse,
        //        Koekken = Lejemaal.Koekken
        //    };
        //}
        public void AddDataFromDto(LejemaalDTO dto)
        {
            Lejemaal.Id = dto.Id;
            Lejemaal.Adresse = dto.Adresse;
            Lejemaal.Etage = dto.Etage;
            Lejemaal.Husleje = dto.Husleje;
            Lejemaal.Areal = dto.Areal;
            Lejemaal.Koekken = dto.Koekken;
            Lejemaal.Badevaerelse = dto.Badevaerelse;
            foreach (var lejerDto in dto.Lejere)
            {
                var lejer = new LejerViewModel();
                lejer.AddDataFromDto(lejerDto);
                Lejere.Add(lejer);
            }
        }

    }
}
