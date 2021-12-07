using System.ComponentModel.DataAnnotations;
using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class BookingViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Start på bookingperiode")]
        [DataType(DataType.Date)]
        public DateTime BookingPeriodeStart { get; set; }

        [Display(Name = "Ende på bookingperiode")]
        [DataType(DataType.Date)]
        public DateTime BookingPeriodeSlut { get; set; }

        public void AddDataFromDTO(BookingDTO dto)
        {
            Id = dto.Id;
            BookingPeriodeStart = dto.BookingPeriodeStart;
            BookingPeriodeSlut = dto.BookingPeriodeSlut;
        }
    }
}
