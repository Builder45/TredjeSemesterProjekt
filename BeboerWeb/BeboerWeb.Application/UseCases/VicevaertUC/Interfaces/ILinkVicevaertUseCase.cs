using BeboerWeb.Application.Requests.Vicevaert;

namespace BeboerWeb.Application.UseCases.VicevaertUC.Interfaces
{
    public interface ILinkVicevaertUseCase
    {
        public void LinkVicevaert(LinkVicevaertRequest command); 
        public void UnlinkVicevaert(LinkVicevaertRequest command);
    }
}