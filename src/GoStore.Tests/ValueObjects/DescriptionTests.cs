using GoStore.Domain.ValueObjects;
using GoStore.Tests.Data;
using static System.Net.Mime.MediaTypeNames;

namespace GoStore.Tests.ValueObjects;

public sealed class DescriptionTests
{
    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(StaticData.MORE_THAN_100_CHARACTERS)]
    public void ShouldReturn_Error_When_Text_IsInvalid(string text)
    {
        var description = new Description(text);

        Assert.False(description.IsValid);
    }

    [Theory]
    [InlineData("abc")]
    [InlineData(StaticData.ONE_HUNDRED_CHARACTERS)]
    [InlineData("Descrição Válida")]
    public void ShouldReturn_Success_When_Description_IsValid(string text)
    {
        var description = new Description(text);

        Assert.True(description.IsValid);
    }
}