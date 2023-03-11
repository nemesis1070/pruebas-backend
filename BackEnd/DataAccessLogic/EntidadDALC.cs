using AutoMapper;
using BackEnd.DTO;
using BackEnd.ModeloDb;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.DataAccessLogic
{
    public class EntidadDALC
    {
        private readonly PruebaTecnicaContext _context;
        private readonly IMapper _mapper;

        public EntidadDALC(PruebaTecnicaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EntidadDTO>> GetAll()
        {
            var query = await _context.Entidades.ToListAsync();
            var datosMapeados = _mapper.Map<List<EntidadDTO>>(query);

            return datosMapeados;
        }

        public async Task<EntidadDTO> Get(int idEntidad)
        {
            var query = await _context.Entidades.Where(ent => ent.IdEntidad == idEntidad).FirstOrDefaultAsync();
            var datosMapeados = _mapper.Map<EntidadDTO>(query);

            return datosMapeados;
        }


        public async Task<bool> Create(EntidadDTO modelo)
        {

            _context.Entidades.Add(_mapper.Map<Entidad>(modelo));
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


        public async Task<bool> Update(EntidadDTO modelo)
        {

            var query = await _context.Entidades.Where(emp => emp.IdEntidad == modelo.IdEntidad).FirstOrDefaultAsync();

            if (query != null)
            {
                query.Nombre = modelo.Nombre;
                query.Direccion = modelo.Direccion;

                _context.Entidades.Update(query);
                await _context.SaveChangesAsync();
            }

            return true;
        }


        public async Task<bool> Delete(int idEntidad)
        {
            var query = await _context.Entidades.Where(emp => emp.IdEntidad == idEntidad).FirstOrDefaultAsync();

            if (query != null)
            {
                _context.Entidades.Remove(query);
                await _context.SaveChangesAsync();
            }

            return true;

        }

    }
}
