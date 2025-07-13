using Domain.ApiResponse;
using Domain.DTOs.CarDTO;
using Domain.Entities;
using Domain.Filters;

namespace Infractructure.Interfaces;

public interface ICarRepository
{
    Task<PagedResponse<List<Car>>> GetAllAsync(CarFilter filter);
    Task<Car?> GetByIdAsync(int id);
    Task<int> CreateAsync(Car car);
    Task<int> UpdateAsync(Car car);
    Task<int> DeleteAsync(Car car);
}