using ECom.DataAccess.Data;
using ECom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Utility;

public class ApplicationDbContextSeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetService<ApplicationDbContext>();
        string[] roles = new string[] {StaticDetail.RoleUser, StaticDetail.RoleAdmin};
        int[] ids = new int[] {StaticDetail.UserId, StaticDetail.AdminId};
        var rolesAndIds = roles.Zip(ids);
        foreach (var (role,id) in rolesAndIds)
        {
            if (!context.Roles.Any(r => r.Name == role))
            {
                context.Roles.Add(new ApplicationRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }
        }
        //
        // if (!context.UserRoles.Any(s => true))
        // {
        //     context.UserRoles.Add(new IdentityUserRole<string>()
        //     {
        //         RoleId = 
        //     })
        // }
        context.SaveChanges();
    }
}