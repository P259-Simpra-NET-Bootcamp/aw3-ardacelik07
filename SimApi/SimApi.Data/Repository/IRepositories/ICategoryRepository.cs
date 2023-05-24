using DataLayer.Models;
using SimApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.IRepositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        List<Category> GetAllWithInclude();
       Category GetByIdWithInclude(int id);
    }
}
