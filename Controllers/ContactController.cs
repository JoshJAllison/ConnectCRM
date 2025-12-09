using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectCRM.Data;
using ConnectCRM.Models;

namespace ConnectCRM.Controllers
{
    public class ContactController(ConnectCRMDbContext context, ILogger<ContactController> logger) : Controller
    {
        // GET: Contact
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var contacts = await context.Contacts.Include(c => c.Account).ToListAsync();
            return View(contacts);
        }

        // GET: Contact/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Details action called with a null ID.");
                return NotFound();
            }

            var contact = await context.Contacts
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                logger.LogWarning("Contact with ID {ContactId} not found.", id);
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contact/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name");
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Phone,JobTitle,AccountId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Add(contact);
                await context.SaveChangesAsync();
                logger.LogInformation("New contact created with ID {ContactId}.", contact.Id);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name", contact.AccountId);
            return View(contact);
        }

        // GET: Contact/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Edit action called with a null ID.");
                return NotFound();
            }

            var contact = await context.Contacts.FindAsync(id);
            if (contact == null)
            {
                logger.LogWarning("Contact with ID {ContactId} not found for editing.", id);
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name", contact.AccountId);
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Phone,JobTitle,AccountId")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(contact);
                    await context.SaveChangesAsync();
                    logger.LogInformation("Contact with ID {ContactId} updated.", contact.Id);
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        logger.LogError(ex, "Concurrency error while editing contact with ID {ContactId}.", contact.Id);
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name", contact.AccountId);
            return View(contact);
        }

        // GET: Contact/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                logger.LogWarning("Delete action called with a null ID.");
                return NotFound();
            }

            var contact = await context.Contacts
                .Include(c => c.Account)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contact == null)
            {
                logger.LogWarning("Contact with ID {ContactId} not found for deletion.", id);
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contact = await context.Contacts.FindAsync(id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
                await context.SaveChangesAsync();
                logger.LogInformation("Contact with ID {ContactId} deleted.", id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return context.Contacts.Any(e => e.Id == id);
        }
    }
}