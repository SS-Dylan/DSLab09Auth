using DSLab09Auth.Models.Entities;
using System.ComponentModel;

namespace DSLab09Auth.Models.ViewModels;

public class UserListVM
{
    public ApplicationUser? ApplicationUser { get; set; }
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    [DisplayName("Number of roles")]
    public int NumberOfRoles { get; set; } = 0;
    [DisplayName("Role name")]
    public string RoleNames { get; set; } = string.Empty;
}
