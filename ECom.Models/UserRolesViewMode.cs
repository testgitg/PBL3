namespace ECom.Models;

public class UserRolesViewMode
{
    public int UserId { get; set; }
    public List<string> RoleNames { get; set; }
    public int SelectedIndex { get; set; }
}