using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkRater.Models.RatingModels
{
    public class RatingListItem
    {
        public int RatingId { get; set; }        
        public int Score { get; set; }
        public string RateName { get; set; }
        public bool IsUserOwned { get; set; }

        public string Description { get; set; }
    }
}
