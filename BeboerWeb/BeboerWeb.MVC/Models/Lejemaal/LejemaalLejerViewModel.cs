using BeboerWeb.API.Contract.DTO;

namespace BeboerWeb.MVC.Models
{
    public class LejemaalLejerViewModel
    {
        public LejemaalViewModel Lejemaal { get; set; } = new LejemaalViewModel();
        public List<LejerViewModel> Lejere { get; set; } = new List<LejerViewModel>();

        public void AddDataFromDto(LejemaalDTO dto)
        {
            Lejemaal.AddDataFromDto(dto);
            foreach (var lejerDto in dto.Lejere)
            {
                var lejer = new LejerViewModel();
                lejer.AddDataFromDto(lejerDto);
                Lejere.Add(lejer);
            }
        }

    }
}
