using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkRater.Data
{
    public class ThemePark
    {
        [Key]
        public int ParkId{ get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        //populates the rides associated with the park
        public virtual ICollection<Ride> Rides { get; set; }
        public virtual ICollection<ParkRating> Ratings { get; set; }

    }
}
