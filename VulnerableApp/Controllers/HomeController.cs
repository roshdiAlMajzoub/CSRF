using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VulnerableApp.Models;

namespace VulnerableApp.Controllers
{
    public class HomeController : Controller
    {
        private AccountController AccountController { get; set; }
        private ApiController ApiController { get; set; }



        public HomeController(AccountController accountController, ApiController apiController)
        {
            this.AccountController = accountController;
            this.ApiController = apiController;
        }

        public IActionResult Index()
        {
            this.ViewBag.Balance = this.ApiController.Balance();
            this.ViewBag.IsAuthenticated = this.AccountController.IsAuthenticated();
            return View();
        }

        [HttpPost]
        public IActionResult Debit(int amount)
        {
            this.ApiController.Debit(amount);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Credit(int amount)
        {
            this.ApiController.Credit(amount);

            return RedirectToAction(nameof(Index));
        }
    }
}
