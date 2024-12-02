using ContactsManagementApplication.Interfaces.Commands;
using MediatR;

namespace ContactsManagementApplication.Interfaces.CommandsHandler
{
    public interface ICommandsHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommands<TResponse>
    { }
}
