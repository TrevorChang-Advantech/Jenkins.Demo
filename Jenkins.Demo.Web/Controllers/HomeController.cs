using Jenkins.Demo.Service;
using Jenkins.Demo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Jenkins.Demo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserNameValidator _userNameValidator;

        public HomeController(
            ILogger<HomeController> logger,
            IUserNameValidator userNameValidator)
        {
            _logger = logger;
            _userNameValidator = userNameValidator;
        }

        public IActionResult Index(string userName)
        {
            var viewModel = new HomeViewModel { UserName = userName };

            if (!string.IsNullOrEmpty(viewModel.UserName))
            {
                if (!_userNameValidator.EnsureUsernameIsLongerThanFiveCharacters(userName))
                {
                    return RedirectToAction("Error");
                }
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}