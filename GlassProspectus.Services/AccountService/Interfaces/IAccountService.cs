using GlassProspectus.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassProspectus.Services.AccountService.Interfaces
{
    public interface IAccountService
    {
        Task PasswordSignInAsync(IdentityUser user, string password, bool isPersistent);
        Task SignInAsync(IdentityUser user, bool isPersistent);
        IdentityUser GetIdentityUser(LoginViewModel model);
        Task SignOutAsync();
    }
}
