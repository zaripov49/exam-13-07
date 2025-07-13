using System.Net;
using AutoMapper;
using Domain.ApiResponse;
using Domain.DTOs.BranchDTO;
using Domain.Entities;
using Infractructure.Interfaces;

namespace Infractructure.Services;

public class BranchService(
        IBranchRepository branchRepository,
        IMapper mapper) : IBranchService
{
    public async Task<Response<string>> CreateBranchAsync(CreateBranchDTO createBranchDTO)
    {
        var branch = mapper.Map<Branch>(createBranchDTO);
        var result = await branchRepository.CreateAsync(branch);

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>("Created Branch Successfully");
    }

    public async Task<Response<string>> DeleteBranchAsync(int id)
    {
        var branch = await branchRepository.GetByIdAsync(id);
        if (branch == null)
        {
            return new Response<string>("Branch not found", HttpStatusCode.NotFound);
        }

        var result = await branchRepository.DeleteAsync(branch);

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>("Deleted Branch Successfully");
    }

    public async Task<PagedResponse<List<GetBranchDTO>>> GetAllBranchsAsync(int pageNumber, int pageSize)
    {
        var pagedResult = await branchRepository.GetAllAsync(pageNumber, pageSize);

        var mapped = mapper.Map<List<GetBranchDTO>>(pagedResult.Data);

        return new PagedResponse<List<GetBranchDTO>>(mapped, pagedResult.TotalRecords, pagedResult.PageNumber, pagedResult.PageSize);
    }

    public async Task<Response<GetBranchDTO>> GetBranchByIdAsync(int id)
    {
        var branch = await branchRepository.GetByIdAsync(id);
        if (branch == null)
        {
            return new Response<GetBranchDTO>("Branch not found", HttpStatusCode.NotFound);
        }

        var mapped = mapper.Map<GetBranchDTO>(branch);
        return new Response<GetBranchDTO>(mapped);
    }

    public async Task<Response<string>> UpdateBranchAsync(UpdateBranchDTO updateBranchDTO)
    {
        var branch = await branchRepository.GetByIdAsync(updateBranchDTO.Id);
        if (branch == null)
        {
            return new Response<string>("Branch not found", HttpStatusCode.NotFound);
        }

        mapper.Map(updateBranchDTO, branch);
        var result = await branchRepository.UpdateAsync(branch);

        if (result == 0)
        {
            return new Response<string>("Something went wrong", HttpStatusCode.InternalServerError);
        }
        return new Response<string>("Updated Branch Successfuly");
    }
}
