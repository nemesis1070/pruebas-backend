using AutoMapper;
using BackEnd.BusinessLogic.Interfaces;
using BackEnd.DataAccessLogic;
using BackEnd.DTO;
using BackEnd.ModeloDb;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.BusinessLogic.Servicios
{
    public class EmpleadoService : IEmpleadoBL
    {
        private readonly IMapper _mapper;
        private readonly PruebaTecnicaContext _context;
        public EmpleadoService(IMapper mapper, PruebaTecnicaContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> Create(EmpleadoDTO modelo)
        {
            var RespuestaDB = await new EmpleadoDALC(_context, _mapper).Create(modelo);
            return RespuestaDB;
        }

        public async Task<bool> Delete(int idEmpleado)
        {
            var RespuestaDB = await new EmpleadoDALC(_context, _mapper).Delete(idEmpleado);
            return RespuestaDB;

        }

        public async Task<EmpleadoDTO> Get(int idEmpleado)
        {
            var RespuestaDB = await new EmpleadoDALC(_context, _mapper).Get(idEmpleado);
            return RespuestaDB;
        }

        public async Task<List<EmpleadoDTO>> GetAll()
        {
            var RespuestaDB = await new EmpleadoDALC(_context, _mapper).GetAll();
            return RespuestaDB;
        }

        public async Task<bool> Update(EmpleadoDTO modelo)
        {
            var RespuestaDB = await new EmpleadoDALC(_context, _mapper).Update(modelo);
            return RespuestaDB;
        }
    }
}
