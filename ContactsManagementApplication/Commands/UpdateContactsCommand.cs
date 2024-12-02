using ContactsManagementApplication.Interfaces.Commands;

namespace ContactsManagementApplication.Commands
{
    public class UpdateContactsCommand: ICommands<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
