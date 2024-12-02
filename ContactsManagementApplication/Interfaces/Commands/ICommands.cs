using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManagementApplication.Interfaces.Commands
{
    public interface ICommands<out TResponse> : IRequest<TResponse> { }
}
