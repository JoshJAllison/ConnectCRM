namespace ConnectCRM.Models
{
    public class DashboardViewModel
    {
        public int TotalAccounts { get; set; }
        public int TotalContacts { get; set; }
        public int OpenOpportunities { get; set; }
        public decimal TotalRevenueWon { get; set; }

        public List<Account> RecentAccounts { get; set; } = new();
        public List<Opportunity> HighValueOpportunities { get; set; } = new();
    }
}