using Domain.ApiResponse;
using Domain.DTOs.CustomerDTO;
using Infractructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<Response<string>> RegisterCustomerAsync(RegisterCustomerDTO registerCustomerDTO)
    {
        return await customerService.RegisterCustomerAsync(registerCustomerDTO);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCustomerAsync(UpdateCustomerDTO updateCustomerDTO)
    {
        return await customerService.UpdateCustomerAsync(updateCustomerDTO);
    }
}
