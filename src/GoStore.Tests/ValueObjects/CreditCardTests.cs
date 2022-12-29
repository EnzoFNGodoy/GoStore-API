using GoStore.Domain.ValueObjects;

namespace GoStore.Tests.ValueObjects;

public sealed class CreditCardTests
{
    [Theory]
    [InlineData("")]
    [InlineData("               ")]
    [InlineData("                   ")]
    [InlineData("312312")]
    public void ShouldReturn_Error_When_CardNumber_IsInvalid(string cardNumberTests)
    {
        var creditCard = new CreditCard(
            cardHolderName: "Lionel Messi",
            cardNumber: cardNumberTests);

        Assert.False(creditCard.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("messi")]
    [InlineData("      ")]
    [InlineData(StaticData.MORE_THAN_50_CHARACTERS)]
    public void ShouldReturn_Error_When_CardHolderName_IsInvalid(string cardHolderNameTests)
    {
        var creditCard = new CreditCard(
           cardHolderName: cardHolderNameTests,
           cardNumber: StaticData.VALID_CREDIT_CARD_NUMBER_UNFORMATTED);

        Assert.False(creditCard.IsValid);
    }

    [Theory]
    [InlineData(StaticData.VALID_CREDIT_CARD_NUMBER_UNFORMATTED)]
    [InlineData(StaticData.VALID_CREDIT_CARD_NUMBER_FORMATTED)]
    public void ShouldReturn_Error_When_CreditCard_IsValid(string cardNumberTests)
    {
        var creditCard = new CreditCard(
            cardHolderName: "Lionel Messi",
            cardNumber: cardNumberTests);

        Assert.True(creditCard.IsValid);
    }
}