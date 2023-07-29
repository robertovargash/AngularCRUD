using BackEndApi.BLL.Services;
using BackEndApi.BLL.Services.Interface;
using BackEndApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
  [Route( "api/[controller]" )]
  [ApiController]
  public class EmpleadoController : ControllerBase
  {
    private readonly IEmpleadoService empleadoService;

    public EmpleadoController( IEmpleadoService empleadoService )
    {
      this.empleadoService = empleadoService;
    }


    [HttpGet( "Lista" )]
    public async Task<IActionResult> Lista()
    {
      var response = new Response<List<EmpleadoDTO>>();
      try
      {
        response.Status = true;
        response.Value = await empleadoService.List();
      }
      catch( Exception ex )
      {
        response.Status = false;
        response.Msg = ex.Message;
      }
      return Ok( response );
    }

    [HttpPost( "Crear" )]
    public async Task<IActionResult> Guardar( [FromBody] EmpleadoDTO empleado )
    {
      var response = new Response<EmpleadoDTO>();
      try
      {
        response.Status = true;
        response.Value = await empleadoService.Create( empleado );
      }
      catch( Exception ex )
      {
        response.Status = false;
        response.Msg = ex.Message;
      }
      return Ok( response );
    }

    [HttpPut( "Editar" )]
    public async Task<IActionResult> Editar( [FromBody] EmpleadoDTO empleado )
    {
      var response = new Response<bool>();
      try
      {
        response.Status = true;
        response.Value = await empleadoService.Update( empleado );
      }
      catch( Exception ex )
      {
        response.Status = false;
        response.Msg = ex.Message;
      }
      return Ok( response );
    }

    [HttpDelete( "Eliminar/{id:int}" )]
    public async Task<IActionResult> Eliminar( int id )
    {
      var response = new Response<bool>();
      try
      {
        response.Status = true;
        response.Value = await empleadoService.Remove( id );
      }
      catch( Exception ex )
      {
        response.Status = false;
        response.Msg = ex.Message;
      }
      return Ok( response );
    }
  }
}
