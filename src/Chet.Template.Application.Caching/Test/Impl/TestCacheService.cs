using Chet.Template.ToolKits.Base;
using Chet.Template.ToolKits.Extensions;

namespace Chet.Template.Application.Caching.Authorize.Impl
{
    public class TestCacheService : CachingServiceBase, ITestCacheService
    {
        private const string KEY_GetCache = "Test:GetCache";

        /// <summary>
        /// 获取Cache1
        /// </summary>
        /// <param name="factory"></param>
        /// <returns></returns>
        public async Task<ServiceResult<string>> GetCacheAsync(Func<Task<ServiceResult<string>>> factory)
        {
            return await Cache.GetOrAddAsync(KEY_GetCache, factory, CacheStrategy.NEVER);
        }

    }
}
