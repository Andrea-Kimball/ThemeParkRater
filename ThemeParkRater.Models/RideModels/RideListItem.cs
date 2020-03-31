using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkRater.Models.RideModels
{
    public class RideListItem
    {
        public int RideId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public double AverageRating { get; set; }
        public bool HasHeightRequirement
        {
            get
            {
                return MinRiderHeight.HasValue;
            }
        }

        

        [Display(Name = "Minimum Required Height")]
        public int? MinRiderHeight { get; set; }
    }
}
