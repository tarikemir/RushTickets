using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resend;
using RushTickets.Domain.Identity;
using RushTickets.MVC.ViewModels;
using RushTickets.Persistence.Contexts;

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
                return RedirectToAction(nameof(Index), "Ticket");
            }

            var registerViewModel = new AuthRegisterViewModel();


            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(AuthRegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            var userId = Guid.NewGuid();

            var user = new User()
            {
                Id = userId,
                Email = registerViewModel.Email,
                FirstName = registerViewModel.FirstName,
                SurName = registerViewModel.SurName,
                Gender = registerViewModel.Gender,
                BirthDate = registerViewModel.BirthDate.Value.ToUniversalTime(),
                UserName = registerViewModel.UserName,
                CreatedOn = DateTimeOffset.UtcNow,
                CreatedByUserId = userId.ToString()
            };

            var identityResult = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }

                return View(registerViewModel);
            }




            _toastNotification.AddSuccessToastMessage("You've successfully registered to the application.");
        
            var message = new EmailMessage();
            message.From = "sudeopann@RushTickets.net";
            message.To.Add(user.Email);
            message.Subject = "Hello!";
            message.HtmlBody = "<div><strong>Greetings<strong> 👋🏻 from .NET</div>";

            await _resend.EmailSendAsync(message);
            _toastNotification.AddSuccessToastMessage("You've successfully registered to the application.");

            return RedirectToAction(nameof(Login));
        }
      

        [HttpGet]
        public IActionResult Login()
        {
            
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(Index), "Ticket");
            }
            
            var loginViewModel = new AuthLoginViewModel();

            return View(loginViewModel);
        }

    
        
        [HttpPost]
        public async Task<IActionResult> LoginAsync(AuthLoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var user = await _userManager.FindByEmailAsync(loginViewModel.Email);

            if (user is null)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

                return View(loginViewModel);
            }

            var loginResult = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, true, false);

            if (!loginResult.Succeeded)
            {
                _toastNotification.AddErrorToastMessage("Your email or password is incorrect.");

                return View(loginViewModel);
            }

            _toastNotification.AddSuccessToastMessage($"Welcome {user.UserName}!");

            return RedirectToAction("Index",controllerName:"Ticket");
        }
    }
}
