using GoStore.Domain.Entities;
using GoStore.Domain.Queries;
using GoStore.Domain.ValueObjects;
using GoStore.Tests.Data;

namespace GoStore.Tests.Queries;

public sealed class CustomerQueriesTests
{
    private readonly IList<Customer> _customers = new List<Customer>();
    private readonly Customer _customerExistent = StaticData.ValidCustomer;

    public CustomerQueriesTests()
    {
        _customers.Add(_customerExistent);
    }

    [Fact]
    public void ShouldReturn_Error_When_Id_NotExists()
    {
        var expression = CustomerQueries.GetCustomerById(StaticData.ID_NOT_EXISTS);
        var customer = _customers?.AsQueryable().FirstOrDefault(expression);

        Assert.Null(customer);
    }

    [Fact]
    public void ShouldReturn_Success_When_Id_Exists()
    {
        var expression = CustomerQueries.GetCustomerById(_customerExistent.Id);
        var customer = _customers?.AsQueryable().FirstOrDefault(expression);

        Assert.NotNull(customer);
        Assert.Equal(customer, _customerExistent);
    }

    [Fact]
    public void ShouldReturn_Error_When_EmailOrPassword_NotExists()
    {
        var expression = CustomerQueries.GetCustomerByEmailAndPassword(
            "godoy@godoy.com",
            "Godoy123@"
            );
        var customer = _customers?.AsQueryable().FirstOrDefault(expression);

        Assert.Null(customer);
    }

    [Fact]
    public void ShouldReturn_Success_When_EmailOrPassword_Exists()
    {
        var expression = CustomerQueries.GetCustomerByEmailAndPassword(
           _customerExistent.Email.ToString(),
           _customerExistent.Password.ToString()
           );
        var customer = _customers?.AsQueryable().FirstOrDefault(expression);

        Assert.NotNull(customer);
        Assert.Equal(customer, _customerExistent);
    }
}