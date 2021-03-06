using BeboerWeb.Application.Requests.Ejendom;
using BeboerWeb.Domain.Models;

namespace BeboerWeb.Application.UseCases.EjendomUC.Interfaces
{
    public interface IGetEjendomUseCase
    {
        Ejendom GetEjendom(GetEjendomRequest command);
        List<Ejendom> GetEjendomme();
        List<Ejendom> GetEjendommeWithLokaler();
    }
}
