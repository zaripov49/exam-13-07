using Domain.ApiResponse;
using Domain.DTOs.CarDTO;
using Domain.Filters;
using Infractructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarController(ICarService carService) : ControllerBase
{
    [HttpGet]
    public async Task<PagedResponse<List<GetCarDTO>>> GetAllCarsAsync([FromQuery] CarFilter filter)
    {
        return await carService.GetAllCarsAsync(filter);
    }

    [HttpGet("{id:int}")]
    public async Task<Response<GetCarDTO>> GetCarByIdAsync(int id)
    {
        return await carService.GetCarByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCarAsync(CreateCarDTO createCarDTO)
    {
        return await carService.CreateCarAsync(createCarDTO);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCarAsync(UpdateCarDTO updateCarDTO)
    {
        return await carService.UpdateCarAsync(updateCarDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteCarAsync(int id)
    {
        return await carService.DeleteCarAsync(id);
    }
}
