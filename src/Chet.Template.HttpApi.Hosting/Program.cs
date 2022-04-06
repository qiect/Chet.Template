using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Chet.Template.Web;

public class Program
{
    public async static Task Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);
        builder.Host.UseAutofac();
        await builder.AddApplicationAsync<TemplateHttpApiHostingModule>();
        var app = builder.Build();
        await app.InitializeApplicationAsync();
        await app.RunAsync();

    }
}
