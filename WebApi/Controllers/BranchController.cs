using Domain.ApiResponse;
using Domain.DTOs.BranchDTO;
using Infractructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BranchController(IBranchService branchService) : ControllerBase
{
    [HttpGet]
    public async Task<PagedResponse<List<GetBranchDTO>>> GetAllBranchsAsync(int pageNumber, int pageSize)
    {
        return await branchService.GetAllBranchsAsync(pageNumber, pageSize);
    }

    [HttpGet("{id:int}")]
    public async Task<Response<GetBranchDTO>> GetBranchByIdAsync(int id)
    {
        return await branchService.GetBranchByIdAsync(id);
    }

    [HttpPost]
    public async Task<Response<string>> CreateBranchAsync(CreateBranchDTO createBranchDTO)
    {
        return await branchService.CreateBranchAsync(createBranchDTO);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateBranchAsync(UpdateBranchDTO updateBranchDTO)
    {
        return await branchService.UpdateBranchAsync(updateBranchDTO);
    }

    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteBranchAsync(int id)
    {
        return await branchService.DeleteBranchAsync(id);
    }
}
