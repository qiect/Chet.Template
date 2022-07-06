using Chet.Template.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Chet.Template.Swagger
{
    public static class TemplateSwaggerExtensions
    {
        /// <summary>
        /// 当前API版本，从appsettings.json获取
        /// </summary>
        private static readonly string version = $"v{AppSettings.ApiVersion}";

        /// <summary>
        /// Swagger描述信息
        /// </summary>
        private static readonly string description = @"<b>Hangfire</b>：<a target=""_blank"" href=""/hangfire"">任务调度中心</a> <code>Powered by .NET 6.0 on Linux</code>";


        /// <summary>
        /// Swagger分组信息，将进行遍历使用
        /// </summary>
        private static readonly List<SwaggerApiInfo> ApiInfos = new List<SwaggerApiInfo>()
        {
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_Front,
                Name = "Chet.Template - 前台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "Chet.Template - 前台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_Admin,
                Name = "Chet.Template - 后台接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "Chet.Template - 后台接口",
                    Description = description
                }
            },
            new SwaggerApiInfo
            {
                UrlPrefix = Grouping.GroupName_Other,
                Name = "Chet.Template - 通用公共接口",
                OpenApiInfo = new OpenApiInfo
                {
                    Version = version,
                    Title = "Chet.Template - 通用公共接口",
                    Description = description
                }
            }
        };

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            return services.AddSwaggerGen(options =>
            {
                // 遍历并应用Swagger分组信息
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerDoc(x.UrlPrefix, x.OpenApiInfo);
                });

                // 应用Controller的API文档描述信息
                //options.DocumentFilter<SwaggerDocumentFilter>();

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Chet.Template.HttpApi.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Chet.Template.Domain.xml"));
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Chet.Template.Application.Contracts.xml"));
            });
        }

        public static void UseSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(options =>
            {
                // 遍历分组信息，生成Json
                ApiInfos.ForEach(x =>
                {
                    options.SwaggerEndpoint($"/swagger/{x.UrlPrefix}/swagger.json", x.Name);
                    // 模型的默认扩展深度，设置为 -1 完全隐藏模型
                    options.DefaultModelsExpandDepth(-1);
                    // API文档仅展开标记
                    options.DocExpansion(DocExpansion.List);
                    // API前缀设置为空
                    options.RoutePrefix = string.Empty;
                    // API页面Title
                    options.DocumentTitle = "Chet.Template";
                });

            });
        }



        internal class SwaggerApiInfo
        {
            /// <summary>
            /// URL前缀
            /// </summary>
            public string UrlPrefix { get; set; }

            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// <see cref="Microsoft.OpenApi.Models.OpenApiInfo"/>
            /// </summary>
            public OpenApiInfo OpenApiInfo { get; set; }
        }
    }

}
