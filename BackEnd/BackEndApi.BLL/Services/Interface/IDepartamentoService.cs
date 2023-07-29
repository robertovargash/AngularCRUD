using BackEndApi.DTO;

namespace BackEndApi.BLL.Services.Interface
{
  public interface IDepartamentoService
  {
    Task<List<DepartamentoDTO>> List();
    Task<DepartamentoDTO> Create( DepartamentoDTO modelo );
    Task<bool> Update( DepartamentoDTO modelo );
    Task<bool> Remove( int id );
  }
}
