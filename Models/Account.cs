using System.ComponentModel.DataAnnotations;

namespace ConnectCRM.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Industry { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string? Phone { get; set; }

        [Required]
        public string Street { get; set; } = string.Empty;
        [Required]
        public string City { get; set; } = string.Empty;
        [Required]
        public string State { get; set; } = string.Empty;
        [Required]
        public string PostalCode { get; set; } = string.Empty;
        [Required]
        public string Country { get; set; } = string.Empty;


        public List<Contact> Contacts { get; set; } = new();
        public List<Opportunity> Opportunities { get; set; } = new();
    }
}
