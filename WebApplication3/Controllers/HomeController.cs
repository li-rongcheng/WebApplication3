using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private async Task<IActionResult> Foo()
        {
            #region [MCN] 仅仅想看一下 this 里有哪些有用的东西
            var ctx = this.Request.Cookies;
            var hasFormContentType = this.Request.HasFormContentType;
            var statusCode = this.Response.StatusCode;

            var identies = this.User.Identities;
            var identity = this.User.Identity;

            var features = this.HttpContext.Features;
            var tempdata = this.TempData;
            #endregion

            #region [MCN] 简单的硬编码登录例子
            const string Issuer = "https://gov.uk";

            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Andrew", ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Surname, "Lock", ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.Country, "UK", ClaimValueTypes.String, Issuer),
                new Claim("ChildhoodHero", "Ronnie James Dio", ClaimValueTypes.String)
            };

            var userIdentity = new ClaimsIdentity(claims, "Passport");

            var userPrincipal = new ClaimsPrincipal(userIdentity);

            await HttpContext.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = false
                });
            #endregion

            return View();
        }

        /** [MCN] GenerateJwtToken() */
        private string GenerateJwtToken(string secret, string userId, int expireDays)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId)
                }),
                Expires = DateTime.UtcNow.AddDays(expireDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
