using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectCRM.Data;
using ConnectCRM.Models;

namespace ConnectCRM.Controllers
{
    public class AccountController(ConnectCRMDbContext context, ILogger<AccountController> logger) : Controller
    {
        private readonly ConnectCRMDbContext _context = context;
        private readonly ILogger<AccountController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accounts = await _context.Accounts.ToListAsync();
            return View(accounts);
        }
    }
}