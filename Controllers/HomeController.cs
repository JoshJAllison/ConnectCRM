using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectCRM.Data;
using ConnectCRM.Models;

namespace ConnectCRM.Controllers
{
    public class HomeController(ILogger<HomeController> logger, ConnectCRMDbContext context) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var dashboardViewModel = new DashboardViewModel
            {
                TotalAccounts = await context.Accounts.CountAsync(),
                TotalContacts = await context.Contacts.CountAsync(),
                OpenOpportunities = await context.Opportunities.CountAsync(o => o.Stage != "Closed Won" && o.Stage != "Closed Lost"),
                TotalRevenueWon = await context.Opportunities.Where(o => o.Stage == "Closed Won").SumAsync(o => o.Amount),
                RecentAccounts = await context.Accounts.OrderByDescending(a => a.Id).Take(5).ToListAsync(),
                HighValueOpportunities = await context.Opportunities
                                                    .Include(o => o.Account)
                                                    .Where(o => o.Stage != "Closed Won" && o.Stage != "Closed Lost")
                                                    .OrderByDescending(o => o.Amount)
                                                    .Take(5)
                                                    .ToListAsync()
            };

            return View(dashboardViewModel);
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