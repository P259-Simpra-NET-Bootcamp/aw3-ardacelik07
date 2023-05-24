using DataLayer.Models;
using DataLayer.Repository.IRepositories;
using Microsoft.EntityFrameworkCore;
using SimApi.Data.Context;
using SimApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SimDbContext dbContext) : base(dbContext)
        {
        }

        public List<Category> GetAllWithInclude()
        {
            var list = dbContext.Set<Category>()
                .Include(x => x.products).ToList();
            return list;
        }

        public Category GetByIdWithInclude(int id)
        {
            var list = dbContext.Set<Category>().Where(x => x.Id == id)
             .Include(x => x.products).FirstOrDefault();

            return list;
        }
    }
}
