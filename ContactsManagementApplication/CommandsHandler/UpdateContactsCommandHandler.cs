using ContactsManagementApplication.Commands;
using ContactsManagementApplication.Interfaces.CommandsHandler;
using ContactsManagementInfra.JsonDataStore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (contacts == null) return Task.FromResult(false);

            contacts.FirstName = request.FirstName;
            contacts.LastName = request.LastName;
            contacts.Email = request.Email;

            _dataStore.SaveAll(contactList);

            return Task.FromResult(true);
        }
    }
}
