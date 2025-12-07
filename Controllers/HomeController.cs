using System.Diagnostics;
using ConnectCRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConnectCRM.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorViewModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            logger.LogError("An error occurred while processing a request. RequestId: {RequestId}", errorViewModel.RequestId);
            return View(errorViewModel);
        }
    }
}