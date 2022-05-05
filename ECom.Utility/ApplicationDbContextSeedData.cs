using ECom.DataAccess.Data;
using ECom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ECom.Utility;

public class ApplicationDbContextSeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetService<ApplicationDbContext>();
        var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
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

            context.SaveChanges();
        }

        if (!context.UserRoles.Any(x => 
                x.RoleId == context.Roles.FirstOrDefault(r => r.Name == StaticDetail.RoleAdmin).Id))
        {
            
            var user= new ApplicationUser
            {
                UserName = StaticDetail.AdminEmail,
                Email=StaticDetail.AdminEmail,
                EmailConfirmed = true
            };
            await userManager.CreateAsync(user, "Admin123!");
            await userManager.AddToRoleAsync(user, StaticDetail.RoleAdmin);
            context.SaveChanges();
        }
        
    }
}