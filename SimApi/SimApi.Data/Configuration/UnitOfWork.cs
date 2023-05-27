using DataLayer.IConfiguration;
using DataLayer.Models;
using DataLayer.Repository.IRepositories;
using DataLayer.Repository.Repositories;
using SimApi.Data.Context;

using SimApi.Data.Repository;

namespace DataLayer.Configuration;

public class UnitOfWork : IUnitOfWork
{
 
    public IGenericRepository<Category> CategoryRepository { get; private set; }

    public IGenericRepository<Product> ProductRepository { get; private set; }

    public ICategoryRepository Category2Repository { get; private set; }


    private readonly SimDbContext dbContext;

    public UnitOfWork(SimDbContext dbContext)
    {
        this.dbContext = dbContext;


      
        CategoryRepository = new GenericRepository<Category>(dbContext);
        ProductRepository = new GenericRepository<Product>(dbContext);
        Category2Repository= new CategoryRepository(dbContext);

    }
    public void Complete()

    {

        dbContext.SaveChanges();
    }

    public void CompleteWithTransaction()
    {
        using (var dbDcontextTransaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                dbDcontextTransaction.Commit();

            }
            catch (Exception ex)
            {
                dbDcontextTransaction.Rollback();
                throw;
            }
        }
    }


    private void Clean(bool disposing)
    {
        if (!disposing)
        {
            dbContext.Dispose();
        }

        disposing = true;
        GC.SuppressFinalize(this);
    }

    public void Dispose()
    {
        Clean(true);
    }
}
