using ActiviGoApi.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiviGoApi.Infrastructur.Data
{
    public static class IdentitySeed
    {
        public static async Task SeedAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();

            var config = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

            // Create roles
            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create Admin user
            var adminEmail = config.GetSection("SeedUser")["email"];
            var adminUsername = config.GetSection("SeedUser")["username"];
            var adminUser = await userManager.FindByEmailAsync(adminEmail);

            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = adminUsername,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var create = await userManager.CreateAsync(adminUser, config.GetSection("SeedUser")["password"]);
                if (!create.Succeeded)
                {
                    var errors = string.Join("; ", create.Errors.Select(e => $"{e.Code}:{e.Description}"));
                    throw new Exception($"Failed to create seed admin: {errors}");
                }
            }

            // Assign Admin role
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                var addRole = await userManager.AddToRoleAsync(adminUser, "Admin");

                if (!addRole.Succeeded)
                {
                    var errors = string.Join("; ", addRole.Errors.Select(e => $"{e.Code}:{e.Description}"));
                    throw new Exception($"Failed to add seed admin to role: {errors}");
                }

            }

            // Create User users
            for (int i = 2; i <= 4; i++)
            {

                var userEmail = config.GetSection($"SeedUser{i}")["email"];
                var userUsername = config.GetSection($"SeedUser{i}")["username"];
                var normalUser = await userManager.FindByEmailAsync(userEmail);
                if (normalUser == null)
                {
                    normalUser = new User
                    {
                        UserName = userUsername,
                        Email = userEmail,
                        EmailConfirmed = true,
                        FirstName = config.GetSection($"SeedUser{i}")["firstname"],
                        LastName = config.GetSection($"SeedUser{i}")["lastname"],
                        DateOfBirth = DateTime.Parse(config.GetSection($"SeedUser{i}")["dob"])
                    };
                    var create = await userManager.CreateAsync(normalUser, config.GetSection($"SeedUser{i}")["password"]);
                    if (!create.Succeeded)
                    {
                        var errors = string.Join("; ", create.Errors.Select(e => $"{e.Code}:{e.Description}"));
                        throw new Exception($"Failed to create seed user: {errors}");
                    }
                }

                // Assign User role

                var addRole = await userManager.AddToRoleAsync(normalUser, "User");

                if(!addRole.Succeeded)
                {
                    var errors = string.Join("; ", addRole.Errors.Select(e => $"{e.Code}:{e.Description}"));
                    throw new Exception($"Failed to add seed user to role: {errors}");
                }

            }
        }
    }
}
