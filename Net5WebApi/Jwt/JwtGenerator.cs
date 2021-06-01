using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Net5WebApi.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Net5WebApi.Jwt
{
    /// <summary>
    /// The 2 GenerateJwtToken() should have the same effect
    /// </summary>
    public class JwtGenerator
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly JwtConfig _jwtConfig;

        public JwtGenerator(UserManager<IdentityUser> userManager, ApplicationDbContext context, JwtConfig jwtConfig)
        {
            _userManager = userManager;
            _context = context;
            _jwtConfig = jwtConfig;
        }

        // implementation 1: use SecurityTokenDescriptor
        public string GenerateJwtToken(IdentityUser user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())   // JTI is for refresh token

                //new Claim(ClaimTypes.Name, user.UserName),
                //new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            };
            AddRoleInfoToClaim(claims, user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = jwtTokenHandler.WriteToken(token);

            return jwtToken;
        }

        // implementation 2: use JwtHeader and JwtPayload
        public async Task<dynamic> GenerateJwtToken(string username)
        {
            var user = await _userManager.FindByEmailAsync(username);

            // add claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())

                //new Claim(ClaimTypes.Name, username ),
            };
            AddRoleInfoToClaim(claims, user);

            // generate token
            var key = Encoding.UTF8.GetBytes(_jwtConfig.Secret);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(new JwtHeader(signingCredentials),new JwtPayload(claims));

            return new
            {
                Access_Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserName = username
            };
        }

        private void AddRoleInfoToClaim(List<Claim> claims, IdentityUser user)
        {
            var roles = from userRole in _context.UserRoles
                        join role in _context.Roles on userRole.RoleId equals role.Id
                        where userRole.UserId == user.Id
                        select new { userRole.UserId, userRole.RoleId, role.Name };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
        }
    }
}
