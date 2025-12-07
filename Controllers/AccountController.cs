using Microsoft.AspNetCore.Mvc;
using ConnectCRM.Models;

namespace ConnectCRM.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            var account = new List<Account>
            {
                new() {
                    Id = 1,
                    Name = "Contoso Ltd.",
                    Industry = "Technology",
                    Website = "www.contoso.com",
                    Phone = "123-456-7890",
                    Street = "123 Tech Lane",
                    City = "Techville",
                    State = "CA",
                    PostalCode = "90001",
                    Country = "USA"
                },
                new() {
                    Id = 2,
                    Name = "Fabrikam Inc.",
                    Industry = "Manufacturing",
                    Website = "www.fabrikam.com",
                    Phone = "987-654-3210",
                    Street = "456 Industrial Rd",
                    City = "Manufactoria",
                    State = "TX",
                    PostalCode = "75001",
                    Country = "USA"
                }
            };
            return View(account);
        }
    }
}
