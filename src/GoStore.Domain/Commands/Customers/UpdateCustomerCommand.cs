using Flunt.Notifications;
using Flunt.Validations;
using GoStore.Domain.Core.Commands;
using GoStore.Domain.Enums;

#nullable disable

namespace GoStore.Domain.Commands.Customers;

public sealed class UpdateCustomerCommand :
    Notifiable<Notification>,
    ICommand
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public EState State { get; set; }

    public void Validate()
    {
        FastValidateId();
        FastValidateName();
        FastValidateEmail();
    }

    #region Fast Fail Validations
    private void FastValidateId()
    {
        AddNotifications(new Contract<UpdateCustomerCommand>()
           .Requires()
           .IsFalse(Id == Guid.Empty, "UpdateCustomerCommand.Id", "The ID cannot be empty.")
           );
    }

    private void FastValidateName()
    {
        AddNotifications(new Contract<UpdateCustomerCommand>()
           .Requires()
           .IsNotNullOrWhiteSpace(FirstName, "UpdateCustomerCommand.FirstName", "The first name cannot be empty.")
           .IsNotNullOrEmpty(FirstName, "UpdateCustomerCommand.FirstName", "The first name cannot be empty.")
           .IsNotNullOrWhiteSpace(LastName, "UpdateCustomerCommand.LastName", "The last name cannot be empty.")
           .IsNotNullOrEmpty(LastName, "UpdateCustomerCommand.LastName", "The last name cannot be empty.")
           );
    }

    private void FastValidateEmail()
    {
        AddNotifications(new Contract<UpdateCustomerCommand>()
           .Requires()
           .IsEmail(Email, "UpdateCustomerCommand.Email", "Email is invalid.")
            );
    }
    #endregion
}