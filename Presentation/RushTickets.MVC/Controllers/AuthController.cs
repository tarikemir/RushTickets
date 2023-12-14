using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resend;
using RushTickets.Domain.Identity;
using RushTickets.MVC.ViewModels;
using YetGenAkbankJump.IdentityMVC.ViewModels;

namespace RushTickets.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _toastNotification;
        private readonly IResend _resend;
        private readonly IWebHostEnvironment _environment;

        public AuthController(UserManager<User> userManager, IToastNotification toastNotification, SignInManager<User> signInManager, IResend resend, IWebHostEnvironment environment)
        {
            _userManager = userManager;
            _toastNotification = toastNotification;
            _signInManager = signInManager;
            _resend = resend;
            _environment = environment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Home");
            }

            var registerViewModel = new AuthRegisterViewModel();


            return View(registerViewModel);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
        {
        }

        [HttpGet] // localhost:7206/Auth/VerifyEmail?email=alpertunga@gmail.com&token=gkomaskdlqwenmjasksdaasdadasd
        public async Task<IActionResult> VerifyEmailAsync(string email, string token)
        {
        }
        */

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var loginViewModel = new AuthLoginViewModel();

            return View(loginViewModel);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
        {
        }
        */
    }
}
