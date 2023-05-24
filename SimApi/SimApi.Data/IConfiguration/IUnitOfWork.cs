using DataLayer.Models;
using DataLayer.Repository.IRepositories;
using SimApi.Data.Domain;
using SimApi.Data.Repository;

namespace DataLayer.IConfiguration;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<staff> staffRepository { get; }
    IGenericRepository<Product> ProductRepository { get; }

    IGenericRepository<Category> CategoryRepository { get; }
    public ICategoryRepository Category2Repository { get;  }


    void Complete();
}
