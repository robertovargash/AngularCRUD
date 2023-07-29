using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BackEndApi.BLL.Services.Interface;
using BackEndApi.DAL.Repository;
using BackEndApi.DTO;
using BackEndApi.Model;

namespace BackEndApi.BLL.Services
{
  public class DepartamentoService : IDepartamentoService
  {
    private readonly IGenericRepository<Departamento> departamentoRepository;
    private readonly IMapper mapper;

    public DepartamentoService( IGenericRepository<Departamento> departamentoRepository, IMapper mapper )
    {
      this.departamentoRepository = departamentoRepository;
      this.mapper = mapper;
    }

    public async Task<DepartamentoDTO> Create( DepartamentoDTO modelo )
    {
      try
      {
        var empleadoCreado = await departamentoRepository.Create( mapper.Map<Departamento>( modelo ) );
        if( empleadoCreado.IdDepartamento == 0 )
        {
          throw new TaskCanceledException( "No se pudo crear el departamento" );
        }
        return mapper.Map<DepartamentoDTO>( empleadoCreado );
      }
      catch( Exception )
      {
        throw;
      }
    }

    public async Task<List<DepartamentoDTO>> List()
    {
      try
      {
        var queryDepartamento = await departamentoRepository.FindSomethingBy();
        return mapper.Map<List<DepartamentoDTO>>( queryDepartamento.ToList() );
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
        var departamentoEncontrado = await departamentoRepository.Get( p => p.IdDepartamento == id );
        if( departamentoEncontrado == null )
        {
          throw new TaskCanceledException( "No existe el departamento" );
        }
        bool respuesta = await departamentoRepository.Remove( departamentoEncontrado );
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

    public async Task<bool> Update( DepartamentoDTO modelo )
    {
      try
      {
        var departamentoModel = mapper.Map<Departamento>( modelo );
        var departamentoEncontrado = await departamentoRepository.Get( p => p.IdDepartamento == departamentoModel.IdDepartamento ) ?? throw new TaskCanceledException( "No existe el departamento" );

        departamentoEncontrado.Nombre = departamentoModel.Nombre;

        bool respuesta = await departamentoRepository.Update( departamentoEncontrado );
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
