using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    class CategoryRepository
    {

        public List<Category> SearchCategories()
        {
            using (var dbContext = new MoviesDBEntities())
            {
                return dbContext.Categories.ToList();
            }
        }
    }
}
