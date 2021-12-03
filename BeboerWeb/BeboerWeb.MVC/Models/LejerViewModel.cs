using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejerViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Start på lejeperiode")]
        [DataType(DataType.Date)]
        public DateTime LejeperiodeStart { get; set; }

        [Display(Name = "Ende på lejeperiode")]
        [DataType(DataType.Date)]
        public DateTime LejeperiodeSlut { get; set; }

        public Guid LejemaalId { get; set; }

        public List<Guid> PersonIds { get; set; } = new List<Guid>();

        [Display(Name = "Lejer(e)")]
        public List<string> LejerNavne { get; set; } = new List<string> {"Tomgang"};

        public void AddDataFromDto(LejerDTO dto)
        {
            Id = dto.Id;
            LejeperiodeStart = dto.LejeperiodeStart;
            LejeperiodeSlut = dto.LejeperiodeSlut;
            LejemaalId = dto.LejemaalId;
            PersonIds = dto.PersonIds;

            if (dto.LejerNavne.Count == 0) return;
            LejerNavne.Remove("Tomgang");
            foreach (var navn in dto.LejerNavne)
            {
                LejerNavne.Add(navn);
            }
        }
    }
}
