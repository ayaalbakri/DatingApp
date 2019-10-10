
using DatingApp.DTO;
using DatingApp.Interface;
using DatingApp.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Items.Infrastructure.Repository.AccountRepo
{
    class AccountRepository : IAccountRepository
    {
        public static string name, location;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signManager;
        private RoleManager<Role> _roleManager;
        // private IRandomPassword _iRandomPassword;
        private IUnitOfWork _unitOfWork;
        private IdentityResult roleResult;

        public AccountRepository(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, RoleManager<Role> roleManager,
            IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signManager = signInManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Register(RegisterDTO model)
        {
            var user = new ApplicationUser { UserName = model.UserName, Email = model.Email };

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            //if (result.Succeeded & model.RoleName != null)
            //{

            //    roleResult = await AssignUserToRoleAsync(user, model.RoleName);

            //}
            return result.Succeeded;

        }
        public async Task<bool> Login(RegisterDTO model)
        {
            var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            // Console.WriteLine(result);
            return result.Succeeded;
        }

        //public async void Lout()
        //{
        //    await _signManager.SignOutAsync();

        //}
        public async Task<ApplicationUser> FindByEmail(string Email)
        {
            return await _userManager.FindByNameAsync(Email);
        }

        //public async Task<string> FindRole(string email)
        //{
        //    var user = await FindByEmail(email);
        //    IList<string> roles = await _userManager.GetRolesAsync(user);

        //    return roles.FirstOrDefault();
        //}

        //public List<string> GetAllRolesAsync()
        //{

        //    return _roleManager.Roles.Select(r => r.Name).ToList();
        //}
        public async Task<bool> UserExistAsync(string email)
        {

            return await FindByEmail(email) != null;

        }

        //public async Task<bool> RoleExistAsync(string roleName)
        //{

        //    return await _roleManager.RoleExistsAsync(roleName);
        //}

        //public async Task<IdentityResult> AssignUserToRoleAsync(ApplicationUser user, string RoleName)
        //{

        //    return await _userManager.AddToRoleAsync(user, RoleName);
        //}

        //public List<ApplicationUser> GetAllUsers()
        //{
        //    return _userManager.Users.ToList();

        //}

        //public async Task<string> GetUserRoleAsync(string email)
        //{
        //    ApplicationUser user = await _userManager.FindByEmailAsync(email);
        //    return _userManager.GetRolesAsync(user).Result.FirstOrDefault();
        //}


        //public async Task UpdateUserByIdAsync(UpdateUserDTO userDTO)
        //{
        //    var user = await _userManager.FindByIdAsync(userDTO.Id);
        //    user.FirstName = userDTO.FirstName;
        //    user.LastName = userDTO.LastName;
        //    user.ProfileImage = userDTO.ProfileImage;
        //    await _userManager.UpdateAsync(user);
        //}

        //public async Task<ApplicationUser> GetUserByIdAsync(string id)
        //{
        //    return await _userManager.FindByIdAsync(id);
        //}

        //public async Task DeleteUserAsync(string id)
        //{
        //    var user = await GetUserByIdAsync(id);
        //    var result = await _userManager.DeleteAsync(user);
        //}

        //public async Task<string> GetroleIdByEmailAsync(string roleName)
        //{
        //    Role role = await _roleManager.FindByNameAsync(roleName);
        //    return role.Id.ToString();
        //}

        //public List<Permision> GetAllPermissions()
        //{
        //    return _unitOfWork.Context.Set<Permision>().ToList();
        //}

        //public void UpdateRolePermission(List<RolePermission> permissions)
        //{

        //    _unitOfWork.Context.Set<RolePermission>().UpdateRange(permissions);
        //}
        //public async Task<bool> roleExistAsync(string id)
        //{

        //    return await _roleManager.FindByIdAsync(id) != null;
        //}
    }
}
