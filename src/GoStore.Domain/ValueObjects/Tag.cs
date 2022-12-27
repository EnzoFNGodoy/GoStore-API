using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;
using GoStore.Domain.Helpers;

namespace GoStore.Domain.ValueObjects;

public sealed class Tag : ValueObject
{
	public Tag(string text)
	{
		Text = text.ToLower();

        AddNotifications(new Contract<Tag>()
          .Requires()
          .IsLowerThan(Text.Length, 3, "Tag.Text", "The tag must be longer than 3 characters ")
          .IsGreaterThan(Text.Length, 20, "Tag.Text", "The tag must be less than 20 characters.")
          .IsTrue(Validate(), "Tag.Text", "The tag is invalid.")
          );
    }

    public string Text { get; private set; }

    private bool Validate()
    {
        if (Text.HasWhiteSpaces())
            return false;

        if (Text.HasUpperCases())
            return false;

        return true;
    }
}