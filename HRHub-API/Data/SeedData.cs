using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRHub_API.Data
{
    public static class SeedData
    {
        public static async Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);

        }
        private static async Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            if(await userManager.FindByEmailAsync("grzegorz.orda@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "admin",
                    Email = "grzegorz.orda@gmail.com"
                };
               var result =  await userManager.CreateAsync(user, "Password1@");
                if(result.Succeeded)
                {
                   await  userManager.AddToRoleAsync(user, "Administrator");
                }

            }

            if (await userManager.FindByEmailAsync("eluxshopmail@gmail.com") == null)
            {
                var user = new IdentityUser
                {
                    UserName = "eluxshopmail",
                    Email = "eluxshopmail@gmail.com"
                };
                var result = await userManager.CreateAsync(user, "Password1@");
                if (result.Succeeded)
                {
                   await userManager.AddToRoleAsync(user, "Manager");
                }

            }

        }
        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                await roleManager.CreateAsync(role);


            }
            if (!await roleManager.RoleExistsAsync("Manager"))
            {
                var role = new IdentityRole
                {
                    Name = "Manager"
                };
                await roleManager.CreateAsync(role);

            }

        }
    }
}
