using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkRater.Data
{
    public class Ride
    {
        [Key]
        public int RideId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public int? MinRiderHeight { get; set; }

        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public virtual ThemePark Park { get; set; }
        public virtual ICollection<RideRating> Ratings { get; set; }
        public double AverageRating
        {
            get
            {
                if (Ratings != null && Ratings.Count != 0)
                    return (double)Ratings.Sum(rating => rating.Score) / Ratings.Count;

                return 0;
            }
        }


    }
}
