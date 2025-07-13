using Domain.ApiResponse;
using Domain.DTOs.BranchDTO;

namespace Infractructure.Interfaces;

public interface IBranchService
{
    Task<PagedResponse<List<GetBranchDTO>>> GetAllBranchsAsync(int pageNumber, int pageSize);
    Task<Response<GetBranchDTO>> GetBranchByIdAsync(int id);
    Task<Response<string>> CreateBranchAsync(CreateBranchDTO createBranchDTO);
    Task<Response<string>> UpdateBranchAsync(UpdateBranchDTO updateBranchDTO);
    Task<Response<string>> DeleteBranchAsync(int id);
}
