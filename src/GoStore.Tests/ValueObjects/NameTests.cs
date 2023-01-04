using GoStore.Domain.ValueObjects;
using GoStore.Tests.Data;

namespace GoStore.Tests.ValueObjects;

public sealed class NameTests
{
    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(StaticData.MORE_THAN_50_CHARACTERS)]
    public void ShouldReturn_Error_When_FirstName_IsInvalid(string firstName)
    {
        var name = new Name(firstName, "Messi");

        Assert.False(name.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(StaticData.MORE_THAN_50_CHARACTERS)]
    public void ShouldReturn_Error_When_LastName_IsInvalid(string lastName)
    {
        var name = new Name("Lionel", lastName);

        Assert.False(name.IsValid);
    }

    [Theory]
    [InlineData("Lionel", "Messi")]
    [InlineData(StaticData.FIFTY_CHARACTERS, StaticData.FIFTY_CHARACTERS)]
    [InlineData("Lio", "Mes")]
    public void ShouldReturn_Success_When_Name_IsValid(string firstName, string lastName)
    {
        var name = new Name(firstName, lastName);

        Assert.True(name.IsValid);
    }
}