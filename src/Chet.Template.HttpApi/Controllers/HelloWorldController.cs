using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Chet.Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiExplorerSettings(GroupName = Grouping.GroupName_Other)]
    public class HelloWorldController : AbpController
    {
        private readonly IHelloWorldService _helloWorldService;

        public HelloWorldController(IHelloWorldService helloWorldService)
        {
            _helloWorldService = helloWorldService;
        }

        [HttpGet]
        public string HelloWorld()
        {
            return _helloWorldService.HelloWorld();
        }
    }
}
