using SimApi.Data.Context;
using SimApi.Data.Repository;
using System.Linq.Expressions;

namespace DataLayer.Repository.Repositories;

public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
{
    protected readonly SimDbContext dbContext;

    public GenericRepository(SimDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    public void Delete(Entity entity)
    {
        dbContext.Set<Entity>().Remove(entity);
    }

    public void DeleteById(int id)
    {
        var entity = dbContext.Set<Entity>().Find(id);
        dbContext.Set<Entity>().Remove(entity);
    }

    public List<Entity> GetAll()
    {
        return dbContext.Set<Entity>().ToList();
    }

    public Entity GetById(int id)
    {
        return dbContext.Set<Entity>().Find(id);
    }

    public void Insert(Entity entity)
    {
        dbContext.Set<Entity>().Add(entity);
    }

    public void Update(Entity entity)
    {
        dbContext.Set<Entity>().Update(entity);
    }


    public IQueryable<Entity> GetWithFilter(Expression<Func<Entity, bool>> filter)
    {
        var query = dbContext.Set<Entity>().AsQueryable();
        query = query.Where(filter);
        return query;
    }
}
