using ContactsManagementApplication.Interfaces.Queries;
using MediatR;

namespace ContactsManagementApplication.Interfaces.QueryHandler
{
    public interface IQueriesHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQueries<TResponse>
    { }
}
