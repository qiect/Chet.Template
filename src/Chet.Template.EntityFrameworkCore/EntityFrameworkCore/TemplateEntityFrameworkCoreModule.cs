using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Chet.Template.EntityFrameworkCore;

[DependsOn(
    typeof(TemplateDomainModule),
    typeof(AbpEntityFrameworkCoreMySQLModule)
    )]
public class TemplateEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also TemplateMigrationsDbContextFactory for EF Core tooling. */
            options.UseMySQL();
        });
    }
}
