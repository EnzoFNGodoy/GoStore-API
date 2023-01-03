using GoStore.Domain.Entities;
using GoStore.Domain.Enums;
using GoStore.Domain.Exceptions;
using System.Reflection.Metadata.Ecma335;

namespace GoStore.Tests.Entities;

public sealed class OrderTests
{
    #region AddProduct
    [Fact]
    public void ShouldReturn_Error_When_TryingTo_AddProduct_That_IsInvalid()
    {
        var data = new StaticData();
        var order = data.ValidOrder;
        var product = data.InvalidProduct;

        order.AddProduct(product);

        Assert.False(order.GetProducts().Any());
        Assert.False(order.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_TryingTo_AddProduct()
    {
        var data = new StaticData();
        var order = data.ValidOrder;
        var product = data.ValidProduct;

        order.AddProduct(product);

        Assert.True(order.GetProducts().Any());
        Assert.Equal(1, order.GetProducts().Count);
        Assert.True(order.IsValid);
    }
    #endregion

    #region SetPayment
    [Fact]
    public void ShouldReturn_Error_When_TryingTo_SetPayment_That_IsInvalid()
    {
        var data = new StaticData();
        var order = data.ValidOrder;
        var payment = data.InvalidCreditCardPayment;

        order.SetPayment(payment);

        Assert.Null(order.Payment);
        Assert.False(order.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_TryingTo_SetPayment()
    {
        var data = new StaticData();
        var order = data.ValidOrder;
        var payment = data.ValidCreditCardPayment;

        order.SetPayment(payment);

        Assert.NotNull(order.Payment);
        Assert.True(order.IsValid);
    }
    #endregion

    #region To Pending
    [Fact]
    public void ShouldReturn_Error_When_TryingTo_ChangeTheStatus_ToPending_But_Order_IsInvalid()
    {
        var data = new StaticData();
        var order = data.ValidOrder; 
        var payment = data.ValidCreditCardPayment;

        order.SetPayment(payment);

        var ex = Assert.Throws<InvalidStatusChangeException>(order.ToPending);
        Assert.Equal("The status cannot be changed. The order is invalid.", ex.Message);
    }

    [Fact]
    public void ShouldReturn_Success_When_TryingTo_ChangeTheStatus_ToPending()
    {
        var data = new StaticData();
        var order = data.ValidOrder;

        order.ToPending();

        Assert.Equal(EOrderStatus.Pendant, order.Status);
        Assert.True(order.IsValid);
    }
    #endregion

    #region Cancel
    [Fact]
    public void ShouldReturn_Error_When_TryingTo_Cancel_But_Order_IsInvalid()
    {
        var data = new StaticData();
        var order = data.InvalidOrder;

        var ex = Assert.Throws<InvalidStatusChangeException>(order.Cancel);
        Assert.Equal("The order could not be cancelled because it is invalid.", ex.Message);
    }

    [Fact]
    public void ShouldReturn_Success_When_TryingTo_Cancel()
    {
        var data = new StaticData();
        var order = data.ValidOrder;

        order.Cancel();

        Assert.Equal(EOrderStatus.Cancelled, order.Status);
        Assert.True(order.IsValid);
    }
    #endregion

    #region Finish
    [Fact]
    public void ShouldReturn_Error_When_TryingTo_Finish_But_Order_IsInvalid()
    {
        var data = new StaticData();
        var order = data.InvalidOrder;

        order.Finish();

        Assert.NotEqual(EOrderStatus.Finished, order.Status);
        Assert.False(order.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_TryingTo_Finish()
    {
        var data = new StaticData();
        var order = data.ValidOrder;
        var payment = data.ValidCreditCardPayment;

        order.SetPayment(payment);

        order.Finish();

        Assert.Equal(EOrderStatus.Finished, order.Status);
        Assert.True(order.IsValid);
    }
    #endregion

    [Fact]
    public void ShouldReturn_Success_When_Order_IsValid()
    {
        var data = new StaticData();
        var order = new Order(
        StaticData.ValidCustomer,
        new DateTime(2023, 05, 11)
        );

        order.AddProduct(data.ValidProduct);
        order.AddProduct(data.ValidProduct);

        var payment = data.ValidCreditCardPayment;

        order.SetPayment(payment);

        order.Finish();

        Assert.Equal(2, order.GetProducts().Count);
        Assert.NotNull(order.Payment);
        Assert.Equal(EOrderStatus.Finished, order.Status);
        Assert.True(order.IsValid);

        
    }
}