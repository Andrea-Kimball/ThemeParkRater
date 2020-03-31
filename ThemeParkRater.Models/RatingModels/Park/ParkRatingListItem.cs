using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkRater.Models.RatingModels
{
    public class ParkRatingListItem: RatingListItem
    {
        public int ParkId { get; set; }
        public string ParkName { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
