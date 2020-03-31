using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeParkRater.Models.RatingModels;
using ThemeParkRater.Models.RideModels;

namespace ThemeParkRater.Models.ThemeParkModels
{
    public class ParkDetail
    {
        public int ParkId { get; set; }
        public string Name { get; set; }        
        public string City { get; set; }        
        public string State { get; set; }
        public List<RideListItem> Rides { get; set; } = new List<RideListItem>();
        public List<ParkRatingListItem> Ratings { get; set; } = new List<ParkRatingListItem>();
    }
}
