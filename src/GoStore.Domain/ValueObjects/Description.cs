using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;

namespace GoStore.Domain.ValueObjects;

public sealed class Description : ValueObject
{
	public Description(string text)
	{
		Text = text;

        AddNotifications(new Contract<Description>()
            .Requires()
            .IsLowerThan(Text.Length, 3, "Description.Text", "The description must be longer than 3 characters ")
            .IsGreaterThan(Text.Length, 100, "Description.Text", "The description must be less than 100 characters.")
            );
    }

    public string Text { get; private set; }
}