using FreeSql.Extensions.EfCoreFluentApi;

namespace Chet.Template.EntityTypeConfiguration
{
    public class TestConfiguration : IEntityTypeConfiguration<Test>
    {
        public void Configure(EfCoreTableFluent<Test> eb)
        {
            //eb.ToTable("tb_song1");
            //eb.Ignore(a => a.Field1);
            //eb.Property(a => a.Title).HasColumnType("varchar(50)").IsRequired();
            //eb.Property(a => a.Url).HasMaxLength(100);

            //eb.Property(a => a.RowVersion).IsRowVersion();
            //eb.Property(a => a.CreateTime).HasDefaultValueSql("current_timestamp");

            //eb.HasKey(a => a.Id);
            //eb.HasIndex(a => a.Title).IsUnique().HasName("idx_tb_song1111");

            ////一对多、多对一
            //eb.HasOne(a => a.Type).HasForeignKey(a => a.TypeId).WithMany(a => a.Songs);

            ////多对多
            //eb.HasMany(a => a.Tags).WithMany(a => a.Songs, typeof(Song_tag));
        }
    }


}
