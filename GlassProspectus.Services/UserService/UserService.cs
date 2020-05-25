using GlassProspectus.Services.UserService.Interfaces;
using GlassProspectus.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GlassProspectus.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> userManager;

        public UserService(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
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
