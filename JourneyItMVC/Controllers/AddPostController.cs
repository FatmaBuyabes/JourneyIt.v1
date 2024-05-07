using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JourneyItMVC.Controllers
{
    public class AddPostController : Controller
    {
        // GET: /AddPost/Create
        public IActionResult Create()
        {
            // Populate countries dropdown
            var countries = new List<SelectListItem>
            {
                new SelectListItem { Text = "USA", Value = "USA" },
                new SelectListItem { Text = "Canada", Value = "Canada" },
                // Add more countries as needed
            };

            ViewBag.Countries = countries;

            return View();
        }

        //// POST: /AddPost/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(AddPost post)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Save the blog post to the database
        //        // Example: SaveToDatabase(post);

        //        // Redirect to a success page or homepage
        //        return RedirectToAction("Index", "Home");
        //    }

        //    // If ModelState is not valid, return back to the create form with errors
        //    // Populate countries dropdown
        //    var countries = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "USA", Value = "USA" },
        //        new SelectListItem { Text = "Canada", Value = "Canada" },
        //        // Add more countries as needed
        //    };

        //    ViewBag.Countries = countries;

        //    return View(post);
        //}
    }
}

