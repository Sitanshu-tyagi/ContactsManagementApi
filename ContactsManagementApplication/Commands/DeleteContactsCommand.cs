using ContactsManagementApplication.Interfaces.Commands;

namespace ContactsManagementApplication.Commands
{
    public class DeleteContactsCommand : ICommands<bool>
    {
        public int Id { get; set; }
    }
}
