using System.Collections.Generic;

namespace TodoApplication.Repository
{
    public interface ITodoRepository<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(U id);
        TEntity Add(TEntity b);
        TEntity Update(U id, TEntity b);
        long Delete(U id);
    }

}
