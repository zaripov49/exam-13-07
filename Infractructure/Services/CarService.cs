using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.CarDTO;
using Domain.Entities;
using Domain.Filters;
using Infractructure.Data;
using Infractructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infractructure.Services;

public class CarService(
        ICarRepository carRepository,
        IMapper mapper) : ICarService
{
    public async Task<Response<string>> CreateCarAsync(CreateCarDTO createCarDTO)
    {
        var car = mapper.Map<Car>(createCarDTO);
        var result = await carRepository.CreateAsync(car);

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>("Created Car Successfully");
    }

    public async Task<Response<string>> DeleteCarAsync(int id)
    {
        var car = await carRepository.GetByIdAsync(id);
        if (car == null)
        {
            return new Response<string>("Car not found", HttpStatusCode.NotFound);
        }

        var result = await carRepository.DeleteAsync(car);

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>("Deleted Car Successfully");
    }

    public async Task<PagedResponse<List<GetCarDTO>>> GetAllCarsAsync(CarFilter filter)
    {
        var pagedResult = await carRepository.GetAllAsync(filter);

        var mapped = mapper.Map<List<GetCarDTO>>(pagedResult.Data);

        return new PagedResponse<List<GetCarDTO>>(mapped, pagedResult.TotalRecords, pagedResult.PageNumber, pagedResult.PageSize);
    }

    public async Task<Response<GetCarDTO>> GetCarByIdAsync(int id)
    {
        var car = await carRepository.GetByIdAsync(id);
        if (car == null)
        {
            return new Response<GetCarDTO>("Car not found", HttpStatusCode.NotFound);
        }

        var mapped = mapper.Map<GetCarDTO>(car);
        return new Response<GetCarDTO>(mapped);
    }

    public async Task<Response<string>> UpdateCarAsync(UpdateCarDTO updateCarDTO)
    {
        var car = await carRepository.GetByIdAsync(updateCarDTO.Id);
        if (car == null)
        {
            return new Response<string>("Car not found", HttpStatusCode.NotFound);
        }

        mapper.Map(updateCarDTO, car);
        var result = await carRepository.UpdateAsync(car);

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>("Updated Car Successfuly");
    }

}
