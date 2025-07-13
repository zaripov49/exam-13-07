using Domain.ApiResponse;
using Domain.DTOs.CustomerDTO;

namespace Infractructure.Interfaces;

public interface ICustomerService
{
    Task<Response<string>> RegisterCustomerAsync(RegisterCustomerDTO dto);
    Task<Response<string>> UpdateCustomerAsync(UpdateCustomerDTO dto);
}
