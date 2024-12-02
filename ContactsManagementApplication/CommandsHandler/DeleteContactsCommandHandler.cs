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
    public class DeleteContactsCommandHandler : ICommandsHandler<DeleteContactsCommand, bool>
    {
        private readonly ContactsJsonDataStore _dataStore;

        public DeleteContactsCommandHandler(ContactsJsonDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        public Task<bool> Handle(DeleteContactsCommand request, CancellationToken cancellationToken)
        {
            var contactList = _dataStore.GetAll();
            var contacts = contactList.FirstOrDefault(p => p.Id == request.Id);

            if (contacts == null) return Task.FromResult(false);

            contactList.Remove(contacts);
            _dataStore.SaveAll(contactList);

            return Task.FromResult(true);
        }
    }
}
