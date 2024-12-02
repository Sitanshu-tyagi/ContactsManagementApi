using ContactsManagementApplication.Interfaces.Queries;
using ContactsManagementDomain.Entities;

namespace ContactsManagementApplication.Queries
{
    public class GetContactsQuery : IQueries<List<Contacts>>
    {
        public int Id { get; set; }

        public GetContactsQuery(int id)
        {
            Id = id;
        }

    }
}
