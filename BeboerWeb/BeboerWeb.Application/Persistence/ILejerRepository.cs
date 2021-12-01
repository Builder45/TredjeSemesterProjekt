using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface ILejerRepository
    {
        Lejer GetLejer(Guid id);
        List<Lejer> GetLejere();
        List<Lejer> GetLejereByLejemaal(Guid lejemaalId);
        void CreateLejer(Lejer lejer);
        void UpdateLejer(Lejer lejer);
    }
}
