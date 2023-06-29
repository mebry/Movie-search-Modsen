using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.BusinessLogic.DTOs.ConsumerDTOs
{
    internal class ConsumerAverageRatingDTO
    {
        public Guid FilmId { get; set; }
        public double AverageRating { get; set; }
    }
}
