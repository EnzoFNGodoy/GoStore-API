using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;
using GoStore.Domain.Helpers;

namespace GoStore.Domain.ValueObjects;

public sealed class Slug : ValueObject
{
    public Slug(string text)
    {
        Text = text;

        AddNotifications(new Contract<Slug>()
            .Requires()
            .IsGreaterOrEqualsThan(Text.Length, 3, "Slug.Text", "The slug must be greater than 3 characters.")
            .IsLowerOrEqualsThan(Text.Length, 20, "Slug.Text", "The slug must be lower than 20 characters.")
            .IsTrue(Validate(), "Slug.Text", "Slug is invalid.")
            );
    }

    public string Text { get; private set; }

    private bool Validate()
    {
        if (Text.HasWhiteSpaces() ||
            Text.HasUpperCases())
            return false;

        if (Text.StartsWith('-') ||
            Text.EndsWith('-'))
            return false;

        return true;
    }
}