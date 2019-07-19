using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Api.Business;
using CashFlow.Api.Repository;
using CashFlow.Api.Repository.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using AutoMapper;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace CashFlow.Api
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
      services
          .AddMvc()
          .AddJsonOptions(options =>
              {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
              })
          .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

      services.AddDbContext<CashFlowDbContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("CashFlowConnectionString")));

      services.AddIdentity<User, Role>()
          .AddEntityFrameworkStores<CashFlowDbContext>()
          .AddDefaultTokenProviders();

      services.AddScoped<AccountsService>();
      services.AddScoped<RecurringTransactionsService>();
      services.AddScoped<LookupsService>();

      services.Configure<IdentityOptions>(options =>
      {
        // Password settings
        options.Password.RequireDigit = true;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredUniqueChars = 6;

        // Lockout settings
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 10;
        options.Lockout.AllowedForNewUsers = true;

        // User settings
        options.User.RequireUniqueEmail = true;
      });

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

      var secret = Configuration
          .GetSection("AppSettings")
          .GetValue<string>("Secret");
      var key = Encoding.ASCII.GetBytes(secret);

      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
      .AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = new SymmetricSecurityKey(key),
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddHttpContextAccessor();

      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "../ClientApp/dist/CashFlow";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();

        app.UseHttpsRedirection();
        app.UseSpaStaticFiles(new StaticFileOptions()
        {
          ContentTypeProvider = new FileExtensionContentTypeProvider()
        });
      }

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller}/{action=Index}/{id?}");
      });

      app.UseSpa(spa =>
      {
        // To learn more about options for serving an Angular SPA from ASP.NET Core,
        // see https://go.microsoft.com/fwlink/?linkid=864501
        spa.Options.SourcePath = "../ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseAngularCliServer(npmScript: "hmr");
        }
      });
    }
  }
}
