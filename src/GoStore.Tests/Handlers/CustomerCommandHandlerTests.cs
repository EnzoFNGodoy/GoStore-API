using GoStore.Domain.Commands.Customers;
using GoStore.Domain.Handlers;
using GoStore.Domain.Repositories;
using GoStore.Tests.Data;
using Moq;
using PaymentContext.Domain.Services;

namespace GoStore.Tests.Handlers;

public sealed class CustomerCommandHandlerTests
{
    private readonly Mock<ICustomerRepository> _customerRepository;
    private readonly Mock<IEmailServices> _emailServices;

    public CustomerCommandHandlerTests()
    {
        _customerRepository = new Mock<ICustomerRepository>();
        _emailServices = new Mock<IEmailServices>();

        _customerRepository.Setup(x => x.EmailExists(StaticData.EMAIL_EXISTS))
            .ReturnsAsync(true);
        _customerRepository.Setup(x => x.EmailExists(
            StaticData.ID_EXISTS, 
            StaticData.EMAIL_EXISTS))
           .ReturnsAsync(true);
        _customerRepository.Setup(x => x.CustomerExists(StaticData.ID_EXISTS))
            .ReturnsAsync(StaticData.ValidCustomer);
    }

    #region Create Customer
    [Fact]
    public async Task CreateCustomerCommand_ShouldReturn_Error_When_EmailExists()
    {
        var handler = new CustomerCommandHandler(_customerRepository.Object, _emailServices.Object);
        var command = new StaticData().ValidCreateCustomerCommand;
        command.Email = StaticData.EMAIL_EXISTS;

        await handler.Handle(command);

        Assert.False(handler.IsValid);
    }

    [Fact]
    public async Task CreateCustomerCommand_ShouldReturn_Success_When_IsValid()
    {
        var handler = new CustomerCommandHandler(_customerRepository.Object, _emailServices.Object);
        var command = new StaticData().ValidCreateCustomerCommand;

        await handler.Handle(command);

        Assert.True(handler.IsValid);
    }
    #endregion

    #region Update Customer
    [Fact]
    public async Task UpdateCustomerCommand_ShouldReturn_Error_When_Id_NotExists()
    {
        var handler = new CustomerCommandHandler(_customerRepository.Object, _emailServices.Object);
        var command = new StaticData().ValidUpdateCustomerCommand;
        command.Id = StaticData.ID_NOT_EXISTS;

        await handler.Handle(command);

        Assert.False(handler.IsValid);
    }

    [Fact]
    public async Task UpdateCustomerCommand_ShouldReturn_Error_When_EmailExists()
    {
        var handler = new CustomerCommandHandler(_customerRepository.Object, _emailServices.Object);
        var command = new StaticData().ValidUpdateCustomerCommand;
        command.Email = StaticData.EMAIL_EXISTS;

        await handler.Handle(command);

        Assert.False(handler.IsValid);
    }

    [Fact]
    public async Task UpdateCustomerCommand_ShouldReturn_Success_When_IsValid()
    {
        var handler = new CustomerCommandHandler(_customerRepository.Object, _emailServices.Object);
        var command = new StaticData().ValidUpdateCustomerCommand;

        await handler.Handle(command);

        Assert.True(handler.IsValid);
    }
    #endregion

    #region Delete Customer
    [Fact]
    public async Task DeleteCustomerCommand_ShouldReturn_Error_When_Id_NotExists()
    {
        var handler = new CustomerCommandHandler(_customerRepository.Object, _emailServices.Object);
        var command = new StaticData().ValidDeleteCustomerCommand;
        command.Id = StaticData.ID_NOT_EXISTS;

        await handler.Handle(command);

        Assert.False(handler.IsValid);
    }

    [Fact]
    public async Task DeleteCustomerCommand_ShouldReturn_Success_When_IsValid()
    {
        var handler = new CustomerCommandHandler(_customerRepository.Object, _emailServices.Object);
        var command = new StaticData().ValidUpdateCustomerCommand;

        await handler.Handle(command);

        Assert.True(handler.IsValid);
    }
    #endregion
}