using GoStore.Domain.Entities;
using System.Linq.Expressions;

namespace GoStore.Domain.Queries;

public static class CustomerQueries
{
    public static Expression<Func<Customer, bool>> GetCustomerById(Guid id)
        => c => c.Id == id;

    public static Expression<Func<Customer, bool>> GetCustomerByEmailAndPassword(
        string email, string password)
        => c => c.Email.Address == email && c.Password.Text == password;
}