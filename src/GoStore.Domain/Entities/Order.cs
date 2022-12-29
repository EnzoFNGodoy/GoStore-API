using Flunt.Validations;
using GoStore.Domain.Core.Entities;
using GoStore.Domain.Enums;
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
    public IReadOnlyCollection<Product> Product { get => _products.ToArray(); }

    public void AddProduct(Product product)
    {
        AddNotifications(product);

        if (IsValid)
            _products.Add(product);
    }

    public void SetPayment(Payment? payment)
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
            Payment = payment;
    }

    public void ToPending()
    {
        if (IsValid && Payment is null)
            Status = EOrderStatus.Pendant;
    }

    public void Cancel()
    {
        if (IsValid)
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