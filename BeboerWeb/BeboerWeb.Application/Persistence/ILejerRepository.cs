using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface ILejerRepository
    {
        Lejer GetLejer(Guid id);
        List<Lejer> GetLejere();
        List<Lejer> GetLejereByLejemaal(Guid lejemaalId);
        List<Lejer> GetLejereByEjendom(Guid ejendomId);
        Guid CreateLejer(Lejer lejer);
        void UpdateLejer(Lejer lejer);

        void LinkLejerWithPerson(Guid lejerId, Guid personId);
        void UnlinkLejerWithPersoner(Guid lejerId);
    }
}
