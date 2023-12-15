using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using MyIWallet.Contexts;
using MyIWallet.Models;
using MyIWallet.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace MyIWallet.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationContext applicationContext;
        private readonly UserManager<User> userManager;

        public HomeController(ILogger<HomeController> logger,
            ApplicationContext applicationContext,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _logger = logger;
            this.applicationContext = applicationContext;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
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