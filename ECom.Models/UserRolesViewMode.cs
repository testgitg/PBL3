using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ECom.Models;
[BindProperties]
public class UserRolesViewMode
{
    public int UserId { get; set; }
    public string Username { get; set; }
    public List<String> RoleNames { get; set; }
    public int SelectedRole { get; set; }
}