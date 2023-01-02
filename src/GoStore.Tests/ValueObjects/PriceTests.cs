using GoStore.Domain.ValueObjects;

namespace GoStore.Tests.ValueObjects;

public sealed class PriceTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void ShouldReturn_Error_When_Value_IsInvalid(decimal value)
    {
        var price = new Price(value); 

        Assert.False(price.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_Price_IsValid()
    {
        var price = new Price((decimal)99.99);

        Assert.True(price.IsValid);
    }
}