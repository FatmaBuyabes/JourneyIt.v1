using Journey.Model.Requests;
using JourneyItMVC.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JourneyItMVC.Controllers
{
    public class EditProfileController : Controller
    {
        private readonly JourneyItAPI _api;
        public EditProfileController(JourneyItAPI api)
        {
            _api = api;
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditProfileRequest post)
        {
            await _api.EditProfile(post);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            // await _api.EditProfile(post);
            return View();
        }



    }
}



