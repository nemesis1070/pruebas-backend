using AutoMapper;
using BackEnd.BusinessLogic.Interfaces;
using BackEnd.DataAccessLogic;
using BackEnd.DTO;
using BackEnd.ModeloDb;

namespace BackEnd.BusinessLogic.Servicios
{
    public class EntidadService : IEntidadBL
    {

        private readonly IMapper _mapper;
        private readonly PruebaTecnicaContext _context;

        public EntidadService(IMapper mapper, PruebaTecnicaContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Create(EntidadDTO modelo)
        {
            var RespuestaDB = await new EntidadDALC(_context, _mapper).Create(modelo);
            return RespuestaDB;
        }

        public async Task<bool> Delete(int idEntidad)
        {
            var RespuestaDB = await new EntidadDALC(_context, _mapper).Delete(idEntidad);
            return RespuestaDB;
        }

        public async Task<EntidadDTO> Get(int idEntidad)
        {
            var RespuestaDB = await new EntidadDALC(_context, _mapper).Get(idEntidad);
            return RespuestaDB;
        }

        public async Task<List<EntidadDTO>> GetAll()
        {
            var RespuestaDB = await new EntidadDALC(_context, _mapper).GetAll();
            return RespuestaDB;
        }

        public async Task<bool> Update(EntidadDTO modelo)
        {
            var RespuestaDB = await new EntidadDALC(_context, _mapper).Update(modelo);
            return RespuestaDB;

        }
    }
}
