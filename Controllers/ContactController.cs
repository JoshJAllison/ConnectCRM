using Microsoft.AspNetCore.Mvc;
using ConnectCRM.Models;
using System.Collections.Generic;

namespace ConnectCRM.Controllers
{
    public class ContactController : Controller
    {
        // GET: /Contact
        public IActionResult Index()
        {
            var contacts = new List<Contact>
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@contoso.com", Phone = "111-222-3333", JobTitle = "Manager", AccountId = 1 },
                new() { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@fabrikam.com", Phone = "444-555-6666", JobTitle = "Developer", AccountId = 2 }
            };
            return View(contacts);
        }
    }
}
