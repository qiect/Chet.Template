namespace Chet.Template.EntityFrameworkCore.DbMigrations
{
    public class TemplateDbMigrationsDbContext : AbpDbContext<TemplateDbMigrationsDbContext>
    {
        public TemplateDbMigrationsDbContext(DbContextOptions<TemplateDbMigrationsDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Configure();
        }
    }
}
