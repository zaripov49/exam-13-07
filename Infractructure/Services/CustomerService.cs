using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.CustomerDTO;
using Domain.Entities;
using Infractructure.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infractructure.Services;

public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
{
    public async Task<Response<string>> RegisterCustomerAsync(RegisterCustomerDTO dto)
    {
        var exists = await customerRepository.GetByEmailAsync(dto.Email);
        if (exists != null)
        {
            return new Response<string>("Customer already exists", HttpStatusCode.Conflict);
        }

        var customer = mapper.Map<Customer>(dto);
        var hasher = new PasswordHasher<Customer>();
        customer.PasswordHash = hasher.HashPassword(customer, dto.Password);

        var result = await customerRepository.CreateAsync(customer);

        return result > 0
            ? new Response<string>("Registered successfully")
            : new Response<string>("Error occurred", HttpStatusCode.InternalServerError);
    }

    public async Task<Response<string>> UpdateCustomerAsync(UpdateCustomerDTO dto)
    {
        var customer = await customerRepository.GetByIdAsync(dto.Id);
        if (customer == null)
        {
            return new Response<string>("Customer not found", HttpStatusCode.NotFound);
        }

        mapper.Map(dto, customer);
        var result = await customerRepository.UpdateAsync(customer);

        return result > 0
            ? new Response<string>("Updated successfully")
            : new Response<string>("Error occurred", HttpStatusCode.InternalServerError);
    }
}
