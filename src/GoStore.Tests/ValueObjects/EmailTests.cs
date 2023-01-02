using GoStore.Domain.ValueObjects;
using System.Net.Mail;

namespace GoStore.Tests.ValueObjects;

public sealed class EmailTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("@")]
    [InlineData("@.")]
    [InlineData("@.com")]
    [InlineData("@psg.com")]
    [InlineData("lionel.messi@.com")]
    [InlineData("lionel.messi@psg.")]
    [InlineData("lionel.messipsg.com")]
    public void ShouldReturn_Error_When_EmailAddress_IsInvalid(string emailAddress)
    {
        var email = new Email(emailAddress);

        Assert.False(email.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_Email_IsValid()
    {
        var email = new Email("lionel.messi@psg.com");

        Assert.True(email.IsValid);
    }
}