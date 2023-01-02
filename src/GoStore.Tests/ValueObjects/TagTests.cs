using GoStore.Domain.ValueObjects;

namespace GoStore.Tests.ValueObjects;

public sealed class TagTests
{
    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData(" messi")]
    [InlineData("Messi")]
    [InlineData(StaticData.MORE_THAN_20_CHARACTERS)]
    public void ShouldReturn_Error_When_Text_IsInvalid(string text)
    {
        var tag = new Tag(text);

        Assert.False(tag.IsValid);
    }

    [Theory]
    [InlineData("mes")]
    [InlineData("messi")]
    [InlineData(StaticData.TWENTY_CHARACTERS)]
    public void ShouldReturn_Success_When_Tag_IsValid(string text)
    {
        var tag = new Tag(text);

        Assert.True(tag.IsValid);
    }
}