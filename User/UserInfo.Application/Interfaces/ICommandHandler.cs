using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserInfo.Application.Interfaces
{
    public interface ICommand
    {}

    public interface ICommandHandler
    {}

    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        Task Handle(T command);
    }

}
