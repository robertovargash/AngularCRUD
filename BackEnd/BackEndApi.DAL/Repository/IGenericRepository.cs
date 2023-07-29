using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEndApi.DAL.Repository
{
  public interface IGenericRepository<TModel> where TModel : class
  {
    Task<TModel> Get( Expression<Func<TModel, bool>> filtro );

    Task<TModel> Create( TModel modelo );

    Task<bool> Update( TModel modelo );

    Task<bool> Remove( TModel modelo );

    Task<IQueryable<TModel>> FindSomethingBy( Expression<Func<TModel, bool>> filtro = null );
  }
}
