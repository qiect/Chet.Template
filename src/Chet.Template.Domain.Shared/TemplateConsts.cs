using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chet.Template
{
    /// <summary>
    /// 全局常量
    /// </summary>
    public class TemplateConsts
    {
        /// <summary>
        /// 数据库表前缀
        /// </summary>
        public const string DbTablePrefix = "chet_";
    }

    /// <summary>
    /// 分组
    /// </summary>
    public static class Grouping
    {
        /// <summary>
        /// Test前台接口组
        /// </summary>
        public const string GroupName_Front = "v1";

        /// <summary>
        /// Test后台接口组
        /// </summary>
        public const string GroupName_Admin = "v2";

        /// <summary>
        /// 其他通用接口组
        /// </summary>
        public const string GroupName_Other = "v3";

        /// <summary>
        /// JWT授权接口组
        /// </summary>
        public const string GroupName_JWT = "v4";
    }
}
