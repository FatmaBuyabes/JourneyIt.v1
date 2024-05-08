using JourneyItMVC.API;
using Journey.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Journy.Model.features;
using Journy.Model;
namespace JourneyItMVC.Controllers
{
    public class MypostsController : Controller
    {
        private readonly JourneyItAPI _api;
        public MypostsController(JourneyItAPI api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> MyPosts()
        {
            var result = await _api.GetMyPosts();
            return View(result);
        }


    }
}
