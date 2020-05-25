using GlassProspectus.Services.AccountService.Interfaces;
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

        public async Task SignInAsync(IdentityUser user, bool isPersistent)
        {
            await signInManager.SignInAsync(user, isPersistent);
        }
    }
}
