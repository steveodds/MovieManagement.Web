using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataContracts
{
    public class ReviewDTO
    {
        public Guid Id { get; set; }
        public int Score { get; set; }
    }
}
