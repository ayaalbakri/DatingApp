using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DatingApp.Helper
{
    public class GenarateToken
    {
        private IConfiguration _config;

        public GenarateToken(IConfiguration config)
        {
            _config = config;
        }
        public JwtSecurityToken CreateToken(string email, Guid id, string userName)
        {
            var expires = DateTime.Now.AddDays(2);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                    new Claim("Email", email),
                    new Claim("Id",id.ToString()),
                    new Claim("UserName",userName),
                    //new Claim(ClaimsIdentity.DefaultRoleClaimType,role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
               claims: claims,
               expires: expires,
              signingCredentials: creds);

            return token;
        }
    }
}
