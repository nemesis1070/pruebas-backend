using BackEnd.DTO;

namespace BackEnd.BusinessLogic.Interfaces
{
    public interface IEmpleadoBL
    {
        Task<List<EmpleadoDTO>> GetAll();
        Task<EmpleadoDTO> Get(int idEmpleado);
        Task<bool> Create(EmpleadoDTO modelo);
        Task<bool> Update(EmpleadoDTO modelo);
        Task<bool> Delete(int idEmpleado);
    }
}
