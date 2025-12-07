using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectCRM.Data;
using ConnectCRM.Models;

namespace ConnectCRM.Controllers
{
    public class ContactController(ConnectCRMDbContext context, ILogger<ContactController> logger) : Controller
    {
        private readonly ConnectCRMDbContext _context = context;
        private readonly ILogger<ContactController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await _context.Contacts.Include(c => c.Account).ToListAsync();
            return View(contacts);
        }
    }
}