using BackEnd.DTO;

namespace BackEnd.BusinessLogic.Interfaces
{
    public interface IEntidadBL
    {
        Task<List<EntidadDTO>> GetAll();
        Task<EntidadDTO> Get(int idEntidad);
        Task<bool> Create(EntidadDTO modelo);
        Task<bool> Update(EntidadDTO modelo);
        Task<bool> Delete(int idEntidad);
    }
}
