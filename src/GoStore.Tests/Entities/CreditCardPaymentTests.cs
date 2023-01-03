using GoStore.Domain.Entities;

namespace GoStore.Tests.Entities;

public sealed class CreditCardPaymentTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(StaticData.MORE_THAN_20_CHARACTERS)]
    public void ShouldReturn_Error_When_LastTransactionNumber_IsInvalid(string number)
    {
        var creditCardPayment = new CreditCardPayment(
            creditCard: StaticData.ValidCreditCard,
            lastTransactionNumber: number,
            paymentDate: new DateTime(2023, 02, 01),
            expirationDate: new DateTime(2023, 02, 20),
            total: StaticData.ValidPrice,
            totalPaid: StaticData.ValidPrice,
            payer: StaticData.ValidName,
            address: StaticData.ValidAddress,
            email: StaticData.ValidEmail
            );

        Assert.False(creditCardPayment.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_CreditCardPayment_IsValid()
    {
        var creditCardPayment = new CreditCardPayment(
           creditCard: StaticData.ValidCreditCard,
           lastTransactionNumber: "2391312",
           paymentDate: new DateTime(2023, 02, 01),
           expirationDate: new DateTime(2023, 02, 20),
           total: StaticData.ValidPrice,
           totalPaid: StaticData.ValidPrice,
           payer: StaticData.ValidName,
           address: StaticData.ValidAddress,
           email: StaticData.ValidEmail
           );

        Assert.True(creditCardPayment.IsValid);
    }
}