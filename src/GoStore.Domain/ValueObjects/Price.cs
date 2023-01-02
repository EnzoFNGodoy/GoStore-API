using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;
using System.Diagnostics.Contracts;

namespace GoStore.Domain.ValueObjects;

public sealed class Price : ValueObject
{
    public Price(decimal value)
    {
        Value = value;

        AddNotifications(new Contract<Price>()
            .Requires()
            .IsNotNull(Value, "Price.Value", "The price cannot be empty.")
            .IsGreaterThan(Value, 0, "Price.Value", "The price must be longer than zero")
            );
    }

    public decimal Value { get; private set; }
}