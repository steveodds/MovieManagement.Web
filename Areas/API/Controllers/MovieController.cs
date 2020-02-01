using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/movies")]
    public class MovieController : ApiController
    {
        private readonly Management.MovieManagement _movieManagement = new Management.MovieManagement();

        [HttpGet]
        [Route("Search")]
        public List<MovieDTO> Search()
        {
            return _movieManagement.Search();
        }

        [HttpDelete]
        [Route("{movieId}")]
        public void Delete(Guid movieId)
        {
            _movieManagement.DeleteMovie(movieId);
        }

        [HttpGet]
        [Route("{movieId}")]
        public MovieDTO GetMovie(Guid movieId)
        {
            return _movieManagement.GetMovie(movieId);
        }

        [HttpPut]
        [Route("{movieId}")]
        public void UpdateMovie([FromBody]MovieDTO movie, Guid movieId)
        {
            _movieManagement.AddOrUpdate(movie);
        }

        [HttpPost]
        [Route("{movieId}")]
        public void SaveMovie([FromBody]MovieDTO movie, Guid movieId)
        {
            _movieManagement.AddOrUpdate(movie);
        }
    }
}
