using Microsoft.AspNetCore.Mvc;
using ConnectCRM.Models;
using System.Collections.Generic;
using System;

namespace ConnectCRM.Controllers
{
    public class OpportunityController : Controller
    {
        // GET: /Opportunity
        public IActionResult Index()
        {
            var opportunities = new List<Opportunity>
            {
                new() { Id = 1, Name = "Contoso Upgrade Deal", Amount = 50000, Stage = "Proposal", CloseDate = DateTime.UtcNow.AddMonths(1), AccountId = 1 },
                new() { Id = 2, Name = "Fabrikam New System", Amount = 120000, Stage = "Negotiation", CloseDate = DateTime.UtcNow.AddMonths(2), AccountId = 2 }
            };
            return View(opportunities);
        }
    }
}
