using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectCRM.Data;
using ConnectCRM.Models;

namespace ConnectCRM.Controllers
{
    public class AccountController(ConnectCRMDbContext context, ILogger<AccountController> logger) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var accounts = await context.Accounts.ToListAsync();
            return View(accounts);
        }

        // GET: Account/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Details action called with a null ID.");
                return NotFound();
            }

            var account = await context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                logger.LogWarning("Account with ID {AccountId} not found.", id);
                return NotFound();
            }

            return View(account);
        }

        // GET: Account/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Industry,Website,Phone,Street,City,State,PostalCode,Country")] Account account)
        {
            if (ModelState.IsValid)
            {
                context.Add(account);
                await context.SaveChangesAsync();
                logger.LogInformation("New account created with ID {AccountId}.", account.Id);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Edit action called with a null ID.");
                return NotFound();
            }

            var account = await context.Accounts.FindAsync(id);
            if (account == null)
            {
                logger.LogWarning("Account with ID {AccountId} not found for editing.", id);
                return NotFound();
            }
            return View(account);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Industry,Website,Phone,Street,City,State,PostalCode,Country")] Account account)
        {
            if (id != account.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(account);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Account with ID {AccountId} updated.", account.Id);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!AccountExists(account.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        logger.LogError(ex, "Concurrency error while editing account with ID {AccountId}.", account.Id);
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Delete action called with a null ID.");
                return NotFound();
            }

            var account = await context.Accounts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                logger.LogWarning("Account with ID {AccountId} not found for deletion.", id);
                return NotFound();
            }

            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await context.Accounts.FindAsync(id);
            if (account != null)
            {
                context.Accounts.Remove(account);
                await context.SaveChangesAsync();
                logger.LogInformation("Account with ID {AccountId} deleted.", id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool AccountExists(int id)
        {
            return context.Accounts.Any(e => e.Id == id);
        }
    }
}