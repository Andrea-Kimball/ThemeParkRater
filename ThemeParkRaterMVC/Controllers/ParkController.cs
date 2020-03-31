using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThemeParkRater.Models.RatingModels.Park;
using ThemeParkRater.Models.ThemeParkModels;
using ThemeParkRater.Services;

namespace ThemeParkRaterMVC.Controllers
{
    public class ParkController : Controller
    {
        // GET: Park
        public async Task<ActionResult> Index()
        {
            var service = GetParkService();

            return View(await service.GetAllParksAsync());
        }
        //GET Park/Create


        public ActionResult Create()
        {
            return View();
        }


        //POST Park/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
            public async Task<ActionResult> Create(ParkCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = GetParkService();
                if(await service.CreateParkAsync(model))
                {
                    return RedirectToAction("Index");
                }                
            }
            return View(model);
        }

        //GET Park/Rate/id
        [HttpGet]
        public async Task<ActionResult> Rate(int id)
        {
            var service = GetParkService();
            ViewBag.Detail = await service.GetParkByIdAsync(id);
            var model = new ParkRatingCreate { ParkId = id };
            return View();
        }

        //POST Park/Rate/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rate(ParkRatingCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = new RatingService(User.Identity.GetUserId());
                if(await service.CreateParkRatingAsync(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        private ParkService GetParkService()
        {
            var userId = User.Identity.GetUserId();
            var service = new ParkService(userId);
            return service;
        }

    }
}