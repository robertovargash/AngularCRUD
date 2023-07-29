using BackEndApi.BLL.Services.Interface;
using BackEndApi.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEndApi.Controllers
{
  [Route( "api/[controller]" )]
  [ApiController]
  public class DepartamentoController : ControllerBase
  {
    private readonly IDepartamentoService departamentoService;

    public DepartamentoController( IDepartamentoService departamentoService )
    {
      this.departamentoService = departamentoService;
    }

    [HttpGet( "Lista" )]
    public async Task<IActionResult> Lista()
    {
      var response = new Response<List<DepartamentoDTO>>();
      try
      {
        response.Status = true;
        response.Value = await departamentoService.List();
      }
      catch( Exception ex )
      {
        response.Status = false;
        response.Msg = ex.Message;
      }
      return Ok( response );
    }

    [HttpPost( "Crear" )]
    public async Task<IActionResult> Guardar( [FromBody] DepartamentoDTO departamento )
    {
      var response = new Response<DepartamentoDTO>();
      try
      {
        response.Status = true;
        response.Value = await departamentoService.Create( departamento );
      }
      catch( Exception ex )
      {
        response.Status = false;
        response.Msg = ex.Message;
      }
      return Ok( response );
    }

    [HttpPut( "Editar" )]
    public async Task<IActionResult> Editar( [FromBody] DepartamentoDTO departamento )
    {
      var response = new Response<bool>();
      try
      {
        response.Status = true;
        response.Value = await departamentoService.Update( departamento );
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
        response.Value = await departamentoService.Remove( id );
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
