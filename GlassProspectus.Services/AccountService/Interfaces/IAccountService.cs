using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlassProspectus.Services.AccountService.Interfaces
{
    public interface IAccountService
    {

        Task SignInAsync(IdentityUser user, bool isPersistent);
    }
}
