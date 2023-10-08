using Bussiness.Abstract;
using Entities.Models;
using Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LogIn");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DoLogIn(string user_name, string password)
        {
            User user = _userService.GetUserByNameAndPassword(user_name, password);
            if (user == null)
            {
                return View("Message", "Yanlış kullanıcı bilgileri girdiniz!");
            }
            _userService.UpdateUserLastOnlineDate(user);

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            claim.Add(new Claim(ClaimTypes.Role, user.Role.Name));
            var claimIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var property = new AuthenticationProperties
            {
                ExpiresUtc = new DateTimeOffset(DateTime.Now.AddDays(1)),
                IssuedUtc = new DateTimeOffset(DateTime.Now)
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), property);

            return RedirectToAction("Etkinlikler");
        }

        public IActionResult Etkinlikler()
        {
            return RedirectToAction("EtkinlikList", "Etkinlik");
            //if(User.Claims.Where(s=>s.Type == ClaimTypes.Role & s.Value == "Admin").Any())
            //{
            //    return RedirectToAction("EtkinlikList", "Etkinlik");
            //}
            //else
            //{
            //    return RedirectToAction("EtkinlikList", "Etkinlik");
            //}
        }

        public IActionResult Members()
        {
            if (User.Claims.Where(s => s.Type == ClaimTypes.Role & s.Value == "Admin").Any())
            {
                return RedirectToAction("AdminMemberList", "Member");
            }
            else
            {
                return RedirectToAction("UserMemberList", "Member");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}