using GoStore.Domain.Core.Entities;
using GoStore.Domain.ValueObjects;

namespace GoStore.Domain.Entities;

public sealed class Customer : Entity
{
    public Customer(
        Name name, 
        Email email, 
        Password password, 
        Address address
        )
    {
        Name = name;
        Email = email;
        Password = password;
        Address = address;

        AddNotifications(Name, Email, Password, Address);
    }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Address Address { get; private set; }
}