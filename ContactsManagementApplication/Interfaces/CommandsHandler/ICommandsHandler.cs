using ContactsManagementApplication.Interfaces.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementApplication.Interfaces.CommandsHandler
{
    public interface ICommandsHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommands<TResponse>
    { }
}
