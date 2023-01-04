using GoStore.Domain.Commands.Customers;
using GoStore.Domain.ValueObjects;

namespace GoStore.Tests.Commands.Customers;

public sealed class UpdateCustomerCommandTests
{
    private readonly Address _address = StaticData.ValidAddress;

    [Fact]
    public void ShouldReturn_Error_When_Id_IsGuidEmpty()
    {
        var command = new UpdateCustomerCommand()
        {
            Id = Guid.Empty,
            FirstName = "Lionel",
            LastName = "Messi",
            Email = StaticData.ValidEmail.ToString(),
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
    [InlineData("Lionel", "")]
    [InlineData("Lionel", "  ")]
    [InlineData("", "Messi")]
    [InlineData("  ", "Messi")]
    public void ShouldReturn_Error_When_Name_IsInvalid(string firstName, string lastName)
    {
        var command = new UpdateCustomerCommand()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = StaticData.ValidEmail.ToString(),
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
        var command = new UpdateCustomerCommand()
        {
            Id = Guid.NewGuid(),
            FirstName = "Lionel",
            LastName = "Messi",
            Email = email,
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
    public void ShouldReturn_Success_When_UpdateCustomerCommand_IsValid()
    {
        var command = new UpdateCustomerCommand()
        {
            Id = Guid.NewGuid(),
            FirstName = "Lionel",
            LastName = "Messi",
            Email = StaticData.ValidEmail.ToString(),
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