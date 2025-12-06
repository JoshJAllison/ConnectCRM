namespace ConnectCRM.Models
{
    public class Contact
    {
        public int Id { get; set; }

        // Contact fields
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;

        // Foreign key to Account
        public int AccountId { get; set; }

        // Navigation property to Account
        public Account? Account { get; set; }
    }
}
