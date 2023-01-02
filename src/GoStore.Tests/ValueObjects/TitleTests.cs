using GoStore.Domain.ValueObjects;
using static System.Net.Mime.MediaTypeNames;

namespace GoStore.Tests.ValueObjects;

public sealed class TitleTests
{
    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(StaticData.MORE_THAN_50_CHARACTERS)]
    public void ShouldReturn_Error_When_Text_IsInvalid(string text)
    {
        var title = new Title(text);

        Assert.False(title.IsValid);
    }

    [Theory]
    [InlineData("Mes")]
    [InlineData("Messi")]
    [InlineData(StaticData.FIFTY_CHARACTERS)]
    public void ShouldReturn_Success_When_Title_IsValid(string text)
    {
        var title = new Title(text);

        Assert.True(title.IsValid);
    }
}