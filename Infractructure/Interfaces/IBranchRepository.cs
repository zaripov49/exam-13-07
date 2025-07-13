using Domain.ApiResponse;
using Domain.Entities;

namespace Infractructure.Interfaces;

public interface IBranchRepository
{
    Task<PagedResponse<List<Branch>>> GetAllAsync(int pageNumber, int pageSize);
    Task<Branch?> GetByIdAsync(int id);
    Task<int> CreateAsync(Branch branch);
    Task<int> UpdateAsync(Branch branch);
    Task<int> DeleteAsync(Branch branch);
}
