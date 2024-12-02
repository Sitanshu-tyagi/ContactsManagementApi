using ContactsManagementApplication.Queries;
using ContactsManagementDomain.Entities;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementApplication.QueriesHandler
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, List<Contacts>>
    {
        private readonly string _jsonFilePath = "Contacts.json";


        public async Task<List<Contacts>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return ReadUsersFromJson();
        }

        private List<Contacts> ReadUsersFromJson()
        {
            if (File.Exists(_jsonFilePath))
            {
                var json = File.ReadAllText(_jsonFilePath);
                return JsonConvert.DeserializeObject<List<Contacts>>(json) ?? new List<Contacts>();
            }
            return new List<Contacts>();
        }
    }
}
