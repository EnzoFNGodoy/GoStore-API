using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;
using GoStore.Domain.Enums;
using GoStore.Domain.Helpers;

namespace GoStore.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    public Address(
        string neighborhood, 
        string street, 
        string number, 
        string zipCode, 
        string city,
        EState state)
    {
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        City = city;
        State = state;

        AddNotifications(new Contract<Address>()
            .Requires()
            .IsGreaterOrEqualsThan(Neighborhood, 3, "Address.Neighborhood", "The neighborhood must be greather or equals than 3 characters.")
            .IsLowerOrEqualsThan(Neighborhood, 100, "Address.Neighborhood", "The neighborhood must be less than 100 characters.")
            .IsNotNullOrWhiteSpace(Neighborhood, "Address.Neighborhood", "The neighborhood cannot be empty.")
            .IsGreaterOrEqualsThan(Street, 3, "Address.Street", "The street must be greather or equals than 3 characters.")
            .IsLowerOrEqualsThan(Street, 100, "Address.Street", "The street must be less than 100 characters.")
            .IsNotNullOrWhiteSpace(Street, "Address.Street", "The street cannot be empty.")
            .IsGreaterOrEqualsThan(Number, 1, "Address.Number", "The number must be greather or equals than 1 characters.")
            .IsLowerOrEqualsThan(Number, 10, "Address.Number", "The number must be less than 100 characters.")
            .IsNotNullOrWhiteSpace(Number, "Address.Number", "The number cannot be empty.")
            .IsGreaterOrEqualsThan(City, 3, "Address.City", "The city must be greather or equals than 3 characters.")
            .IsLowerOrEqualsThan(City, 150, "Address.City", "The city must be less than 100 characters.")
            .IsNotNullOrWhiteSpace(City, "Address.City", "The city cannot be empty.")
            .IsTrue(NumberIsValid(), "Address.Number", "Number is invalid.")
            .IsTrue(ZipCodeIsValid(), "Address.ZipCode", "Zip code is invalid.")
         );
    }

    public string Neighborhood { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public EState State { get; private set; }

    private bool ZipCodeIsValid()
    {
        if (ZipCode.Length == 8 && ZipCode.IsOnlyNumbers())
            return true;

        return false;
    }

    private bool NumberIsValid()
    {
        if (Number.IsOnlyNumbers())
            return true;

        return false;
    }
}