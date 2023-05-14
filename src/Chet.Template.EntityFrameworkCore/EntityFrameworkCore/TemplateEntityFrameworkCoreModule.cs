using FreeSql;
using FreeSql.Cloud;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Volo.Abp.Modularity;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Chet.Template.EntityFrameworkCore;

[DependsOn(
    typeof(TemplateDomainModule)
    )]
public class TemplateEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddSingleton(DB.Cloud); //×¢Èë FreeSqlCloud<DbEnum>
        context.Services.AddSingleton(provider => DB.Cloud.Use(DbEnum.db1)); //×¢Èë db1 IFreeSql

    }
}
