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
        foreach (var role in roles)
        {
            if(!context.Roles.Any(x => x.Name == role))
            {
                context.Roles.Add(new ApplicationRole()
                {
                    Name = role,
                    NormalizedName = role.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
            }
        }
        context.SaveChanges();
    }
}