using Volo.Abp.Modularity;

namespace Chet.Template;

[DependsOn(
    typeof(TemplateDomainSharedModule)
)]
public class TemplateApplicationContractsModule : AbpModule
{

}
