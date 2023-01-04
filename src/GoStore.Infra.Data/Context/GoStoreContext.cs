using GoStore.Domain.Entities;
using GoStore.Domain.Exceptions;
using MongoDB.Driver;

namespace GoStore.Infra.Data.Context;

public class GoStoreContext
{
    public static string? ConnectionString { get; set; }
    public static string? DatabaseName { get; set; }
    public static bool IsSSL { get; set; }

    private IMongoDatabase? _database { get; }

    public GoStoreContext()
    {
        MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
        try
        {
            if (IsSSL)
            {
                settings.SslSettings = new SslSettings
                { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                var mongoClient = new MongoClient(settings);
                _database = mongoClient.GetDatabase(DatabaseName);
            }
        }
        catch (Exception)
        {
            throw new InvalidConnectionException();
        }
    }

    #region Collections
    public IMongoCollection<Customer> Customers
        => _database.GetCollection<Customer>("Customers");

    public IMongoCollection<Product> Products
        => _database.GetCollection<Product>("Products");

    public IMongoCollection<CreditCardPayment> CreditCardPayments
        => _database.GetCollection<CreditCardPayment>("CreditCardPayments");

    public IMongoCollection<Order> Orders
      => _database.GetCollection<Order>("Orders");
    #endregion
}