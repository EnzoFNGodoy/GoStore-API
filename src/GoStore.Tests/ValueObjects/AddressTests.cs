using GoStore.Domain.Enums;
using GoStore.Domain.ValueObjects;
using System.IO;

namespace GoStore.Tests.ValueObjects;

public sealed class AddressTests
{
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("     ")]
    [InlineData(StaticData.MORE_THAN_100_CHARACTERS)]
    public void ShouldReturn_Error_When_Neighborhood_IsInvalid(string neighborhoodTests)
    {
        var address = new Address(
            neighborhood: neighborhoodTests,
            street: "Rua Nova",
            number: "123",
            zipCode: "12345678",
            city: "Araraquara",
            state: EState.SP
            );

        Assert.False(address.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("     ")]
    [InlineData(StaticData.MORE_THAN_100_CHARACTERS)]
    public void ShouldReturn_Error_When_Street_IsInvalid(string streetTests)
    {
        var address = new Address(
           neighborhood: "Vila Velha",
           street: streetTests,
           number: "123",
           zipCode: "12345678",
           city: "Araraquara",
           state: EState.SP
           );

        Assert.False(address.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("     ")]
    [InlineData("12345678901")]
    public void ShouldReturn_Error_When_Number_IsInvalid(string numberTests)
    {
        var address = new Address(
          neighborhood: "Vila Velha",
          street: "Rua Nova",
          number: numberTests,
          zipCode: "12345678",
          city: "Araraquara",
          state: EState.SP
          );

        Assert.False(address.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("172")]
    [InlineData("abcdefgh")]
    [InlineData("        ")]
    [InlineData("1234567890212")]
    public void ShouldReturn_Error_When_ZipCode_IsInvalid(string zipCodeTests)
    {
        var address = new Address(
         neighborhood: "Vila Velha",
         street: "Rua Nova",
         number: "123",
         zipCode: zipCodeTests,
         city: "Araraquara",
         state: EState.SP
         );

        Assert.False(address.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("     ")]
    [InlineData(StaticData.MORE_THAN_150_CHARACTERS)]
    public void ShouldReturn_Error_When_City_IsInvalid(string cityTests)
    {
        var address = new Address(
         neighborhood: "Vila Velha",
         street: "Rua Nova",
         number: "123",
         zipCode: "12345678",
         city: cityTests,
         state: EState.SP
         );

        Assert.False(address.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_IsValid()
    {
        var address = new Address(
         neighborhood: "Vila Velha",
         street: "Rua Nova",
         number: "123",
         zipCode: "12345678",
         city: "Araraquara",
         state: EState.SP
         );

        Assert.True(address.IsValid);
    }
}