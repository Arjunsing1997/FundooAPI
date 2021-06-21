using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using BusinessLayer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Fundoo_API_DEMO
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FundooContext>(opts => opts.UseSqlServer(Configuration["ConnectionStrings:FundooDB"]));
            services.AddControllers();
            services.AddTransient<IUserBL, UserBL>();
            services.AddTransient<IUserRL, UserRL>();

           // services.AddAuthentication(options =>
           // {
           //     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
           //     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
           //     options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
           // })

           //// Adding Jwt Bearer  
           //.AddJwtBearer(options =>
           //{
           //    options.SaveToken = true;
           //    options.RequireHttpsMetadata = false;
           //    options.TokenValidationParameters = new TokenValidationParameters()
           //    {
           //        ValidateIssuer = true,
           //        ValidateAudience = true,
           //        ValidAudience = Configuration["JWT:ValidAudience"],
           //        ValidIssuer = Configuration["JWT:ValidIssuer"],
           //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
           //    };
           //});


            services.AddSwaggerGen();
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My FundooAPI");
            });
        }
    }
}
