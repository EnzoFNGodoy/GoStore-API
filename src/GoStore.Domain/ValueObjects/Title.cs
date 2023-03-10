using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;

namespace GoStore.Domain.ValueObjects;

public sealed class Title : ValueObject
{
	public Title(string text)
	{
		Text = text;

		AddNotifications(new Contract<Title>()
			.Requires()
			.IsNotNullOrWhiteSpace(Text, "Title.Text", "The title cannot be empty.")
			.IsGreaterOrEqualsThan(Text.Length, 3, "Title.Text", "The title must be longer than 3 characters ")
			.IsLowerOrEqualsThan(Text.Length, 50, "Title.Text", "The title must be less than 3 characters.")
			);
	}

    public string Text { get; private set; }
}