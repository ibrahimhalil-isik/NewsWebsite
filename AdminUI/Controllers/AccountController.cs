using AdminUI.Models;
using ApiAccess.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AdminUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IWriterApiRequest _writerApiRequest;
        public AccountController(IWriterApiRequest writerApiRequest)
        {
            _writerApiRequest = writerApiRequest;
        }
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> SingIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var writer = _writerApiRequest.GetWriterByEmailPassword(model.Email, model.Password);
                if (writer != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, model.Email)
                    };
                    var identity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("errorMessage", "Kullanıcı adı veya şifre hatalı!");
                    return View("Login");
                }
            }
            else
            {
                return View("Login");
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return View("Login");
        }
    }
}
