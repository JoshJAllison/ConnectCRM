namespace ConnectCRM.Models
{
    public class Account
    {
        public int Id { get; set; }

        // Account fields
        public string Name { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        // Address fields
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

        // Navigation property: 1:N relationship with Contacts
        public List<Contact> Contacts { get; set; } = new();
    }
}
