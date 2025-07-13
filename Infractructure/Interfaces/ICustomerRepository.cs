using Domain.Entities;

namespace Infractructure.Interfaces;

public interface ICustomerRepository
{
    Task<int> CreateAsync(Customer customer);
    Task<int> UpdateAsync(Customer customer);
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer?> GetByEmailAsync(string email);
}
