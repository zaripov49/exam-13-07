using Domain.ApiResponse;
using Domain.DTOs.RentalDTO;
using Infractructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalController(IRentalService rentalService) : ControllerBase
{
    [HttpPost]
    public async Task<Response<string>> CreateRentalAsync(CreateRentalDTO createRentalDTO)
    {
        return await rentalService.CreateRentalAsync(createRentalDTO);
    }

    [HttpGet("customer/{customerId:int}")]
    public async Task<Response<List<GetRentalDTO>>> GetRentalsByCustomerAsync(int customerId)
    {
        return await rentalService.GetRentalsByCustomerAsync(customerId);
    }

    [HttpGet("car/{carId:int}")]
    public async Task<Response<List<GetRentalDTO>>> GetRentalsByCarAsync(int carId)
    {
        return await rentalService.GetRentalsByCarAsync(carId);
    }
}
