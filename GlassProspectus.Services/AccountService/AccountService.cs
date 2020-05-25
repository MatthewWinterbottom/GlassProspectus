using GlassProspectus.Services.AccountService.Interfaces;
using GlassProspectus.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GlassProspectus.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountService(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task PasswordSignInAsync(IdentityUser user, string password, bool isPersistent) =>
            await signInManager.PasswordSignInAsync(user, password, isPersistent, false);

        public async Task SignInAsync(IdentityUser user, bool isPersistent) =>
            await signInManager.SignInAsync(user, isPersistent);

        public IdentityUser GetIdentityUser(LoginViewModel model) =>
            new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
