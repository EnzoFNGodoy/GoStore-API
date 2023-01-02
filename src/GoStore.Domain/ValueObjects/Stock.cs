using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;

namespace GoStore.Domain.ValueObjects;

public sealed class Stock : ValueObject
{
    public Stock(int quantity)
    {
        Quantity = quantity;

        AddNotifications(new Contract<Stock>()
            .Requires()
            .IsGreaterOrEqualsThan(Quantity, 0, "Stock.Quantity", "The stock must be greater or equals than zero.")
            );
    }

    public int Quantity { get; private set; }

    public void Increase(int quantity)
    {
        if (IsValid) Quantity += quantity;
    }

    public void Decrease(int quantity)
    {
        if (IsValid) Quantity -= quantity;
    }
}