using Domain.ApiResponse;
using Domain.DTOs.CarDTO;
using Domain.Filters;

namespace Infractructure.Interfaces;

public interface ICarService
{
    Task<PagedResponse<List<GetCarDTO>>> GetAllCarsAsync(CarFilter filter);
    Task<Response<GetCarDTO>> GetCarByIdAsync(int id);
    Task<Response<string>> CreateCarAsync(CreateCarDTO createCarDTO);
    Task<Response<string>> UpdateCarAsync(UpdateCarDTO updateCarDTO);
    Task<Response<string>> DeleteCarAsync(int id);
}
