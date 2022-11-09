using DSLab09Auth.Models.Entities;

namespace DSLab09Auth.Services;

public interface IUserRepository
{
    Task<ApplicationUser?> ReadByUsernameAsync(string username);
    Task<IQueryable<ApplicationUser>> ReadAllAsync();
    Task<bool> AssignRoleAsync(string userName, string roleName);
}
