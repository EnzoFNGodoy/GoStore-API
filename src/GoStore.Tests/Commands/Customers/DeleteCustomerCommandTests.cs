using GoStore.Domain.Commands.Customers;

namespace GoStore.Tests.Commands.Customers;

public sealed class DeleteCustomerCommandTests
{
    [Fact]
    public void ShouldReturn_Error_When_Id_IsGuidEmpty()
    {
        var command = new DeleteCustomerCommand()
        {
            Id = Guid.Empty
        };

        command.Validate();

        Assert.False(command.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_DeleteCustomerCommand_IsValid()
    {
        var command = new DeleteCustomerCommand()
        {
            Id = Guid.NewGuid()
        };

        command.Validate();

        Assert.True(command.IsValid);
    }
}