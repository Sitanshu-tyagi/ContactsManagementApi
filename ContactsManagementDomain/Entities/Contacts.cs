using System.ComponentModel.DataAnnotations;

namespace ContactsManagementDomain.Entities
{
    public class Contacts
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
