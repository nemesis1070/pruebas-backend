using AutoMapper;
using BackEnd.DTO;
using BackEnd.ModeloDb;

namespace BackEnd
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entidad, EntidadDTO>().ReverseMap();

            CreateMap<EmpleadoDTO, Empleado>()
                .ForMember(d => d.IdEmpleado, opc => opc.Ignore());

            CreateMap<Empleado, EmpleadoDTO>()
                .ForMember(d => d.NombreEntidad, opc => opc.MapFrom(o => o.IdEntidadNavigation.Nombre));
        }
    }
}
