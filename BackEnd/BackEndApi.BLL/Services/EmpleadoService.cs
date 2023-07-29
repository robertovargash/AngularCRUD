using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BackEndApi.BLL.Services.Interface;
using BackEndApi.DAL.Repository;
using BackEndApi.DTO;
using BackEndApi.Model;

namespace BackEndApi.BLL.Services
{
  public class EmpleadoService : IEmpleadoService
  {

    private readonly IGenericRepository<Empleado> empleadoRepositorio;
    private readonly IMapper mapper;

    public EmpleadoService( IGenericRepository<Empleado> empleadoRepositorio, IMapper mapper )
    {
      this.empleadoRepositorio = empleadoRepositorio;
      this.mapper = mapper;
    }


    public async Task<EmpleadoDTO> Create( EmpleadoDTO modelo )
    {
      try
      {
        var empleadoCreado = await empleadoRepositorio.Create( mapper.Map<Empleado>( modelo ) );
        if( empleadoCreado.IdEmpleado == 0 )
        {
          throw new TaskCanceledException( "No se pudo crear el empleado" );
        }
        return mapper.Map<EmpleadoDTO>( empleadoCreado );
      }
      catch( Exception )
      {
        throw;
      }
    }

    public async Task<List<EmpleadoDTO>> List()
    {
      try
      {
        var queryempleado = await empleadoRepositorio.FindSomethingBy();
        var listaEmpleados = queryempleado.Include( cat => cat.IdDepartamentoNavigation ).ToList();
        return mapper.Map<List<EmpleadoDTO>>( listaEmpleados.ToList() );
      }
      catch( Exception )
      {
        throw;
      }
    }

    public async Task<bool> Remove( int id )
    {
      try
      {
        var empleadoEncontrado = await empleadoRepositorio.Get( p => p.IdEmpleado == id );
        if( empleadoEncontrado == null )
        {
          throw new TaskCanceledException( "No existe el empleado" );
        }
        bool respuesta = await empleadoRepositorio.Remove( empleadoEncontrado );
        if( !respuesta )
        {
          throw new TaskCanceledException( "No se pudo eliminar" );
        }
        return respuesta;
      }
      catch( Exception )
      {
        throw;
      }
    }

    public async Task<bool> Update( EmpleadoDTO modelo )
    {
      try
      {
        var empleadoModel = mapper.Map<Empleado>( modelo );
        var empleadoEncontrado = await empleadoRepositorio.Get( p => p.IdEmpleado == empleadoModel.IdEmpleado ) ?? throw new TaskCanceledException( "No existe el empleado" );

        empleadoEncontrado.NombreCompleto = empleadoModel.NombreCompleto;
        empleadoEncontrado.FechaContrato = empleadoModel.FechaContrato;
        empleadoEncontrado.Sueldo = empleadoModel.Sueldo;
        empleadoEncontrado.IdDepartamento = empleadoModel.IdDepartamento;

        bool respuesta = await empleadoRepositorio.Update( empleadoEncontrado );
        if( !respuesta )
        {
          throw new TaskCanceledException( "No se pudo editar" );
        }
        return respuesta;
      }
      catch( Exception )
      {
        throw;
      }
    }
  }
}
