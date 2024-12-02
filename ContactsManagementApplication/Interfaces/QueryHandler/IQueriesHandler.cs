using ContactsManagementApplication.Interfaces.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementApplication.Interfaces.QueryHandler
{
    public interface IQueriesHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IQueries<TResponse>
    { }
}
