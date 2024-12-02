using ContactsManagementApplication.Interfaces.Commands;

namespace ContactsManagementApplication.Commands
{
    public class AddContactsCommand : ICommands<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
