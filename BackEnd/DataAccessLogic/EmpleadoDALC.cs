using AutoMapper;
using BackEnd.DTO;
using BackEnd.ModeloDb;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DataAccessLogic
{
    public class EmpleadoDALC
    {
        private readonly PruebaTecnicaContext _context;
        private readonly IMapper _mapper;

        public EmpleadoDALC(PruebaTecnicaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EmpleadoDTO>> GetAll()
        {
            var query = await _context.Empleados.Include(emp => emp.IdEntidadNavigation).ToListAsync();
            var datosMapeados = _mapper.Map<List<EmpleadoDTO>>(query);

            return datosMapeados;
        }

        public async Task<EmpleadoDTO> Get(int idEmpleado)
        {

            var query = await _context.Empleados.Where(emp => emp.IdEmpleado == idEmpleado).Include(emp => emp.IdEntidadNavigation).FirstOrDefaultAsync();

            var datosMapeados = _mapper.Map<EmpleadoDTO>(query);

            return datosMapeados;

        }


        public async Task<bool> Create(EmpleadoDTO modelo)
        {

            _context.Empleados.Add(_mapper.Map<Empleado>(modelo));
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;

            }

        }


        public async Task<bool> Update(EmpleadoDTO modelo)
        {

            var query = await _context.Empleados.Where(emp => emp.IdEmpleado == modelo.IdEmpleado).FirstOrDefaultAsync();

            if (query != null)
            {
                query.Nombres = modelo.Nombres;
                query.Apellidos = modelo.Apellidos;
                query.Cargo = modelo.Cargo;
                query.Edad = modelo.Edad;
                query.IdEntidad = modelo.IdEntidad;

                _context.Empleados.Update(query);
                await _context.SaveChangesAsync();
            }

            return true;
        }


        public async Task<bool> Delete(int idEmpleado)
        {

            var query = await _context.Empleados.Where(emp => emp.IdEmpleado == idEmpleado).FirstOrDefaultAsync();

            if (query != null)
            {
                _context.Empleados.Remove(query);
                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
