using Chet.Template.ToolKits.Base;

namespace Chet.Template.Application.Caching.Authorize
{
    public interface ITestCacheService
    {
        /// <summary>
        /// 获取Cache
        /// </summary>
        /// <returns></returns>
        Task<ServiceResult<string>> GetCacheAsync(Func<Task<ServiceResult<string>>> factory);

    }
}
