using Flunt.Validations;
using GoStore.Domain.Core.Entities;
using GoStore.Domain.Enums;
using GoStore.Domain.Exceptions;
using GoStore.Domain.ValueObjects;

namespace GoStore.Domain.Entities;

public sealed class Order : Entity
{
    private readonly IList<Product> _products;

    public Order(
        Customer customer,
        DateTime date
        )
    {
        Customer = customer;
        Date = date;
        Payment = null;
        Status = EOrderStatus.Started;
        _products = new List<Product>();

        AddNotifications(Customer);
    }

    public Customer Customer { get; private set; }
    public Payment? Payment { get; set; }
    public DateTime Date { get; private set; }
    public EOrderStatus Status { get; private set; }
    public IReadOnlyCollection<Product> Products { get => _products.ToArray(); }

    public void AddProduct(Product product)
    {
        AddNotifications(product);

        if (IsValid)
            _products.Add(product);
    }

    public void SetPayment(Payment payment)
    {
        AddNotifications(payment, new Contract<Order>()
                    .Requires()
                    .IsLowerThan(DateTime.Now, payment.PaymentDate, "Order.Payment", "The payment date must be in the future.")
                );

        if (IsValid)
            Payment = payment;
    }

    public void ToPending()
    {
        if (IsValid is false || Payment is not null)
            throw new InvalidStatusChangeException();

        Status = EOrderStatus.Pendant;
    }

    public void Cancel()
    {
        if (IsValid is false)
            throw new InvalidStatusChangeException("The order could not be cancelled because it is invalid.");

        Status = EOrderStatus.Cancelled;
    }

    public void Finish()
    {
        if (Payment is null)
        {
            AddNotification("Order.Payment", "No payment found for this purchase.");
            return;
        }

        AddNotifications(new Contract<Order>()
                    .Requires()
                    .IsLowerThan(DateTime.Now, Payment.PaymentDate, "Order.Payment", "The payment date must be in the future.")
                );

        if (IsValid)
            Status = EOrderStatus.Finished;
    }
}