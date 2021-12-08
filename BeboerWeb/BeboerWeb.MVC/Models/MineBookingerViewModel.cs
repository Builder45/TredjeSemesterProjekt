namespace BeboerWeb.MVC.Models
{
    public class MineBookingerViewModel
    {
        public BookingViewModel Booking { get; set; } = new BookingViewModel();
        public List<BookingViewModel> Bookinger { get; set; } = new List<BookingViewModel>();
    }
}
