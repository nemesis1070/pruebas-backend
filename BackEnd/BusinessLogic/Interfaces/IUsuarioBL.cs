using BackEnd.DTO;

namespace BackEnd.BusinessLogic.Interfaces
{
    public interface IUsuarioBL
    {
        Task<CredencialesDTO> InicioSesion(LoginDTO modelo);
    }
}
