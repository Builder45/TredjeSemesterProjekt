using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface IVicevaertRepository
    {
        void LinkVicevaert(Vicevaert vicevaert);
        void UnlinkVicevaert(Vicevaert vicevaert);
        void AddVicevaertToEjendom(Guid personId, Guid ejendomId);
    }
}
