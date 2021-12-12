namespace BeboerWeb.Application.Requests.Opslag
{
    public class GetOpslagRequest
    {
        public Guid Id { get; set; }
        public Guid BrugerId { get; set; }

        public GetOpslagRequest(Guid id)
        {
            Id = id;    
        }
        public GetOpslagRequest() {}
    }
}
