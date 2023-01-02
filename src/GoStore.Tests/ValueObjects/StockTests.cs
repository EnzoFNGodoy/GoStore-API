using GoStore.Domain.ValueObjects;

namespace GoStore.Tests.ValueObjects;

public sealed class StockTests
{
    [Fact]
    public void ShouldReturn_Error_When_Quantity_IsInvalid()
    {
        var stock = new Stock(-1);

        Assert.False(stock.IsValid);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void ShouldReturn_Success_When_Quantity_IsValid(int quantity)
    {
        var stock = new Stock(quantity);

        Assert.True(stock.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_Increase_Quantity_And_Stock_IsValid()
    {
        var stock = new Stock(6);
        stock.Decrease(5);

        Assert.Equal(1, stock.Quantity);
        Assert.True(stock.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_Decrease_Quantity_And_Stock_IsValid()
    {
        var stock = new Stock(1);
        stock.Increase(3);

        Assert.Equal(4, stock.Quantity);
        Assert.True(stock.IsValid);
    }
}