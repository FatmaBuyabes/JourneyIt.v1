using JourneyItMVC.API;
using Journey.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Journy.Model.features;
using Journy.Model;
using Journey.Model.Requests;
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
        [HttpGet]
        public async Task<IActionResult> EditPost(int id)
        {
          
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(int id,EditPostRequest edit)
        {
            var result = await _api.EditPost(id,edit);
            return RedirectToAction("Myposts");
        }

    }
}
