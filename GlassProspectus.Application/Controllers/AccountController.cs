using GlassProspectus.Services.AccountService.Interfaces;
using GlassProspectus.Services.UserService.Interfaces;
using GlassProspectus.Services.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GlassProspectus.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IAccountService accountService;

        public AccountController(IUserService userService,
                                 IAccountService accountService)
        {
            this.userService = userService;
            this.accountService = accountService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<bool> Register([Bind] UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = userService.GetUserFromViewModel(user);

                var successStatus = await userService.CreateUserAsync(identityUser, user.Password); // Create a User

                if (successStatus)
                    await accountService.SignInAsync(identityUser, isPersistent: false);
            }

            return true;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<bool> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = accountService.GetIdentityUser(model);

                await accountService.PasswordSignInAsync(identityUser, model.Password, model.RememberMe);

                return true;
            }

            return false;
        }

        [HttpPost]
        [Route("")]
        public async Task<bool> Logout()
        {
            await accountService.SignOutAsync();
            return true;
        }
    }
}
