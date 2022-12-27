using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;
using GoStore.Domain.Validators;
using PaymentContext.Domain.Enums;

namespace GoStore.Domain.ValueObjects;

public sealed class Address : ValueObject
{
    public Address(string neighborhood, string street, string number, string zipCode, string city,
      EState state, string country)
    {
        Neighborhood = neighborhood;
        Street = street;
        Number = number;
        ZipCode = zipCode;
        City = city;
        State = state;
        Country = country;

        AddNotifications(new Contract<Address>()
            .Requires()
            .IsGreaterOrEqualsThan(Neighborhood, 3, "Address.Neighborhood", "O bairro deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(Neighborhood, 100, "Address.Neighborhood", "O bairro não deve conter mais de 100 caracteres.")
            .IsGreaterOrEqualsThan(Street, 3, "Address.Street", "A rua deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(Street, 100, "Address.Street", "A rua não deve conter mais de 100 caracteres.")
            .IsGreaterOrEqualsThan(Number, 1, "Address.Number", "O número deve conter pelo menos 1 caracteres.")
            .IsLowerOrEqualsThan(Number, 10, "Address.Number", "O número não deve conter mais de 10 caracteres.")
            .IsTrue(ZipCodeIsValid(), "Address.ZipCode", "Código postal inválido")
            .IsGreaterOrEqualsThan(City, 3, "Address.City", "A cidade deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(City, 150, "Address.City", "A cidade não deve conter mais de 150 caracteres.")
            .IsGreaterOrEqualsThan(City, 3, "Address.Country", "O país deve conter pelo menos 3 caracteres.")
            .IsLowerOrEqualsThan(City, 150, "Address.Country", "O país não deve conter mais de 150 caracteres.")
        );
    }

    public string Neighborhood { get; private set; }
    public string Street { get; private set; }
    public string Number { get; private set; }
    public string ZipCode { get; private set; }
    public string City { get; private set; }
    public EState State { get; private set; }
    public string Country { get; private set; }

    private bool ZipCodeIsValid()
    {
        if (ZipCode.Length == 8)
            return true;

        return false;
    }
}