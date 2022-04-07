﻿using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Chet.Template;

[DependsOn(
    typeof(AbpIdentityApplicationModule)
    )]
public class TemplateApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<TemplateApplicationModule>();
        });
    }
}