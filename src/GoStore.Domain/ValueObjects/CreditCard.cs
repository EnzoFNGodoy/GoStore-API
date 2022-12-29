using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;
using System.Diagnostics.Contracts;

namespace GoStore.Domain.ValueObjects;

public sealed class CreditCard : ValueObject
{
    public CreditCard(
        string cardHolderName,
        string cardNumber)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;

        AddNotifications(new Contract<CreditCard>()
            .Requires()
            .IsCreditCard(CardNumber, "CreditCard.CardNumber", "Credit Card Number is invalid.")
            .IsNotNullOrWhiteSpace(CardHolderName, "CreditCard.CardHolderName", "The Card Holder Name cannot be empty.") 
            .IsLowerOrEqualsThan(6, CardHolderName.Length, "CreditCard.CardHolderName", "The Card Holder Name must be greather than 6 characters.") 
            .IsGreaterOrEqualsThan(50, CardHolderName.Length, "CreditCard.CardHolderName", "The Card Holder Name must be less than 50 characters.") 
            );
    }

    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
}
