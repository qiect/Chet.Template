using Chet.Template.Configurations;
using Chet.Template.EntityFrameworkCore;
using Chet.Template.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Chet.Template.Web;

[DependsOn(
       typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAutofacModule),
       typeof(TemplateHttpApiModule),
       typeof(TemplateSwaggerModule),
       typeof(TemplateEntityFrameworkCoreModule)
    )]
public class TemplateHttpApiHostingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        // 身份验证
        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,//是否验证颁发者
                       ValidateAudience = true,//是否验证访问群体
                       ValidateLifetime = true,//是否验证生存期
                       ClockSkew = TimeSpan.FromSeconds(30),//验证Token的时间偏移量
                       ValidateIssuerSigningKey = true,//是否验证安全密钥
                       ValidAudience = AppSettings.JWT.Domain,//访问群体
                       ValidIssuer = AppSettings.JWT.Domain,//颁发者
                       IssuerSigningKey = new SymmetricSecurityKey(AppSettings.JWT.SecurityKey.GetBytes())//安全密钥
                   };
               });

        // 认证授权
        context.Services.AddAuthorization();

        // Http请求
        context.Services.AddHttpClient();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        // 环境变量，开发环境
        if (env.IsDevelopment())
        {
            // 生成异常页面
            app.UseDeveloperExceptionPage();
        }


        // 路由
        app.UseRouting();

        // 身份验证
        app.UseAuthentication();

        // 认证授权
        app.UseAuthorization();

        // 路由映射
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
