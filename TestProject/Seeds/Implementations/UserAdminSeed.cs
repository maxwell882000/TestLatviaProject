using System;
using Microsoft.AspNetCore.Identity;
using TestProject.Domain.Users;

namespace TestProject.Seeds
{
    public class UserAdminSeed : IUserAdminSeed
    {
        UserManager<User> userManager;
        IUserStore<User> _userStore;
        public UserAdminSeed(UserManager<User> userManager, IUserStore<User> _userStore)
        {
            this.userManager = userManager;
            this._userStore = _userStore;
        }
        private async Task createUser()
        {
            var user = Activator.CreateInstance<User>();
            await _userStore.SetUserNameAsync(user, "admin@admin.com", CancellationToken.None);
            user.EmailConfirmed = true;
            await this.userManager.CreateAsync(user, "123Aa123_123Aa123");
            await this.userManager.AddToRoleAsync(user, RoleType.ADMIN.ToString());
            await this.userManager.GenerateEmailConfirmationTokenAsync(user);
        }
        public async Task seed()
        {
            await createUser();
        }
    }
}

