using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Chet.Template;

[DependsOn(
    typeof(AbpIdentityHttpApiModule),
    typeof(TemplateApplicationModule)
    )]
public class TemplateHttpApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
       
    }

}
