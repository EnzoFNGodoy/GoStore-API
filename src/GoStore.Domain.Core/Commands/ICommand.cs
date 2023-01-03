using Flunt.Notifications;

namespace GoStore.Domain.Core.Commands;

public interface ICommand
{
    void Validate();
}