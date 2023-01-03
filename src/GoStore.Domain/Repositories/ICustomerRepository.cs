using GoStore.Domain.Entities;

namespace GoStore.Domain.Repositories;

public interface ICustomerRepository
{
    public Task<bool> EmailExists(Guid id, string email); // For Update method
    public Task<bool> EmailExists(string email); // For Create method
    public Task<Customer> CustomerExists(Guid id); // For Create method
    public Task Create(Customer customer);
    public Task Update(Customer customer);
    public Task Delete(Guid id);
}