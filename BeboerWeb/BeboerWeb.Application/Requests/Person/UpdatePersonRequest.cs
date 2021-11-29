namespace BeboerWeb.Application.Requests.Person
{
    public class UpdatePersonRequest
    {
        public Guid Id { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public int Telefonnr { get; set; }
        public Guid BrugerId { get; set; }

        public UpdatePersonRequest(Guid id, string fornavn, string efternavn, int telefonnr, Guid brugerId)
        {
            Id = id;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Telefonnr = telefonnr;
            BrugerId = brugerId;
        }
    }
}
