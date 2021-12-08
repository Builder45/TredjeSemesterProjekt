namespace BeboerWeb.MVC.Models
{
    public class BookingOverviewViewModel
    {
        public BookingViewModel Booking { get; set; } = new BookingViewModel();
        public List<BookingViewModel> ExistingBookinger { get; set; } = new List<BookingViewModel>();
        public DateTime SearchDate { get; set; } = DateTime.Now;
        public int SearchYear { get; set; }
        public int SearchMonth { get; set; }
    }
}
