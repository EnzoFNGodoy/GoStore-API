using GoStore.Domain.Core.Entities;
using GoStore.Domain.ValueObjects;

namespace GoStore.Domain.Entities;

public sealed class Product : Entity
{
    private readonly IList<Tag> _tags;

    public Product(
        Title title,
        Description description,
        Price price,
        Slug slug,
        Stock stock)
    {
        Title = title;
        Description = description;
        Price = price;
        Slug = slug;
        Stock = stock;
        _tags = new List<Tag>();

        AddNotifications(Title, Description, Price, Slug, Stock);
    }

    public Title Title { get; private set; }
    public Description Description { get; private set; }
    public Price Price { get; private set; }
    public Slug Slug { get; private set; }
    public Stock Stock { get; private set; }

    public IReadOnlyCollection<Tag> GetTags() => _tags.ToArray();

    public void AddTag(Tag tag)
    {
        AddNotifications(tag);

        if (IsValid)
            _tags.Add(tag);
    }
}