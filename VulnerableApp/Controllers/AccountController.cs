﻿using Microsoft.AspNetCore.Mvc;

namespace VulnerableApp.Controllers
{
    public class AccountController : Controller
    {
        public IServiceProvider Services { get; set; }
        public HttpContext Context { get { return Services.GetRequiredService<IHttpContextAccessor>().HttpContext; } }

        public AccountController(IServiceProvider services)
        {
            this.Services = services;
        }

        [HttpGet]
        public bool IsAuthenticated()
        {
            return Context.Request.Cookies["IsAuthenticated"] == "1";
        }


        [HttpPost]
        public IActionResult Login()
        {
            Context.Response.Cookies.Append("IsAuthenticated", "1");
            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            Context.Response.Cookies.Delete("IsAuthenticated");
            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
