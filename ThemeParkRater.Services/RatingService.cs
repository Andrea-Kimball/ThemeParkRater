using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeParkRater.Data;
using ThemeParkRater.Models.RatingModels.Park;
using ThemeParkRaterMVC.Data;

namespace ThemeParkRater.Services
{
    public class RatingService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userId;
        public RatingService(string userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;

        }
        //Rate a Park
        public async Task<bool>CreateParkRatingAsync(ParkRatingCreate model)
        {
            var entity = new ParkRating
            {
                Description = model.Description,
                ParkId = model.ParkId,
                Score = model.Score,
                VisitDate = model.VisitDate,
                UserId = _userId,
            };
            _context.Ratings.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;
        }

        //Rate a Ride
    }
}
