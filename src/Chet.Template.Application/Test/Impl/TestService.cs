using Chet.Template.Repositories;
using System;
using System.Threading.Tasks;

namespace Chet.Template
{
    public class TestService : ServiceBase, ITestService
    {
        private readonly ITestRepository _testRepository;

        public TestService(ITestRepository testRepository)
        {
            this._testRepository = testRepository;
        }

        public async Task<bool> DeleteTestAsync(Guid id)
        {
            await _testRepository.DeleteAsync(id);
            return true;
        }

        public async Task<TestDto> GetTestAsync(Guid id)
        {
            var entity = await _testRepository.GetAsync(id);
            return new TestDto()
            {
                Name = entity.Name,
                Remark = entity.Remark
            };
        }

        public async Task<bool> InsertTestAsync(TestDto dto)
        {
            var entity = new Test()
            {
                Name = dto.Name,
                Remark = dto.Remark
            };
            var test = await _testRepository.InsertAsync(entity);
            return test != null;
        }

        public async Task<bool> UpdateTestAsync(Guid id, TestDto dto)
        {
            var entity = await _testRepository.GetAsync(id);
            entity.Name = dto.Name;
            entity.Remark = dto.Remark;
            await _testRepository.UpdateAsync(entity);
            return true;
        }
    }
}
