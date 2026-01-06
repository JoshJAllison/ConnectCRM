using ConnectCRM.Data;
using ConnectCRM.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConnectCRM.Controllers
{
    public class ContactController(ConnectCRMDbContext context) : Controller
    {
        // GET: Contact
        public async Task<IActionResult> Index()
        {
            var contacts = await context.Contacts.Include(c => c.Account).ToListAsync();
            return View(contacts);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name");
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Phone,JobTitle,AccountId")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Add(contact);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // If we got this far, something failed, redisplay form
            ViewData["AccountId"] = new SelectList(context.Accounts, "Id", "Name", contact.AccountId);
            return View(contact);
        }

        // ... other actions (Details, Edit, Delete)
    }
}