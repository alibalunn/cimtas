using LeaveTrack.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LeaveTrack.Domain.Common.Enums;
using LeaveTrack.Application.RequestObjects;

namespace LeaveTrack.Controllers
{
    [Route("")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            
            return View();
        }

        [HttpPost("")]
        public async Task<IActionResult> Login(UserCredentialsRequest userCredentials)
        {
            if (!ModelState.IsValid)
            {
                return View(userCredentials);
            }

            string username = userCredentials.Username;
            string password = userCredentials.Password;
            var validationResult = await _authService.ValidateUserAsync(username, password);

            if (validationResult.IsValid)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, validationResult.Role ?? "User")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity));

                if (validationResult.Role == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("List", "Leave");
                }
            }

            ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
            return View(userCredentials);
        }


        [HttpGet("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }
    }
}
