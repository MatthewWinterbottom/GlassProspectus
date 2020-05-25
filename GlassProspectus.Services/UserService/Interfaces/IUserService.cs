using GlassProspectus.Services.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GlassProspectus.Services.UserService.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUserAsync(IdentityUser user, string password);
        bool UpdateUserAsync(IdentityUser user);
        bool DeleteUserAsync(int userId);
        IdentityUser GetUserFromViewModel(UserRegisterViewModel user);
    }
}
