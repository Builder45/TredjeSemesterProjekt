using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejerViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Start på lejeperiode")]
        public DateTime LejeperiodeStart { get; set; }

        [Display(Name = "Ende på lejeperiode")]
        public DateTime LejeperiodeSlut { get; set; }
        public Guid LejemaalId { get; set; }

        public List<Guid> PersonIds { get; set; } = new List<Guid>();

        public void AddDataFromDto(LejerDTO dto)
        {
            Id = dto.Id;
            LejeperiodeStart = dto.LejeperiodeStart;
            LejeperiodeSlut = dto.LejeperiodeSlut;
            LejemaalId = dto.LejemaalId;
            PersonIds = dto.PersonIds;
        }
    }
}
