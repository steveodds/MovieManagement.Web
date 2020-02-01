using MovieManagement.DataAccess;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Management
{
    public class CategoryManagement
    {
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public List<CategoryDTO> Search()
        {
            var result = _categoryRepo.SearchCategories();
            var resultToDTO = result.Select(a => new CategoryDTO
            {
                Id = a.Id,
                Name = a.Name
            }).ToList();

            return resultToDTO;
        }

        public CategoryDTO GetCategory(Guid categoryId)
        {
            var result = _categoryRepo.GetCategory(categoryId);
            return new CategoryDTO
            {
                Id = result.Id,
                Name = result.Name
            };
        }

        public void DeleteCategory(Guid categoryId)
        {
            _categoryRepo.DeleteCategory(categoryId);
        }

        public void AddOrUpdate(CategoryDTO category)
        {
            if (category.Id == Guid.Empty)
            {
                var newCategory = new Category
                {
                    Id = new Guid(),
                    Name = category.Name
                };

                _categoryRepo.AddCategory(newCategory);
            }
            else
            {
                var updatedCategory = new Category
                {
                    Id = category.Id,
                    Name = category.Name
                };

                _categoryRepo.UpdateCategory(updatedCategory);
            }
        }
    }
}
