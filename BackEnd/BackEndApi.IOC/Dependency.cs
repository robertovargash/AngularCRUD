using BackEndApi.BLL.Services;
using BackEndApi.BLL.Services.Interface;
using BackEndApi.DAL;
using BackEndApi.DAL.Repository;
using BackEndApi.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BackEndApi.IOC
{
  public static class Dependency
  {
    public static void InyectarDependencias( this IServiceCollection services, IConfiguration configuration )
    {
      services.AddDbContext<DbempleadoContext>( options =>
      {
        options.UseSqlServer( configuration.GetConnectionString( "cadenaSQL" ) );
      } );
      services.AddTransient( typeof( IGenericRepository<> ), typeof( GenericRepository<> ) );
      //services.AddScoped<IVentaRepository, VentaRepository>();

      services.AddAutoMapper( typeof( AutoMapperProfile ) );

      services.AddScoped<IDepartamentoService, DepartamentoService>();
      services.AddScoped<IEmpleadoService, EmpleadoService>();
      //services.AddScoped<ICategoriaService, CategoriaService>();
      //services.AddScoped<IProductoService, ProductoService>();
      //services.AddScoped<IVentaService, VentaService>();
      //services.AddScoped<IDashBoardService, DashBoardService>();
      //services.AddScoped<IMenuService, MenuService>();
    }
  }

}