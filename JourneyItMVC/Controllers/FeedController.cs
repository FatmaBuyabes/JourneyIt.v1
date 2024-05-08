//using Journey.Model.Responses;
//using JourneyItMVC.API;
//using Journy.Model;
//using Journy.Model.features;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore.Metadata.Internal;

//namespace JourneyItMVC.Controllers
//{
//    public class FeedController : Controller
//    {
//        private readonly JourneyItAPI _api;
//        public FeedController(JourneyItAPI api)
//        {
//            _api = api;
//        }

//        //private readonly List<PostResponse> _posts = new List<PostResponse>
//        //{
//        //    new Post
//        //    {
//        //        Id = 1,
//        //        UserId = 1,
//        //        User = "Faten",
//        //        Title="",
//        //        CountryId = 1,
//        //        ImgPath = "/images/post1.jpg",
//        //        Texts = "Kuwait, a small but vibrant country in the Middle East, offers a mix of modernity and tradition. Visitors can explore its stunning architecture, such as the iconic Kuwait Towers, and delve into its rich cultural heritage at places like the Kuwait National Museum."
//        //    },
//        //    new Post
//        //    {
//        //        Id = 2,
//        //        UserId = 2,
//        //        User = "Awdah",
//        //        Title=,
//        //        Country = "Canada",
//        //        ImgPath = "/images/post2.jpg",
//        //        Texts = "A trip to Canada promises diverse experiences, from the natural wonders of Banff National Park to the multicultural vibes of Toronto and the historic charm of Quebec City"
//        //    },
//        //    new Post
//        //    {
//        //        Id = 3,
//        //        UserId = 3,
//        //        User = "fatma",
//        //        Country = "France",
//        //        ImgPath = "/images/post3.jpg",
//        //        Texts = "A trip to France is a journey through history, culture, and culinary delights. Start with the iconic landmarks of Paris, from the Eiffel Tower to the Louvre Museum, then wander through charming cobblestone streets in picturesque villages like Provence or Normandy. "
//        //    },
//        //    new Post
//        //    {
//        //        Id = 4,
//        //        UserId = 4,
//        //        User = "noura",
//        //        Country = "UK",
//        //        ImgPath = "/images/post4.jpg",
//        //        Texts = "A trip to the UK offers a fascinating blend of history, culture, and natural beauty. Start with iconic landmarks like Big Ben and Buckingham Palace in London, then explore historic cities like Edinburgh and Bath. "
//        //    },
//        //    new Post
//        //    {
//        //        Id = 5,
//        //        UserId = 5,
//        //        User = "nawaf",
//        //        Country = "Germany",
//        //        ImgPath = "/images/post5.jpg",
//        //        Texts = "A trip to Canada promises unforgettable experiences, from exploring the stunning landscapes of Banff and Jasper National Parks to immersing yourself in vibrant cities like Toronto and Vancouver."
//        //    }
//        //};

//        [HttpGet]
//        public async Task<IActionResult> Explore()
//        {
//            var result = await _api.GetRandomPost();
//            return View(result);
//        }
//        }
//    }

using JourneyItMVC.API;
using Journey.Model.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Journy.Model.features;
using Journy.Model;
namespace JourneyItMVC.Controllers
{
    public class FeedController : Controller
    {
        private readonly JourneyItAPI _api;
        public FeedController(JourneyItAPI api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> Explore()
        {
            var result = await _api.GetRandomPost();
            return View(result);
        }


    }
}
