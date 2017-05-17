using Firebase.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FirebaseExample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.Map("/api", a =>
            {
                a.UseJwtBearerAuthentication(new JwtBearerOptions
                {
                    AutomaticAuthenticate = true,
                    IncludeErrorDetails = true,
                    Authority = "https://securetoken.google.com/{project-id}",
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "https://securetoken.google.com/{project-id}",
                        ValidateAudience = true,
                        ValidAudience = "{project-id}",
                        ValidateLifetime = true
                    }
                });
                a.UseMvc();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
