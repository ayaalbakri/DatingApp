
using DatingApp.DTO;
using DatingApp.Helper;
using DatingApp.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Items.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        // GET: api/Account
        private readonly IConfiguration _config;
        private readonly GenarateToken _genarateToken;

        //private readonly IMapper _mapper;
        private readonly IAccountRepository _accountRepository;

        public string role;

        public AccountController(/*IMapper mapper,*/ IAccountRepository accountRepository, IConfiguration config, GenarateToken genarateToken)
        {
            // _mapper = mapper;

            _accountRepository = accountRepository;
            _config = config;
            _genarateToken = genarateToken;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("wer");
        }

        [HttpGet("Claims")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Users()
        {
            var exp = User.Claims;
            if (!User.Claims.Any(c => c.Type == "Email"))
            {
                return BadRequest("Somthing Wrong please try to log in Again");

            }
            var email = User.Claims.FirstOrDefault(c => c.Type == "Email").Value;
            // StringBuilder builder = new StringBuilder();
            //builder.Append
            return Ok(email);

        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> UserInfoAsync(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        return BadRequest("Id can't be null");
        //    }
        //    var user = await _accountRepository.GetUserByIdAsync(id);
        //    if (user == null)
        //    {
        //        return BadRequest("user not found");
        //    }
        //    var userDTO = _mapper.Map<ApplicationUserDTO>(user);
        //    userDTO.RoleName = _accountRepository.GetUserRoleAsync(userDTO.Email).Result;
        //    if (string.IsNullOrEmpty(userDTO.RoleName))
        //    {
        //        return BadRequest("user Role Not found");
        //    }
        //    return Ok(userDTO);

        //}
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin,Q&E Manager")]
        [HttpPost]
        public async Task<IActionResult> registerAsync([FromBody]RegisterDTO model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (await _accountRepository.UserExistAsync(model.Email))
            {
                return StatusCode(StatusCodes.Status409Conflict, "User with Same Email Allready Exist");

            }
            if (await _accountRepository.Register(model))
            {
                //ClaimsIdentity.DefaultRoleClaimType
                var expires = DateTime.Now.AddDays(2);
                var token = _genarateToken.CreateToken(model.Email, new Guid(), model.UserName);

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            else
            {
                return NotFound("Error Occurred While Adding User");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> register([FromBody]RegisterDTO model)
        {
            bool result = await _accountRepository.Login(model);
            if (result)
            {
                var user = await _accountRepository.FindByEmail(model.Email);
                var expires = DateTime.Now.AddDays(2);
                var token = _genarateToken.CreateToken(model.Email, user.Id, user.UserName);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), Exp = expires, UserInf = new ApplicationUserDTO { Email = model.Email, Id = user.Id, userName = user.UserName } });
            }
            else
            {
                return NotFound("user Not Found");
            }

        }

        //[HttpGet("Roles")]
        //public IActionResult GetAllRoles()
        //{
        //    var Roles = _accountRepository.GetAllRolesAsync();
        //    return Ok(Roles);
        //}

        //[HttpGet("Users")]
        //public IActionResult GetAllUsers()
        //{

        //    var users = _accountRepository.GetAllUsers();
        //    var usersDTO = _mapper.Map<List<ApplicationUserDTO>>(users);
        //    usersDTO.ForEach(e => e.RoleName = _accountRepository.GetUserRoleAsync(e.Email).Result);
        //    return Ok(usersDTO);
        //}
        //[HttpGet("Permisions")]
        //public IActionResult GetAllPermisions()
        //{
        //    var permissions = _accountRepository.GetAllPermissions();
        //    return Ok(_mapper.Map<List<PermissionDTO>>(permissions));
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateUserAsync([FromBody]UpdateUserDTO updateUserDTO)
        //{
        //    //var users = _mapper.Map<ApplicationUser>(updateUserDTO);
        //    if (updateUserDTO.ProfileImageInf != null)
        //    {
        //        var file = updateUserDTO.ProfileImageInf.FilePath.Split(new char[] { ',' }, 2)[1];
        //        updateUserDTO.ProfileImageInf.FilePath = file;
        //        var profileImage = await _imageRepository.UploadeImageAsync(updateUserDTO.ProfileImageInf);
        //        updateUserDTO.ProfileImage = profileImage;

        //        await _accountRepository.UpdateUserByIdAsync(updateUserDTO);
        //    }
        //    await _accountRepository.UpdateUserByIdAsync(updateUserDTO);
        //    return Ok("User Updated Succ.");
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteUserAsync(string id)
        //{
        //    await _accountRepository.DeleteUserAsync(id);
        //    return Ok("User Deleted Successfully");
        //}

        //[HttpPost("lout")]
        //public IActionResult Lout()
        //{
        //    _accountRepository.Lout();
        //    return Ok("User Update Successfully");
        //}
        //[HttpPut("Permissions/RoleId:{roleId}")]
        //public async Task<IActionResult> UpdatePermissionAsync(string roleId, [FromBody] List<RolePermission> permissions)
        //{
        //    if (permissions.Any(r => r.RoleId.ToString() != roleId))
        //    {
        //        return BadRequest("Role Id isn't correct");
        //    }
        //    if (!await _accountRepository.roleExistAsync(roleId))
        //    {
        //        return NotFound("Role Not Exist");
        //    }
        //    _accountRepository.UpdateRolePermission(permissions);
        //    return Ok("User Update Successfully");
        //}
    }
}
