using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectCRM.Data;
using ConnectCRM.Models;
using System;

namespace ConnectCRM.Controllers
{
    public class OpportunityController(ConnectCRMDbContext context, ILogger<OpportunityController> logger) : Controller
    {
        // GET: Opportunity
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var opportunities = await context.Opportunities.Include(o => o.Account).ToListAsync();
            return View(opportunities);
        }

        // GET: Opportunity/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Details action called with a null ID.");
                return NotFound();
            }

            var opportunity = await context.Opportunities
                .Include(o => o.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                logger.LogWarning("Opportunity with ID {OpportunityId} not found.", id);
                return NotFound();
            }

            return View(opportunity);
        }

        // GET: Opportunity/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name");
            return View();
        }

        // POST: Opportunity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Amount,Stage,CloseDate,AccountId")] Opportunity opportunity)
        {
            if (ModelState.IsValid)
            {
                context.Add(opportunity);
                await context.SaveChangesAsync();
                logger.LogInformation("New opportunity created with ID {OpportunityId}.", opportunity.Id);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name", opportunity.AccountId);
            return View(opportunity);
        }

        // GET: Opportunity/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Edit action called with a null ID.");
                return NotFound();
            }

            var opportunity = await context.Opportunities.FindAsync(id);
            if (opportunity == null)
            {
                logger.LogWarning("Opportunity with ID {OpportunityId} not found for editing.", id);
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name", opportunity.AccountId);
            return View(opportunity);
        }

        // POST: Opportunity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Amount,Stage,CloseDate,AccountId")] Opportunity opportunity)
        {
            if (id != opportunity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(opportunity);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Opportunity with ID {OpportunityId} updated.", opportunity.Id);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!OpportunityExists(opportunity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        logger.LogError(ex, "Concurrency error while editing opportunity with ID {OpportunityId}.", opportunity.Id);
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name", opportunity.AccountId);
            return View(opportunity);
        }

        // GET: Opportunity/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Delete action called with a null ID.");
                return NotFound();
            }

            var opportunity = await context.Opportunities
                .Include(o => o.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (opportunity == null)
            {
                logger.LogWarning("Opportunity with ID {OpportunityId} not found for deletion.", id);
                return NotFound();
            }

            return View(opportunity);
        }

        // POST: Opportunity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opportunity = await context.Opportunities.FindAsync(id);
            if (opportunity != null)
            {
                context.Opportunities.Remove(opportunity);
                await context.SaveChangesAsync();
                logger.LogInformation("Opportunity with ID {OpportunityId} deleted.", id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool OpportunityExists(int id)
        {
            return context.Opportunities.Any(e => e.Id == id);
        }
    }
}