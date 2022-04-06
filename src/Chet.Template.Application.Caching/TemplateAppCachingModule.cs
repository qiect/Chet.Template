using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace Chet.Template.Application.Caching
{
    [DependsOn(
    typeof(AbpCachingModule),
    typeof(TemplateDomainSharedModule)
    )]
    public class TemplateAppCachingModule : AbpCachingModule
    {
    }
}
