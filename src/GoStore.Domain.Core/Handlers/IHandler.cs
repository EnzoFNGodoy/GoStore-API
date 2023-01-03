using GoStore.Domain.Core.Commands;

namespace GoStore.Domain.Core.Handlers;

public interface IHandler<T> where T : ICommand
{
    Task<ICommandResult> Handle(T command);
}