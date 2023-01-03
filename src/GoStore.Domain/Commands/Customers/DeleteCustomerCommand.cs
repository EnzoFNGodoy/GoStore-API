using Flunt.Notifications;
using Flunt.Validations;
using GoStore.Domain.Core.Commands;

namespace GoStore.Domain.Commands.Customers;

public sealed class DeleteCustomerCommand : 
    Notifiable<Notification>,
    ICommand
{
    public Guid Id { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<DeleteCustomerCommand>()
            .Requires()
            .IsTrue(Id == Guid.Empty, "DeleteCustomerCommand.Id", "The id cannot be empty")
            );
    }
}