using JourneyItMVC.API;
using Journey.Model.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace JourneyItMVC.Controllers
{
    public class AddPostController : Controller
    {
        private readonly JourneyItAPI _api;
        public AddPostController(JourneyItAPI api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> Pin(int id)
        {
            await _api.Pin(id);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Rate(int id, int rating)
        {
            await _api.Rate(id, rating);
            return RedirectToAction("Index", "Home");
        }

      

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostRequest post)
        {
            await _api.CreatePost(post);
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var countres = (await _api.GetCountries()).Select(r => new SelectListItem { Text = r.CountryName, Value = r.Id.ToString() });
            ViewBag.Countries = countres;
            return View();
        }

    }
}

