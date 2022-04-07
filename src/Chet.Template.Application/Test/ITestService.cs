using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chet.Template
{
    public interface ITestService
    {
        Task<bool> InsertTestAsync(TestDto dto);

        Task<bool> DeleteTestAsync(Guid id);

        Task<bool> UpdateTestAsync(Guid id, TestDto dto);

        Task<TestDto> GetTestAsync(Guid id);
    }
}
