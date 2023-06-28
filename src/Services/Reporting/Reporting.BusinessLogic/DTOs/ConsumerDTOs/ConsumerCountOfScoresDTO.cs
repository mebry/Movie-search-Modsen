using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting.BusinessLogic.DTOs.ConsumerDTOs
{
    internal class ConsumerCountOfScoresDTO
    {
        public Guid FilmId { get; set; }
        public int CountOfScores { get; set; }
    }
}
