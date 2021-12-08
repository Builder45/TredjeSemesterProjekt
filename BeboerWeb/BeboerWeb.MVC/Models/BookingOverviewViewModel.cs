namespace BeboerWeb.MVC.Models
{
    public class BookingOverviewViewModel
    {
        public BookingViewModel Booking { get; set; } = new BookingViewModel();
        public List<BookingViewModel> ExistingBookinger { get; set; } = new List<BookingViewModel>();
        public int SearchYear { get; set; } = 2021;
        public int SearchMonth { get; set; } = 1;

        public string[] Months { get; } =
        {
            "Januar", "Februar", "Marts", "April", "Maj", "Juni", "Juli", 
            "August", "September", "Oktober", "November", "December"
        };

        //public int[] Years { get; } =
        //{
        //    DateTime.Now.Year, DateTime.Now.Year + 1, 
        //};
    }
}
