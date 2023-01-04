using GoStore.Domain.Entities;
using GoStore.Domain.Repositories;
using GoStore.Infra.Data.Context;
using MongoDB.Driver;

namespace GoStore.Infra.Data.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly GoStoreContext _context;

    public CustomerRepository(GoStoreContext context)
    {
        _context = context;
    }

    public async Task Create(Customer customer) 
        => await _context.Customers
        .InsertOneAsync(customer);
    

    public async Task<Customer> CustomerExists(Guid id)
        => await _context.Customers
        .FindAsync(c => c.Id == id)
        .Result.FirstOrDefaultAsync();

    public async Task Delete(Guid id) 
        => await _context.Customers
        .FindOneAndDeleteAsync(c => c.Id == id);

    public async Task<bool> EmailExists(Guid id, string email)
    {
        var customer = await _context.Customers
            .FindAsync(c => c.Email.Address == email && c.Id != id)
            .Result.FirstOrDefaultAsync();

        return customer is not null;
    }

    public async Task<bool> EmailExists(string email)
    {
        var customer = await _context.Customers
           .FindAsync(c => c.Email.Address == email)
           .Result.FirstOrDefaultAsync();

        return customer is not null;
    }

    public async Task Update(Customer customer)
        => await _context.Customers
        .FindOneAndReplaceAsync(c => c.Id == customer.Id, customer);
}