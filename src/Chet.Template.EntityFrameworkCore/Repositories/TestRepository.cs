using FreeSql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chet.Template.Repositories
{
    /// <summary>
    /// Test仓储
    /// </summary>
    public class TestRepository : BaseRepository<Test, Guid>
    {
        public TestRepository(IDbContextProvider<TemplateDbContext> dbContextProvider) : base(dbContextProvider)
        {

        }

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="tests"></param>
        /// <returns></returns>
        public async Task BatchInsertAsync(IEnumerable<Test> tests)
        {
            var dbCtx = await GetDbContextAsync();
            await dbCtx.Tests.AddRangeAsync(tests);
            await dbCtx.SaveChangesAsync();
        }
    }
}
