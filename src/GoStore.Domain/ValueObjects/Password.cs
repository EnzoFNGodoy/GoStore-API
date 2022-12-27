using Flunt.Validations;
using GoStore.Domain.Core.ValueObjects;
using GoStore.Domain.Helpers;

namespace GoStore.Domain.ValueObjects;

public sealed class Password : ValueObject
{
    public Password(string text)
    {
        Text = text;

        AddNotifications(new Contract<Password>()
            .Requires()
            .IsFalse(Text.HasUpperCases(), "Password.Text", "The password must have at least one upper case.")
            .IsFalse(Text.HasLowerCases(), "Password.Text", "The password must have at least one lower case.")
            .IsFalse(Text.HasNumbers(), "Password.Text", "The password must have at least one number.")
            .IsFalse(Text.HasSpecialCharacter(), "Password.Text", "The password must have at least one special character.")
            .IsLowerThan(Text.Length, 3, "Password.Text", "The password must be longer than 3 characters.")
            .IsGreaterThan(Text.Length, 16, "Password.Text", "The password must be less than 16 characters.")
            );
    }

    public string Text { get; private set; }
}