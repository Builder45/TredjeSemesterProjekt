namespace BeboerWeb.Application.Requests.Opslag
{
    public class DeleteOpslagRequest
    {
        public Guid Id { get; set; }

        public DeleteOpslagRequest(Guid id)
        {
            Id = id;
        }
    }
}
