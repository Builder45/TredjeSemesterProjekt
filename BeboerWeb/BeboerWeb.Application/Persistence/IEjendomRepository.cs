using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.Persistence
{
    public interface IEjendomRepository

    {
        void CreateEjendom(Ejendom ejendom);
        Ejendom GetEjendom(Guid id);
        List<Ejendom> GetEjendomme();
        List<Ejendom> GetEjendommeWithLokaler();
        List<Ejendom> GetEjendommeByPerson(Guid personId);
        void UpdateEjendom(Ejendom ejendom);

    }
}
