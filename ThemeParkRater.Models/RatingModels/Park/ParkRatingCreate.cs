using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThemeParkRater.Models.RatingModels.Park
{
    public class ParkRatingCreate
    {
        [ForeignKey("Park")]
        public int ParkId { get; set; }
        [Required]
        [Range(1, 10)]
        public int Score { get; set; }
        public string Description { get; set; }

        public DateTime VisitDate
        {
            get; set;

        }
    }
}
