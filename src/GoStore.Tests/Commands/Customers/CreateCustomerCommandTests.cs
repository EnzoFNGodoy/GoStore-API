using GoStore.Domain.Commands.Customers;
using GoStore.Domain.ValueObjects;

namespace GoStore.Tests.Commands.Customers;

public sealed class CreateCustomerCommandTests
{
    private readonly Address _address = StaticData.ValidAddress;

    [Theory]
    [InlineData("Lionel", "")]
    [InlineData("Lionel", "  ")]
    [InlineData("", "Messi")]
    [InlineData("  ", "Messi")]
    public void ShouldReturn_Error_When_Name_IsInvalid(string firstName, string lastName)
    {
        var command = new CreateCustomerCommand()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = StaticData.ValidEmail.ToString(),
            Password = StaticData.ValidPassword.ToString(),
            Neighborhood = _address.Neighborhood,
            Street = _address.Street,
            Number = _address.Number,
            ZipCode = _address.ZipCode,
            City = _address.City,
            State = _address.State
        };

        command.Validate();

        Assert.False(command.IsValid);
    }

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
    public void ShouldReturn_Error_When_Email_IsInvalid(string email)
    {
        var command = new CreateCustomerCommand()
        {
            FirstName = "Lionel",
            LastName = "Messi",
            Email = email,
            Password = StaticData.ValidPassword.ToString(),
            Neighborhood = _address.Neighborhood,
            Street = _address.Street,
            Number = _address.Number,
            ZipCode = _address.ZipCode,
            City = _address.City,
            State = _address.State
        };

        command.Validate();

        Assert.False(command.IsValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("       ")]
    [InlineData(StaticData.MORE_THAN_16_CHARACTERS)]
    public void ShouldReturn_Error_When_Password_IsInvalid(string pwd)
    {
        var command = new CreateCustomerCommand()
        {
            FirstName = "Lionel",
            LastName = "Messi",
            Email = StaticData.ValidEmail.ToString(),
            Password = pwd,
            Neighborhood = _address.Neighborhood,
            Street = _address.Street,
            Number = _address.Number,
            ZipCode = _address.ZipCode,
            City = _address.City,
            State = _address.State
        };

        command.Validate();

        Assert.False(command.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_CreateCustomerCommand_IsValid()
    {
        var command = new CreateCustomerCommand()
        {
            FirstName = "Lionel",
            LastName = "Messi",
            Email = StaticData.ValidEmail.ToString(),
            Password = StaticData.ValidPassword.ToString(),
            Neighborhood = _address.Neighborhood,
            Street = _address.Street,
            Number = _address.Number,
            ZipCode = _address.ZipCode,
            City = _address.City,
            State = _address.State
        };

        command.Validate();

        Assert.True(command.IsValid);
    }
}