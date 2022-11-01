using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Blog.Data
{
    public class DefaultRoleAndUsers
    {

        public static void SeedUsersAndRoles(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNamesList = new string[] { "User", "Admin" };
            foreach (string roleName in roleNamesList)
            {
                if (!roleManager.RoleExistsAsync(roleName).Result)
                {
                    IdentityRole role = new IdentityRole() { Name = roleName };
                    IdentityResult result = roleManager.CreateAsync(role).Result;
                    foreach (IdentityError error in result.Errors)
                    {
                        // TODO: Log errors
                    }
                }
            }

            string adminEmail = "admin@admin.com";
            string adminPass = "Admin123";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                IdentityUser user = new IdentityUser() { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true };
                IdentityResult result = userManager.CreateAsync(user, adminPass).Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                    // FIXME: errors
                }
                foreach (IdentityError error in result.Errors)
                {
                    // TODO: Log errors
                }
            }
        }

        public static async void UpdateUserRoles(BlogDbContext db, UserManager<IdentityUser> userManager)
        {
            List<IdentityUser> usersList = db.Users.ToList();
            foreach (IdentityUser user in usersList)
            {
                var roles = await userManager.GetRolesAsync(user);
                var userHasAnyRole = roles.Count > 0;
                if (!userHasAnyRole)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
                // FIXME: errors
            }
        }
    }
}