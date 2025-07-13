using Domain.ApiResponse;
using Domain.Entities;
using Domain.Paginations;
using Infractructure.Data;
using Infractructure.Interfaces;

namespace Infractructure.Repositories;

public class BranchRepository(DataContext context) : IBranchRepository
{
    public async Task<int> CreateAsync(Branch branch)
    {
        await context.Branches.AddAsync(branch);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Branch branch)
    {
        context.Branches.Remove(branch);
        return await context.SaveChangesAsync();
    }

    public async Task<PagedResponse<List<Branch>>> GetAllAsync(int pageNumber, int pageSize)
{
    var query = context.Branches.AsQueryable();

    var pagination = new Pagination<Branch>(query);
    return await pagination.GetPagedResponseAsync(pageNumber, pageSize);
}


    public async Task<Branch?> GetByIdAsync(int id)
    {
        var branch = await context.Branches.FindAsync(id);
        return branch;
    }

    public async Task<int> UpdateAsync(Branch branch)
    {
        context.Branches.Update(branch);
        return await context.SaveChangesAsync();
    }
}
