using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Net5WebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net5WebApi.Jwt
{
    public class JwtConfig
    {
        public string Secret { get; set; }
    }

    public static class JwtExtension
    {
        // used in ConfigureServices()
        public static void AddJwt(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(jwt => {
                    var key = Encoding.ASCII.GetBytes(Configuration["JwtConfig:Secret"]);

                    jwt.SaveToken = true;
                    jwt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });

            // add support for postgresql
            bool config_UnitTestConnectionEnabled = Configuration.GetValue<bool>("UnitTestConnectionEnabled");

            string postgresConnStr = "PostgresConnection";
            if (config_UnitTestConnectionEnabled)
                postgresConnStr = "PostgresConnection_UnitTest";

            services.AddDbContext<ApiDbContext>(options =>
               options.UseNpgsql(
                   Configuration.GetConnectionString(postgresConnStr),
                   postgresOption => postgresOption.MigrationsAssembly("Net5WebApi.Data")
               ));

            // from sharpmembers
            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApiDbContext>()
            //    .AddDefaultTokenProviders();

            // from .net5 vs template project
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApiDbContext>();
        }

        // used in Configure()
        public static void UseJwt(this IApplicationBuilder app)
        {
            app.UseAuthentication();
        }
    }
}
