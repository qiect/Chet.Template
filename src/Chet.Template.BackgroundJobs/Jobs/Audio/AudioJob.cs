using Chet.Template.Audio;
using Chet.Template.Enum;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chet.Template.BackgroundJobs.Jobs.Audio
{
    public class AudioJob : IBackgroundJob
    {
        public async Task ExecuteAsync()
        {
            var urlList = new List<AudioJobItem<string>>
            {
                new AudioJobItem<string>{ Result="https://music.163.com/#/album?id=2882052",Type=AudioEnum.TangShi },
            };

            var web = new HtmlWeb();
            var list_task = new List<Task<AudioJobItem<HtmlDocument>>>();

            urlList.ForEach(item =>
            {
                var task = Task.Run(async () =>
                {
                    var htmlDocument = await web.LoadFromWebAsync(item.Result);
                    return new AudioJobItem<HtmlDocument>
                    {
                        Result = htmlDocument,
                        Type = item.Type
                    };
                });
                list_task.Add(task);
            });
            Task.WaitAll(list_task.ToArray());

        }
    }
}
