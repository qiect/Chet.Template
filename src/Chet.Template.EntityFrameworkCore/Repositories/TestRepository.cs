using Chet.Template.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Chet.Template.Repositories
{
    /// <summary>
    /// Test仓储
    /// </summary>
    public class TestRepository : EfCoreRepository<TemplateDbContext, Test, Guid>, ITestRepository
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
