using BackEndApi.DTO;

namespace BackEndApi.BLL.Services.Interface
{
  public interface IEmpleadoService
  {
    Task<List<EmpleadoDTO>> List();
    Task<EmpleadoDTO> Create( EmpleadoDTO modelo );
    Task<bool> Update( EmpleadoDTO modelo );
    Task<bool> Remove( int id );
  }
}
