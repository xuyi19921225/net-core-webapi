using BestPracticeWeb.WebApi.Common;
using BestPracticeWeb.WebApi.IService;
using BestPracticeWeb.WebApi.Middlewares;
using BestPracticeWeb.WebApi.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BestPracticeWeb.WebApi
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
            services.AddControllers(options =>
            {
                options.Filters.Add<ValidateModelAttribute>();
                options.Filters.Add(typeof(WebApiResultAttribute));
                options.Filters.Add<ExceptionAttribute>();
                //options.RespectBrowserAcceptHeader = true;
            });

            //关闭自动验证 走过滤器进行验证
            services.Configure<ApiBehaviorOptions>(options =>
              options.SuppressModelStateInvalidFilter = true);

            services.Configure<LDAPOptions>(Configuration.GetSection("LDAP"));
            services.Configure<EncyptOptions>(Configuration.GetSection("Encypt"));
            services.Configure<JwtOptions>(Configuration.GetSection("Authentication:JwtBearer:JwtOptions"));
            //由于初始化的时候我们就需要用，所以使用Bind的方式读取配置
            //将配置绑定到JwtSettings实例中
            //JwtOptions jwtOptions = new JwtOptions();
            //Configuration.Bind("Authentication:JwtBearer:JwtOptions", jwtOptions);
            //_signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.SecretKey));
            //jwtOptions.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            JwtOptions jwtOptions = Configuration.GetSection("Authentication:JwtBearer:JwtOptions").Get<JwtOptions>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    //是否验证发行人
                    ValidateIssuer = true,
                    ValidIssuer = jwtOptions.Issuer,//发行人
                    //是否验证受众人
                    ValidateAudience = true,
                    ValidAudience = jwtOptions.Audience,//受众人
                    //是否验证密钥
                    ValidateIssuerSigningKey = true,
                    //密钥
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey)),

                    ValidateLifetime = true, //验证生命周期
                    RequireExpirationTime = true //过期时间
                };
            });

            services.AddSingleton<IJwtSerivce, JwtService>();
            services.AddSingleton<ILDAPService, LDAPService>();
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
            // 开启认证
            app.UseAuthentication();
            // 开启授权
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
