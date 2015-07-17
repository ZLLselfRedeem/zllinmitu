using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//该程序集定义了一个可以将插件插入可扩展Windows窗口应用程序中的类型模板。
namespace CommonSnappable
{
    //为所有插件提供一个多态接口
    public interface IAppFunctionality
    {
        void DoIt();
    }

    //允许插件的开发者提供一些关于组件来源的基本细节
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CompanyInfoAttribute : System.Attribute
    {
        public string CompanyName { get; set; }
        public string CompanyUrl { get; set; }
    }
}
