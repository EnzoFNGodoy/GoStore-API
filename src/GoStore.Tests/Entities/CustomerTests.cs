using GoStore.Domain.Entities;
using GoStore.Tests.Data;

namespace GoStore.Tests.Entities;

public sealed class CustomerTests
{
    [Fact]
    public void ShouldReturn_Success_When_Customer_IsValid()
    {
        var customer = new Customer(
            name: StaticData.ValidName,
            email: StaticData.ValidEmail,
            password: StaticData.ValidPassword,
            address: StaticData.ValidAddress);

        Assert.True(customer.IsValid);
    }
}