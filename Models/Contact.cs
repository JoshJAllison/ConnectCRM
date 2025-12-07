namespace ConnectCRM.Models
{
    public class Contact
    {
        public int Id { get; set; }

        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;

        
        public int AccountId { get; set; }

        
        public Account? Account { get; set; }
    }
}
