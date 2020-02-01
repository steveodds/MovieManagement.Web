using MovieManagement.DataAccess;
using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Management
{
    public class ReviewManagement
    {
        private readonly ReviewRepository _reviewRepo = new ReviewRepository();

        public List<ReviewDTO> Search()
        {
            var result = _reviewRepo.SearchReviews();

            return result.Select(a => new ReviewDTO
            {
                Id = a.Id,
                Score = a.Score
            }).ToList();
        }

        public ReviewDTO GetReview(Guid reviewId)
        {
            var reviews = _reviewRepo.GetReview(reviewId);

            return new ReviewDTO
            {
                Id = reviews.Id,
                Score = reviews.Score
            };
        }

        public void DeleteReview(Guid reviewId)
        {
            _reviewRepo.DeleteReview(reviewId);
        }

        public void AddOrUpdate(ReviewDTO review)
        {
            if (review.Id == Guid.Empty)
            {
                var newReview = new Review
                {
                    Id = new Guid(),
                    Score = review.Score
                };

                _reviewRepo.AddReview(newReview);
            }
            else
            {
                var updatedReview = new Review
                {
                    Id = review.Id,
                    Score = review.Score
                };

                _reviewRepo.UpdateReview(updatedReview);
            }
        }
    }
}
