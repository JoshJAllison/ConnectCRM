using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectCRM.Data;
using ConnectCRM.Models;
using System;

namespace ConnectCRM.Controllers
{
    public class OpportunityController(ConnectCRMDbContext context, ILogger<OpportunityController> logger) : Controller
    {
        private readonly ConnectCRMDbContext _context = context;
        private readonly ILogger<OpportunityController> _logger = logger;

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var opportunities = await _context.Opportunities.Include(o => o.Account).ToListAsync();
            return View(opportunities);
        }
    }
}