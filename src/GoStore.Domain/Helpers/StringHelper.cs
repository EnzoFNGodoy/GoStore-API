namespace GoStore.Domain.Helpers;

public static class StringHelper
{
    public static bool HasWhiteSpaces(this string text) => text.Any(char.IsWhiteSpace);

    public static bool HasUpperCases(this string text) => text.Any(char.IsUpper);

    public static bool HasLowerCases(this string text) => text.Any(char.IsLower);

    public static bool HasNumbers(this string text) => text.Any(char.IsNumber);

    public static bool HasSpecialCharacter(this string text) => 
        text.Any(char.IsPunctuation) || text.Any(char.IsSymbol);

    public static bool IsOnlyNumbers(this string text) => text.All(char.IsNumber);
}