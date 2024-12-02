using ContactsManagementApplication.Commands;
using ContactsManagementApplication.Helper;
using ContactsManagementApplication.Interfaces.CommandsHandler;
using ContactsManagementInfra.JsonDataStore;

namespace ContactsManagementApplication.CommandsHandler
{
    public class UpdateContactsCommandHandler : ICommandsHandler<UpdateContactsCommand, bool>
    {
        private readonly ContactsJsonDataStore _dataStore;

        public UpdateContactsCommandHandler(ContactsJsonDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public Task<bool> Handle(UpdateContactsCommand request, CancellationToken cancellationToken)
        {
            var contactList = _dataStore.GetAll();
            var contacts = contactList.FirstOrDefault(p => p.Id == request.Id);

            if (contacts == null) throw new CustomNotFoundException("Contact not found with the given ID.");
            ;

            contacts.FirstName = request.FirstName;
            contacts.LastName = request.LastName;
            contacts.Email = request.Email;

            _dataStore.SaveAll(contactList);

            return Task.FromResult(true);
        }
    }
}
