using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Net5WebApi.Data;
using Net5WebApi.Jwt;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Net5WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;
        private readonly JwtConfig _jwtConfig;
        private readonly JwtGenerator _jwtGenerator;

        public TokenController(
            ApplicationDbContext context
            , UserManager<IdentityUser> userManager
            , IConfiguration config
            , IOptions<JwtConfig> jwtConfig
            , JwtGenerator jwtGenerator
        ){
            _context = context;
            _userManager = userManager;
            _config = config;
            _jwtConfig = jwtConfig.Value;
            _jwtGenerator = jwtGenerator;
        }

        [Route("/token")]
        [HttpPost]
        public async Task<IActionResult> TokenPost(string email, string password, string grant_type)
        {
            if (await IsValidUsernameAndPassword(email, password))
            {
                return new ObjectResult(await _jwtGenerator.GenerateJwtToken(email));
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<bool> IsValidUsernameAndPassword(string email, string password)
        {

            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.CheckPasswordAsync(user, password);
        }
    }
}
