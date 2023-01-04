using GoStore.Domain.Entities;
using GoStore.Tests.Data;

namespace GoStore.Tests.Entities;

public sealed class ProductTests
{
    [Fact]
    public void ShouldReturn_Error_When_TryingTo_AddTag_That_IsInvalid()
    {
        var product = new Product(
            title: StaticData.ValidTitle,
            description: StaticData.ValidDescription,
            price: StaticData.ValidPrice,
            slug: StaticData.ValidSlug,
            stock: StaticData.ValidStock
            );

        var tag = StaticData.InvalidTag;

        product.AddTag(tag);

        Assert.False(product.GetTags().Any());
        Assert.False(product.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_TryingTo_AddTag()
    {
        var product = new Product(
            title: StaticData.ValidTitle,
            description: StaticData.ValidDescription,
            price: StaticData.ValidPrice,
            slug: StaticData.ValidSlug,
            stock: StaticData.ValidStock
            );

        var tag = StaticData.ValidTag;

        product.AddTag(tag);

        Assert.Equal(1, product.GetTags().Count);
        Assert.True(product.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_Product_IsValid()
    {
        var product = new Product(
            title: StaticData.ValidTitle,
            description: StaticData.ValidDescription,
            price: StaticData.ValidPrice,
            slug: StaticData.ValidSlug,
            stock: StaticData.ValidStock
            );

        Assert.True(product.IsValid);
    }
}