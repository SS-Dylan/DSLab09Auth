using DSLab09Auth.Models.Entities;

namespace DSLab09Auth.Services;

public interface IUserRepository
{
    Task<ApplicationUser?> ReadByUsernameAsync(string username);
}
