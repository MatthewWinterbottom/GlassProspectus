using GlassProspectus.Repository;
using GlassProspectus.Services.UserService.Interfaces;
using GlassProspectus.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GlassProspectus.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UniDbContext uniDbContext;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UserService(UniDbContext uniDbContext,
                           UserManager<IdentityUser> userManager,
                           SignInManager<IdentityUser> signInManager)
        {
            this.uniDbContext = uniDbContext;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<bool> CreateUserAsync(IdentityUser user, string password)
        {
            var createUserResult = await userManager.CreateAsync(user, password);

            return createUserResult.Succeeded;
        }

        public bool DeleteUserAsync(int userId)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateUserAsync(IdentityUser user)
        {
            throw new System.NotImplementedException();
        }


        public IdentityUser GetUserFromViewModel(UserRegisterViewModel user) =>
            new IdentityUser
            {
                UserName = user.Email,
                Email = user.Email,
            };
    }
}
