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
            .IsTrue(Text.HasUpperCases(), "Password.Text", "The password must have at least one upper case.")
            .IsTrue(Text.HasLowerCases(), "Password.Text", "The password must have at least one lower case.")
            .IsTrue(Text.HasNumbers(), "Password.Text", "The password must have at least one number.")
            .IsTrue(Text.HasSpecialCharacter(), "Password.Text", "The password must have at least one special character.")
            .IsNotNullOrWhiteSpace(Text, "Password.Text", "The password cannot be empty.")
            .IsGreaterOrEqualsThan(Text.Length, 6, "Password.Text", "The password must be greater or equals than 6 characters.")
            .IsLowerOrEqualsThan(Text.Length, 16, "Password.Text", "The password must be lower or equals than 16 characters.")
            );
    }

    public string Text { get; private set; }

    public override string ToString() => Text;
}