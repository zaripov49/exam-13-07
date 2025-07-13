using Domain.Entities;
using Infractructure.Data;
using Infractructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.Repositories;

public class RentalRepository(DataContext context) : IRentalRepository
{
    public async Task<int> CreateAsync(Rental rental)
    {
        await context.Rentals.AddAsync(rental);
        return await context.SaveChangesAsync();
    }

    public async Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate)
    {
        return !await context.Rentals.AnyAsync(r =>
            r.CarId == carId &&
            r.StartDate < endDate && r.EndDate > startDate
        );
    }

    public async Task<List<Rental>> GetByCustomerIdAsync(int customerId)
    {
        return await context.Rentals
            .Where(r => r.CustomerId == customerId)
            .Include(r => r.Car)
            .Include(r => r.Branch)
            .ToListAsync();
    }

    public async Task<List<Rental>> GetByCarIdAsync(int carId)
    {
        return await context.Rentals
            .Where(r => r.CarId == carId)
            .Include(r => r.Customer)
            .Include(r => r.Branch)
            .ToListAsync();
    }
}
