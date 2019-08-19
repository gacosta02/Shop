

using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Shop.Web.Data.Entities;
using Shop.Web.Models;

namespace Shop.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManage;
        public UserHelper(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManage = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await this.userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await this.userManager.FindByEmailAsync(email);
            
        }

        public async  Task<SignInResult> LoginAsync(LoginViewModel model)
        {
         return await this.signInManage.PasswordSignInAsync(
         model.Username,
         model.Password,
         model.RememberMe,
         false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManage.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
            return await this.userManager.UpdateAsync(user);
        }
    }
}
