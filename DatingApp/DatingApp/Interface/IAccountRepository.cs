using DatingApp.DTO;
using DatingApp.Models;
using System.Threading.Tasks;

namespace DatingApp.Interface
{
    public interface IAccountRepository
    {
        Task<bool> Register(RegisterDTO model);
        Task<bool> Login(RegisterDTO model);
        Task<bool> UserExistAsync(string email);
        Task<ApplicationUser> FindByEmail(string Email);
    }
}
