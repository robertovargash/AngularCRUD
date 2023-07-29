using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BackEndApi.DAL.Repository
{
  public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
  {
    private readonly DbempleadoContext _dbContext;

    public GenericRepository( DbempleadoContext dbContext )
    {
      _dbContext = dbContext;
    }

    public async Task<TModelo> Get( Expression<Func<TModelo, bool>> filtro )
    {
      try
      {
        TModelo modelo = await _dbContext.Set<TModelo>().FirstOrDefaultAsync( filtro );
        return modelo;
      }
      catch( Exception )
      {

        throw;
      }
    }

    public async Task<TModelo> Create( TModelo modelo )
    {
      try
      {
        _dbContext.Set<TModelo>().Add( modelo );
        await _dbContext.SaveChangesAsync();
        return modelo;
      }
      catch( Exception )
      {

        throw;
      }
    }

    public async Task<bool> Update( TModelo modelo )
    {
      try
      {
        _dbContext.Set<TModelo>().Update( modelo );
        await _dbContext.SaveChangesAsync();
        return true;
      }
      catch( Exception )
      {

        throw;
      }
    }

    public async Task<bool> Remove( TModelo modelo )
    {
      try
      {
        _dbContext.Set<TModelo>().Remove( modelo );
        await _dbContext.SaveChangesAsync();
        return true;
      }
      catch( Exception )
      {

        throw;
      }
    }


    public async Task<IQueryable<TModelo>> FindSomethingBy( Expression<Func<TModelo, bool>> filtro = null )
    {
      try
      {
        IQueryable<TModelo> queryModelo = filtro == null ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where( filtro );
        return queryModelo;
      }
      catch( Exception )
      {

        throw;
      }
    }
  }
}
