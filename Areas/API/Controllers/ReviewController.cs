using MovieManagement.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MovieManagement.Web.Areas.API.Controllers
{
    [RoutePrefix("api/reviews")]
    public class ReviewController : ApiController
    {
        private readonly Management.ReviewManagement _reviewManagement = new Management.ReviewManagement();

        [HttpGet]
        [Route("Search")]
        public List<ReviewDTO> Search()
        {
            return _reviewManagement.Search();
        }

        [HttpDelete]
        [Route("{reviewId}")]
        public void Delete(Guid reviewId)
        {
            _reviewManagement.DeleteReview(reviewId);
        }

        [HttpGet]
        [Route("{reviewId")]
        public ReviewDTO GetReview(Guid reviewId)
        {
            return _reviewManagement.GetReview(reviewId);
        }

        [HttpPut]
        [Route("reviewId")]
        public void UpdateReview([FromBody]ReviewDTO review, Guid reviewId)
        {
            _reviewManagement.AddOrUpdate(review);
        }

        [HttpPost]
        [Route("reviewId")]
        public void SaveReview([FromBody]ReviewDTO review, Guid reviewId)
        {
            _reviewManagement.AddOrUpdate(review);
        }
    }
}
