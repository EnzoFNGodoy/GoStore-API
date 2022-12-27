using GoStore.Domain.ValueObjects;

namespace GoStore.Domain.Entities
{
    public sealed class OrderBase
    {
        private readonly IList<Product> _products;

        public Customer Customer { get; private set; }
        public DateTime Date { get; private set; }
        public IReadOnlyCollection<Product> Product { get => _products.ToArray(); }
        public Price SubTotal { get; private set; }
        public Price Total { get; private set; }
    }
}