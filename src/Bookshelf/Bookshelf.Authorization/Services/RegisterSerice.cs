using Bookshelf.Authorization.Enum;
using Bookshelf.Authorization.Identity;
using Bookshelf.Authorization.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Authorization.Services
{
    public class RegisterSerice : IRegisterService
    {
        private readonly UserManager<BookshelfIdentityUser> userManager;
        private readonly RoleManager<IdentityRole<Guid>> roleManager;

        public RegisterSerice(
            UserManager<BookshelfIdentityUser> userManager,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }


        public async Task<Guid> RegisterAsync(string email, string password, string firstName, string lastName)
        {
            var rolesInDb = roleManager.Roles.ToList();
            if (rolesInDb.Count == 0)
            {
                await roleManager.CreateAsync(new IdentityRole<Guid> { Name = System.Enum.GetName(typeof(RoleType), RoleType.Account) });
                await roleManager.CreateAsync(new IdentityRole<Guid> { Name = System.Enum.GetName(typeof(RoleType), RoleType.Root) });
            }
            var aspnetUser = new BookshelfIdentityUser
            {
                UserName = email,
                Email = email
            };
            var creationResult = await userManager.CreateAsync(aspnetUser, password);
            if (creationResult != IdentityResult.Success)
            {
                throw new ApplicationException($"Register failed. {string.Join("\r\n", creationResult.Errors)}");
            }
            var identityUser = await userManager.FindByNameAsync(email);
            var roleAssignmentResult = await userManager.AddToRoleAsync(identityUser, System.Enum.GetName(typeof(RoleType), RoleType.Account));
            if (roleAssignmentResult != IdentityResult.Success)
            {
                throw new ApplicationException($"Role assignment failed. {string.Join("\r\n", roleAssignmentResult.Errors)}");
            }
            return aspnetUser.Id;
        }

        public async Task<bool> SetIdInApplicationAsync(Guid aspnetGuid, int idInApplication)
        {
            var aspnetUser = await userManager.FindByIdAsync(aspnetGuid.ToString());
            if (aspnetUser == null)
            {
                return false;
            }
            aspnetUser.IdInApplication = idInApplication;
            return true;
        }
    }
}
