namespace BeboerWeb.MVC.Models
{
    public class BookingOverviewViewModel
    {
        public BookingViewModel Booking { get; set; }
        public List<BookingViewModel> ExistingBookinger { get; set; } = new List<BookingViewModel>();
        public DateTime SearchDate { get; set; } = DateTime.Now;
    }
}
