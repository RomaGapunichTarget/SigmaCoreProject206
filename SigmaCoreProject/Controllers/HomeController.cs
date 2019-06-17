using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SigmaCoreProject.Models;

namespace SigmaCoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly sigmaCoreContext _context;

        public HomeController(sigmaCoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var lstNews = _context.News.Select(news => news).ToList();
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
