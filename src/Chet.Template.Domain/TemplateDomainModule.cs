using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Chet.Template;

[DependsOn(
    typeof(TemplateDomainSharedModule),
    typeof(AbpIdentityDomainModule)
)]
public class TemplateDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
