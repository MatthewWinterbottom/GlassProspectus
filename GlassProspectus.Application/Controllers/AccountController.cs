using GlassProspectus.Services.AccountService.Interfaces;
using GlassProspectus.Services.UserService.Interfaces;
using GlassProspectus.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GlassProspectus.Application.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService userService;
        private readonly IAccountService accountService;

        public AccountController(IUserService userService,
                                 IAccountService accountService)
        {
            this.userService = userService;
            this.accountService = accountService;
        }

        [HttpGet]
        public IActionResult Register()
        {




            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                // Bind viewmodel to IdentityUserModel
                var identityUser = userService.GetUserFromViewModel(user);

                var successStatus = await userService.CreateUserAsync(identityUser, user.Password); // Create a User

                if (successStatus)
                {
                    await accountService.SignInAsync(identityUser, true);
                }
            } 
            
            return View();
        }
    }
}
