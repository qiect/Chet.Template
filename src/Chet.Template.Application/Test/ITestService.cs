using Chet.Template.ToolKits.Base;
namespace Chet.Template
{
    public interface ITestService
    {
        //Task<bool> InsertTestAsync(TestDto dto);
        Task<ServiceResult<string>> InsertTestAsync(TestDto dto);


        //Task<bool> DeleteTestAsync(Guid id);
        Task<ServiceResult> DeleteTestAsync(Guid id);


        //Task<bool> UpdateTestAsync(Guid id, TestDto dto);
        Task<ServiceResult<string>> UpdateTestAsync(Guid id, TestDto dto);


        //Task<TestDto> GetTestAsync(Guid id);
        Task<ServiceResult<TestDto>> GetTestAsync(Guid id);

    }
}
