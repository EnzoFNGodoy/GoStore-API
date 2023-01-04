using GoStore.Domain.ValueObjects;
using GoStore.Tests.Data;
using static System.Net.Mime.MediaTypeNames;

namespace GoStore.Tests.ValueObjects;

public sealed class SlugTests
{
    [Theory]
    [InlineData("")]
    [InlineData("    ")]
    [InlineData("Lionel-Messi")]
    [InlineData("-lionel-messi")]
    [InlineData("lionel-messi-")]
    [InlineData(StaticData.MORE_THAN_20_CHARACTERS)]
    public void ShouldReturn_Error_When_Text_IsInvalid(string text)
    {
        var slug = new Slug(text);

        Assert.False(slug.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_Slug_IsValid()
    {
        var slug = new Slug("lionel-messi");

        Assert.True(slug.IsValid);
    }
}