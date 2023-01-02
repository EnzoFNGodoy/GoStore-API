using Flunt.Validations;
using GoStore.Domain.Core.Entities;
using GoStore.Domain.ValueObjects;

namespace GoStore.Domain.Entities;

public abstract class Payment : Entity
{
    protected Payment(
        DateTime paymentDate,
        DateTime? expirationDate,
        Price total,
        Price totalPaid,
        Name payer,
        Address address,
        Email email
        )
    {
        Number = Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpper();
        PaymentDate = paymentDate;
        ExpirationDate = expirationDate;
        Total = total;
        TotalPaid = totalPaid;
        Payer = payer;
        Address = address;
        Email = email;

        AddNotifications(Total, TotalPaid, Payer, Address, Email, new Contract<Payment>()
            .Requires()
            .IsGreaterThan(Total.Value, 0, "Payment.Total", "The total cannot be zero")
            .IsGreaterOrEqualsThan(TotalPaid.Value, Total.Value, "Payment.TotalPaid", "The total paid is less than Total")
            );
    }

    public string Number { get; private set; }
    public DateTime PaymentDate { get; private set; }
    public DateTime? ExpirationDate { get; private set; }
    public Price Total { get; private set; }
    public Price TotalPaid { get; private set; }
    public Name Payer { get; private set; }
    public Address Address { get; private set; }
    public Email Email { get; private set; }
}
