using Domain.Entities;

namespace Infractructure.Interfaces;

public interface IRentalRepository
{
    Task<int> CreateAsync(Rental rental);  

    Task<List<Rental>> GetByCustomerIdAsync(int customerId);   

    Task<List<Rental>> GetByCarIdAsync(int carId);   

    Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate);  
}
