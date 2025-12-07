using Microsoft.EntityFrameworkCore;
using ConnectCRM.Models;

namespace ConnectCRM.Data
{
    public class ConnectCRMDbContext : DbContext
    {
        public ConnectCRMDbContext(DbContextOptions<ConnectCRMDbContext> options)
            : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }
    }
}
