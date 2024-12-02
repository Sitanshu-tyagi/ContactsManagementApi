using ContactsManagementApplication.Commands;
using ContactsManagementApplication.Interfaces.CommandsHandler;
using ContactsManagementDomain.Entities;
using ContactsManagementInfra.JsonDataStore;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementApplication.CommandsHandler
{
    public class AddContactsCommandHandler : ICommandsHandler<AddContactsCommand, int>
    {
        private readonly ContactsJsonDataStore _dataStore;


        public AddContactsCommandHandler(ContactsJsonDataStore dataStore)
        {
            _dataStore = dataStore;
        }
        public Task<int> Handle(AddContactsCommand request, CancellationToken cancellationToken)
        {
            var contactList = _dataStore.GetAll();
            var newId = contactList.Count > 0 ? contactList.Max(p => p.Id) + 1 : 1;

            var contact = new Contacts
            {
                Id = newId,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            contactList.Add(contact);
            _dataStore.SaveAll(contactList);

            return Task.FromResult(newId);
        }
    }
}
