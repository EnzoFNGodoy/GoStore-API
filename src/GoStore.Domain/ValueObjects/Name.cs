using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;

namespace GoStore.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public Name(
        string firstName,
        string lastName
        )
    {
        FirstName = firstName;
        LastName = lastName;

        AddNotifications(new Contract<Name>()
            .Requires()
            .IsLowerThan(FirstName.Length, 3, "Name.FirstName", "The first name must be longer than 3 characters.")
            .IsGreaterThan(FirstName.Length, 50, "Name.FirstName", "The first name must be less than 100 characters.")
            .IsLowerThan(LastName.Length, 3, "Name.LastName", "The last name must be longer than 3 characters.")
            .IsGreaterThan(LastName.Length, 50, "Name.LastName", "The last name must be less than 100 characters.")
            );
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
}
