using System.ComponentModel.DataAnnotations;

namespace ConnectCRM.Models
{
    public class Opportunity
    {
        public int Id { get; set; }

        // Main fields
        [Required]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        public string Stage { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime CloseDate { get; set; } = DateTime.UtcNow;

        // Foreing key to account
        public int AccountId { get; set; }
        public Account? Account { get; set; }
    }
}
