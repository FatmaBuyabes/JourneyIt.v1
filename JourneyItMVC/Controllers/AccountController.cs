using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JourneyItMVC.API;
using Journy.Model.Auth;

namespace JourneyItMVC.Controllers
{
    public class AccountController : Controller
    {



        private readonly JourneyItAPI _api;
        public AccountController(JourneyItAPI api)
        {
            _api = api;
        }
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest req)
        {
            var created = await _api.SignUp(req);
            if (created)
            {
                return Redirect("/Account/Login"); //Account ??
            }
            ModelState.AddModelError("Username", "Something happened, Could not create user");
            return View(req);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            var jwtToken = await _api.Login(request.Username, request.Password);
            if (jwtToken != "")
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(jwtToken);

                var claimsIdentity = new ClaimsIdentity(jwtSecurityToken.Claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);


                var authProperties = new AuthenticationProperties
                { IsPersistent = false, AllowRefresh = true };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                HttpContext.Session.SetString("Token", jwtToken);
                HttpContext.Response.Cookies.Append("Token", jwtToken);

                return Redirect("/Home/Index");  // change the Home ??
            }


            ModelState.AddModelError("Username", "Invalid Username and/or Password");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return Redirect("/Home/Index");
        }
        public IActionResult Denied()
        {
            return View();
        }
    }
}

