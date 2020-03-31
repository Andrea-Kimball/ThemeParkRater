using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThemeParkRater.Data;
using ThemeParkRater.Models.RatingModels;
using ThemeParkRater.Models.RideModels;
using ThemeParkRater.Models.ThemeParkModels;
using ThemeParkRaterMVC.Data;

namespace ThemeParkRater.Services
{
    public class ParkService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _userId;
        public ParkService(string userId)
        {
            _context = new ApplicationDbContext();
            _userId = userId;

        }


        //CREATE
        public async Task<bool> CreateParkAsync(ParkCreate model)
        {
            ThemePark entity = new ThemePark
            {
                Name = model.Name,
                City = model.City,
                State = model.State

            };
            _context.Parks.Add(entity);
            var changeCount = await _context.SaveChangesAsync();
            return changeCount == 1;

        }


        //GET ALL
        public async Task<List<ParkListItem>> GetAllParksAsync()
        {
            //GET all parks from db
            var entityList = await _context.Parks.ToListAsync();

            //turn themeparks into parklistItems
            var parkList = entityList.Select(park => new ParkListItem
            {
                ParkId = park.ParkId,
                Name = park.Name,
                City = park.City,
                State = park.State,
                AverageRating = park.AverageRating,
                RideCount = park.Rides.Count
            }).ToList();
            //return changed list
            return parkList;
        }

        //GET BY ID
        public async Task<ParkDetail> GetParkByIdAsync(int parkId)
        {
            //Search Database by Id for Park
            var entity = await _context.Parks.FindAsync(parkId);
            if (entity == null)
                throw new Exception("No Park found.");
            //Turn the entity into the Detail

            var model = new ParkDetail
            {
                ParkId = entity.ParkId,
                Name = entity.Name,
                City = entity.City,
                State = entity.State,
                Rides = entity.Rides.Select(ride => new RideListItem
                {
                    RideId = ride.RideId,
                    MinRiderHeight = ride.MinRiderHeight,
                    Name = ride.Name,
                    Type = ride.Type,
                    AverageRating = ride.AverageRating
                }).ToList(),
                
            };
            foreach (var rating in entity.Ratings)
            {
                model.Ratings.Add(new ParkRatingListItem
                {
                    RatingId = rating.RatingId,
                    ParkId = rating.ParkId,
                    ParkName = rating.Park.Name,
                    Description = rating.Description,
                    IsUserOwned = rating.UserId == _userId,
                    Score = rating.Score,
                    VisitDate = rating.VisitDate
                });
            }

            //return the detail model
            return model;
        }
    }
}
