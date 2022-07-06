using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using static Chet.Template.TemplateDbConsts;

namespace Chet.Template.EntityFrameworkCore
{
    public static class TemplateDbContextModelCreatingExtensions
    {
        public static void Configure(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));
            builder.Entity<Test>(p =>
            {
                p.ToTable(TemplateConsts.DbTablePrefix + DbTableName.Tests);
                p.HasKey(t => t.Id);
                p.Property(p => p.Name).HasMaxLength(200).IsRequired();
                p.Property(p => p.Remark).HasColumnType("longtext");
            });
        }
    }
}
