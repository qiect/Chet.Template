using System;
using Volo.Abp.Domain.Entities;

namespace Chet.Template
{
    public class Test : Entity<Guid>
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
