using AssessmentPaper.WebApi.Persistence.Core;

namespace AssessmentPaper.WebApi.Persistence.Repositories;

public class Repository<TEntity> where TEntity : class , IRepository<TEntity>
{
    protected readonly DbClient Context;

    public Repository(DbClient context)
    {
        Context = context;
    }
    public void Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> Find(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public TEntity Get(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Remove(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public TEntity SingleOrDefault(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}