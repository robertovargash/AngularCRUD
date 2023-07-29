using AutoMapper;
using BackEndApi.DTO;
using BackEndApi.Model;

namespace BackEndApi.Utility
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {

      CreateMap<Departamento, DepartamentoDTO>().ReverseMap();

      CreateMap<Empleado, EmpleadoDTO>()
        .ForMember( destino =>
        destino.DescripcionDepartamento,
        option => option.MapFrom( origen => origen.IdDepartamentoNavigation.Nombre ) );

      CreateMap<EmpleadoDTO, Empleado>()
       .ForMember( destino =>
        destino.IdDepartamentoNavigation,
        option => option.Ignore() );
    }
  }
}