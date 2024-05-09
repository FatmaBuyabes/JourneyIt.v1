//using Microsoft.AspNetCore.Mvc;

//namespace JourneyItMVC.Controllers

//public class UserProfileController : Controller
//{
//    public IActionResult Index()
//    {

//        UserProfile userProfile = new UserProfile("faten aldousari", "faten@gmail.com", "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_960_720.png", "/Images/about-me-image.jpg");

//        return View(userProfile);
//    }
//}
using JourneyItMVC.API;
using Journey.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Journy.Model.features;

namespace JourneyItMVC.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly JourneyItAPI _api;
        public UserProfileController(JourneyItAPI api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _api.GetProfilet();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Follower()
        {
            var result = await _api.GetFollowers();
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Following()
        {
            var result = await _api.GetFollowing();
            return View(result);
        }
    }
}
