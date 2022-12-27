using GoStore.Domain.Core.ValueObjects;

namespace GoStore.Domain.ValueObjects;

public sealed class CreditCard : ValueObject
{
    public CreditCard(
        string cardHolderName,
        string cardNumber)
    {
        CardHolderName = cardHolderName;
        CardNumber = cardNumber;

        AddNotifications();
    }

    public string CardHolderName { get; private set; }
    public string CardNumber { get; private set; }
}
