using Microsoft.AspNetCore.Identity;

namespace DSLab09Auth.Services;

public interface IRoleRepository
{
    IQueryable<IdentityRole> ReadAll();
}
