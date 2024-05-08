
using JourneyItMVC.API;
using Journey.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Journy.Model.features;
using Journy.Model;
namespace JourneyItMVC.Controllers
{
    public class PinnedPostsController : Controller
    {
        private readonly JourneyItAPI _api;
        public PinnedPostsController(JourneyItAPI api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> PinnedPosts()
        {
            var result = await _api.GetPinnedPost();
            return View(result);
        }


    }
}
