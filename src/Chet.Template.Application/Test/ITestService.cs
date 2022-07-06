using Chet.Template.ToolKits.Base;
namespace Chet.Template
{
    /// <summary>
    /// Test服务接口
    /// </summary>
    public interface ITestService
    {
        /// <summary>
        /// 插入Test
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> InsertTestAsync(TestDto dto);

        /// <summary>
        /// 删除Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult> DeleteTestAsync(Guid id);

        /// <summary>
        /// 修改Test
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<ServiceResult<string>> UpdateTestAsync(Guid id, TestDto dto);

        /// <summary>
        /// 获取Test
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ServiceResult<TestDto>> GetTestAsync(Guid id);

    }
}
