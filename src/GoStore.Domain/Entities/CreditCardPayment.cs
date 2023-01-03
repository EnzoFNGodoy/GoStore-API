using Flunt.Validations;
using GoStore.Domain.Helpers;
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
        Name payer,
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

        AddNotifications(CreditCard, 
            new Contract<CreditCard>()
            .Requires()
            .IsNotNullOrWhiteSpace(LastTransactionNumber, "CreditCardPayment.LastTransactionNumber", "The last transaction number cannot be empty.")
            .IsGreaterOrEqualsThan(LastTransactionNumber.Length, 3, "CreditCardPayment.LastTransactionNumber", "The last transaction number must be greather or equals than 3 characters.")
            .IsLowerOrEqualsThan(LastTransactionNumber.Length, 20, "CreditCardPayment.LastTransactionNumber", "The last transaction number must be lower or equals than 20 characters.")
            .IsTrue(Validate(), "CreditCardPayment", "The credit card payment is invalid.")
            );
    }

    public CreditCard CreditCard { get; private set; }
    public string LastTransactionNumber { get; private set; }

    private bool Validate()
    {
        if (LastTransactionNumber.IsOnlyNumbers())
            return true;

        return false;
    }
}