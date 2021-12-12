using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface IOpslagRepository
    {
        public List<Opslag> GetAllOpslag();
        public List<Opslag> GetOpslagByEjendomme(List<Ejendom> ejendomme);
        public Opslag GetOpslag(Guid id);
        public Guid CreateOpslag(Opslag opslag);
        public void UpdateOpslag(Opslag opslag);
        public void DeleteOpslag(Opslag opslag);
        public void LinkOpslagWithEjendom(Guid opslagsId, Guid ejendomId);
        public void UnlinkOpslagWithEjendomme(Guid opslagsId);
    }
}
