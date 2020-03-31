using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkRater.Models.ThemeParkModels
{
    public class ParkListItem
    {
        public int ParkId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name= "Average Rating")]
        public double AverageRating { get; set; }

        [Display(Name = "Ride Count")]
        public int RideCount { get; set; }
    }
}
