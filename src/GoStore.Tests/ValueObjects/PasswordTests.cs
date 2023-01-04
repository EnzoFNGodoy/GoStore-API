using GoStore.Domain.ValueObjects;
using GoStore.Tests.Data;

namespace GoStore.Tests.ValueObjects;

public sealed class PasswordTests
{
    [Theory]
    [InlineData("")]
    [InlineData("       ")]
    [InlineData("messi123@")]
    [InlineData("Messi123")]
    [InlineData("Messi@")]
    [InlineData("MESSI@123")]
    [InlineData(StaticData.MORE_THAN_16_CHARACTERS)]
    public void ShouldReturn_Error_When_PasswordTyped_IsInvalid(string pwd)
    {
        var password = new Password(pwd);

        Assert.False(password.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_Password_IsValid()
    {
        var password = new Password("Messi123@");

        Assert.True(password.IsValid);
    }
}