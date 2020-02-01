using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    class CategoryRepository : BaseRepository
    {

        public List<Category> SearchCategories()
        {
            return DbContext.Categories.ToList();
        }

        public Category GetCategory(Guid categoryId)
        {
            return DbContext.Categories.FirstOrDefault(a => a.Id == categoryId);
        }

        public void AddCategory(Category newCategory)
        {
            DbContext.Categories.Add(newCategory);
            DbContext.SaveChanges();
        }

        public void DeleteCategory(Guid categoryId)
        {
            var category = DbContext.Categories.FirstOrDefault(a => a.Id == categoryId);

            if (category != null)
            {
                DbContext.Categories.Remove(category);
                DbContext.SaveChanges();
            }
        }

        public void UpdateCategory(Category updatedCategory)
        {
            var existingCategory = DbContext.Categories.FirstOrDefault(a => a.Id == updatedCategory.Id);

            if (existingCategory != null)
            {
                existingCategory.Name = updatedCategory.Name;
                DbContext.SaveChanges();
            }
        }
    }
}
