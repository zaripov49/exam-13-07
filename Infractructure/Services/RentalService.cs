using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.RentalDTO;
using Domain.Entities;
using Infractructure.Interfaces;

namespace Infractructure.Services;

public class RentalService(
        IRentalRepository rentalRepository,
        ICarRepository carRepository,
        IMapper mapper) : IRentalService
{
    public async Task<Response<string>> CreateRentalAsync(CreateRentalDTO dto)
    {
        dto.StartDate = DateTime.SpecifyKind(dto.StartDate, DateTimeKind.Utc);
        dto.EndDate = DateTime.SpecifyKind(dto.EndDate, DateTimeKind.Utc);

        var isAvailable = await rentalRepository.IsCarAvailableAsync(dto.CarId, dto.StartDate, dto.EndDate);
        if (!isAvailable)
        {
            return new Response<string>("Car is not available for the selected dates", HttpStatusCode.Conflict);
        }

        var car = await carRepository.GetByIdAsync(dto.CarId);
        if (car == null)
        {
            return new Response<string>("Car not found", HttpStatusCode.NotFound);
        }

        var days = (dto.EndDate.Date - dto.StartDate.Date).Days;
        if (days <= 0)
        {
            return new Response<string>("Invalid rental period", HttpStatusCode.BadRequest);
        }

        var totalCost = car.PricePerDay * days;

        var rental = mapper.Map<Rental>(dto);
        rental.TotalCost = totalCost;

        var result = await rentalRepository.CreateAsync(rental);
        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }

        return new Response<string>("Rental created successfully");
    }

    public async Task<Response<List<GetRentalDTO>>> GetRentalsByCustomerAsync(int customerId)
    {
        var rentals = await rentalRepository.GetByCustomerIdAsync(customerId);
        var mapped = mapper.Map<List<GetRentalDTO>>(rentals);
        return new Response<List<GetRentalDTO>>(mapped);
    }

    public async Task<Response<List<GetRentalDTO>>> GetRentalsByCarAsync(int carId)
    {
        var rentals = await rentalRepository.GetByCarIdAsync(carId);
        var mapped = mapper.Map<List<GetRentalDTO>>(rentals);
        return new Response<List<GetRentalDTO>>(mapped);
    }
}
