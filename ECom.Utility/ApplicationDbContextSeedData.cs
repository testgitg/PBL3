using ECom.DataAccess.Data;
using ECom.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

            context.SaveChanges();
        }

        if (!context.UserRoles.Any(x => 
                x.RoleId == context.Roles.FirstOrDefault(r => r.Name == StaticDetail.RoleAdmin).Id))
        {
            
            var user= new ApplicationUser
            {
                UserName = StaticDetail.AdminEmail,
                NormalizedUserName = StaticDetail.AdminEmail.ToUpper(),
                NormalizedEmail = StaticDetail.AdminEmail.ToUpper(),
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var password = new PasswordHasher<ApplicationUser>();
            var hashed = password.HashPassword(user, "Admin123!");
            user.PasswordHash = hashed;
            context.Users.Add(user);
            context.SaveChanges();
            var userRole = new IdentityUserRole<int>
            {
                RoleId = context.Roles.FirstOrDefault(r => r.Name == StaticDetail.RoleAdmin).Id,
                UserId = context.Users.FirstOrDefault(u => u.UserName == StaticDetail.AdminEmail).Id
            };
            context.UserRoles.Add(userRole);
            context.SaveChanges();
        }
        
    }
}