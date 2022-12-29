using GoStore.Domain.ValueObjects;

namespace GoStore.Domain.Entities;

public sealed class CreditCardPayment : Payment
{
    public CreditCardPayment(
        CreditCard creditCard,
        string lastTransactionNumber,
        DateTime paymentDate,
        DateTime? expirationDate,
        Price total,
        Price totalPaid,
        string payer,
        Address address,
        Email email) : base(
            paymentDate,
            expirationDate,
            total,
            totalPaid,
            payer,
            address,
            email)
    {
        CreditCard = creditCard;
        LastTransactionNumber = lastTransactionNumber;
    }

    public CreditCard CreditCard { get; private set; }
    public string LastTransactionNumber { get; private set; }
}