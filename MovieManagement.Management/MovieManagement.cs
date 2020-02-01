using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieManagement.DataAccess;
using MovieManagement.DataContracts;

namespace MovieManagement.Management
{
    public class MovieManagement
    {
        private MovieRepository _movieRepo = new MovieRepository();
        public List<MovieDTO> Search()
        {
            var result = _movieRepo.SearchMovies();

            var toReturn = result.Select(a => new MovieDTO
            {
                Id = a.Id,
                AverageScore = (float)a.AverageScore,
                CategoryName = a.Category.Name,
                Length = a.Length,
                Rating = a.Rating,
                ReleaseDate = a.ReleaseDate,
                Title = a.Title
            }).ToList();

            return toReturn;
        }

        public MovieDTO GetMovie(Guid movieId)
        {
            var result = _movieRepo.GetMovies(movieId);

            return new MovieDTO
            {
                Id = result.Id,
                AverageScore = (float)result.AverageScore,
                CategoryName = result.Category.Name,
                Length = result.Length,
                Rating = result.Rating,
                ReleaseDate = result.ReleaseDate,
                Title = result.Title
            };
        }

        public void DeleteMovie(Guid movieId)
        {
            _movieRepo.DeleteMovie(movieId);
        }

        public void AddOrUpdate(MovieDTO movie)
        {
            var movy = new Movy()
            {
                Id = movie.Id != Guid.Empty ? movie.Id : Guid.NewGuid(),
                Rating = movie.Rating,
                AverageScore = movie.AverageScore,
                Length = movie.Length,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title,
            };

            if (!string.IsNullOrEmpty(movie.CategoryName))
            {
                var categoryRepo = new CategoryRepository();
                var existingCategory = categoryRepo.GetCategory(movie.CategoryName);
                if (existingCategory != null)
                {
                    movy.CategoryId = existingCategory.Id;
                }
            }

            if (movie.Id != Guid.Empty)
            {
                //updates movie
                _movieRepo.UpdateMovie(movy);
            }
            else
            {
                //adds new movie
                _movieRepo.AddMovie(movy);
            }
        }
    }
}
