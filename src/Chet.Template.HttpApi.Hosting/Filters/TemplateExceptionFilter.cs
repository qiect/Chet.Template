using Chet.Template.ToolKits.log4net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Chet.Template.Filters
{
    public class TemplateExceptionFilter: IExceptionFilter
    {
        /// <summary>
        /// 异常处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public void OnException(ExceptionContext context)
        {
            // 日志记录
            LoggerHelper.WriteToFile($"{context.HttpContext.Request.Path}|{context.Exception.Message}", context.Exception);
        }
    }
}
