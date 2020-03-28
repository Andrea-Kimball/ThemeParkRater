using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeParkRaterMVC.Data;

namespace ThemeParkRater.Data
{
    //abstract classes cannot be instantiated
    public abstract class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [Required]
        [Range(1,10)]
        public int Score { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User{ get; set; }
        public string Description { get; set; }
    }

    public class ParkRating: Rating
    {
        [ForeignKey("Park")]
        public int ParkId { get; set; }
        public virtual ThemePark Park { get; set; }
        public DateTime VisitDate { get; set; }

    }

    public class RideRating: Rating
    {
        [ForeignKey("Ride")]
        public int RideId { get; set; }
        public virtual Ride Ride { get; set; }

    }
}
