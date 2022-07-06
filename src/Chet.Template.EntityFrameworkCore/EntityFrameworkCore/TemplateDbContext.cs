using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Chet.Template.EntityFrameworkCore
{
    /// <summary>
    /// 默认启用MySQL数据库
    /// </summary>
    [ConnectionStringName("MySql")]
    public class TemplateDbContext : AbpDbContext<TemplateDbContext>
    {
        public DbSet<Test> Tests { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configure();
        }
    }
}
