using Domain.Entities;
using Infractructure.Data;
using Infractructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.Repositories;

public class CustomerRepository(DataContext context) : ICustomerRepository
{
    public async Task<int> CreateAsync(Customer customer)
    {
        await context.Customers.AddAsync(customer);
        return await context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Customer customer)
    {
        context.Customers.Update(customer);
        return await context.SaveChangesAsync();
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await context.Customers.FindAsync(id);
    }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await context.Customers
            .FirstOrDefaultAsync(c => c.Email!.ToLower() == email.ToLower());
    }
}
