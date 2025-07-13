using Domain.ApiResponse;
using Domain.DTOs.RentalDTO;
using Domain.Entities;

namespace Infractructure.Interfaces;

public interface IRentalService
{
    Task<Response<string>> CreateRentalAsync(CreateRentalDTO dto);
    Task<Response<List<GetRentalDTO>>> GetRentalsByCustomerAsync(int customerId);
    Task<Response<List<GetRentalDTO>>> GetRentalsByCarAsync(int carId);
}
