using Chet.Template.BackgroundJobs;
using Chet.Template.EntityFrameworkCore;
using Chet.Template.Filters;
using Chet.Template.Middleware;
using Chet.Template.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.ExceptionHandling;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Chet.Template.Web;

[DependsOn(
       typeof(AbpAspNetCoreMvcModule),
       typeof(AbpAutofacModule),
       typeof(TemplateHttpApiModule),
       typeof(TemplateSwaggerModule),
       typeof(TemplateEntityFrameworkCoreModule),
       typeof(TemplateBackgroundJobsModule)
    )]
public class TemplateHttpApiHostingModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //异常处理
        Configure<MvcOptions>(options =>
        {
            var filterMetadata = options.Filters.FirstOrDefault(x => x is ServiceFilterAttribute attribute && attribute.ServiceType.Equals(typeof(AbpExceptionFilter)));

            // 移除 AbpExceptionFilter
            options.Filters.Remove(filterMetadata);
            options.Filters.Add(typeof(TemplateExceptionFilter));
        });

        //路由规则配置
        context.Services.AddRouting(options =>
        {
            // 设置URL为小写
            options.LowercaseUrls = true;
            // 在生成的URL后面添加斜杠
            options.AppendTrailingSlash = true;
        });
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

        // 异常处理中间件
        app.UseMiddleware<ExceptionHandlerMiddleware>();

        //app.UseHsts();//使用HSTS的中间件，该中间件添加了严格传输安全头
        //app.UseCors();//使用默认的跨域配置
        //app.UseHttpsRedirection();//HTTP请求转HTTPS

        // 路由映射
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
