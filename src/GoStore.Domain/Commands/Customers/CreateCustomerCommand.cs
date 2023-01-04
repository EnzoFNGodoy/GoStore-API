using Flunt.Notifications;
using Flunt.Validations;
using GoStore.Domain.Core.Commands;
using GoStore.Domain.Enums;

#nullable disable

namespace GoStore.Domain.Commands.Customers;

public sealed class CreateCustomerCommand :
    Notifiable<Notification>,
    ICommand
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string ZipCode { get; set; }
    public string City { get; set; }
    public EState State { get; set; }

    public void Validate()
    {
        FastValidateName();
        FastValidateEmail();
        FastValidatePassword();
    }

    #region Fast Fail Validations
    private void FastValidateName()
    {
        AddNotifications(new Contract<CreateCustomerCommand>()
           .Requires()
           .IsNotNullOrWhiteSpace(FirstName, "CreateCustomerCommand.FirstName", "The first name cannot be empty.")
           .IsNotNullOrEmpty(FirstName, "CreateCustomerCommand.FirstName", "The first name cannot be empty.")
           .IsNotNullOrWhiteSpace(LastName, "CreateCustomerCommand.LastName", "The last name cannot be empty.")
           .IsNotNullOrEmpty(LastName, "CreateCustomerCommand.LastName", "The last name cannot be empty.")
           );
    }

    private void FastValidateEmail()
    {
        AddNotifications(new Contract<CreateCustomerCommand>()
           .Requires()
           .IsEmail(Email, "CreateCustomerCommand.Email", "Email is invalid.")
            );
    }

    private void FastValidatePassword()
    {
        AddNotifications(new Contract<CreateCustomerCommand>()
           .Requires()
           .IsNotNullOrWhiteSpace(Password, "CreateCustomerCommand.Text", "The password cannot be empty.")
           .IsGreaterOrEqualsThan(Password.Length, 6, "CreateCustomerCommand.Password", "The password must be greater or equals than 6 characters.")
           .IsLowerOrEqualsThan(Password.Length, 16, "CreateCustomerCommand.Password", "The password must be lower or equals than 16 characters.")
           );
    }
    #endregion
}