namespace BeboerWeb.Application.Requests.Vicevaert
{
    public class AddVicevaertToEjendomRequest
    {
        public Guid PersonId { get; set; }
        public Guid EjendomId { get; set; }
    }
}
