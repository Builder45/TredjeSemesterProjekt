using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface IVicevaertRepository
    {
        List<Vicevaert> GetVicevaerterByEjendom(Guid ejendomId);
        void LinkVicevaert(Vicevaert vicevaert);
        void UnlinkVicevaert(Vicevaert vicevaert);
        void AddVicevaertToEjendom(Guid personId, Guid ejendomId);
    }
}
