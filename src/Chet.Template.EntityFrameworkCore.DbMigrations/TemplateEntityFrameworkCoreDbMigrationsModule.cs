﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Chet.Template.EntityFrameworkCore.DbMigrations
{
    [DependsOn(
    typeof(TemplateEntityFrameworkCoreModule)
    )]
    public class TemplateEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TemplateDbContext>();
        }
    }
}