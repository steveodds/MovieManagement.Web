using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategorieController : ApiController
    {
        private readonly Management.CategoryManagement _categoryManagement = new Management.CategoryManagement();

        [HttpGet]
        [Route("Search")]
        public List<CategoryDTO> Search()
        {
            return _categoryManagement.Search();
        }

        [HttpDelete]
        [Route("{categoryId}")]
        public void Delete(Guid categoryId)
        {
            _categoryManagement.DeleteCategory(categoryId);
        }

        [HttpGet]
        [Route("{categoryId}")]
        public CategoryDTO GetCategory(Guid categoryId)
        {
            return _categoryManagement.GetCategory(categoryId);
        }

        [HttpPut]
        [Route("{categoryId}")]
        public void UpdateCategory([FromBody]CategoryDTO category, Guid categoryId)
        {
            _categoryManagement.AddOrUpdate(category);
        }

        [HttpPost]
        [Route("{categoryId}")]
        public void SaveCategory([FromBody]CategoryDTO category, Guid categoryId)
        {
            _categoryManagement.AddOrUpdate(category);
        }
    }
}
