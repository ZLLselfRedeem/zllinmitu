using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Razor;

namespace YJC.Toolkit.Accounting
{
    [RazorTemplate(@"BootCss\AccountEdit\template.cshtml", Author = "YJC", CreateDate = "2015-07-06", 
        PageDataType = typeof(NormalEditData), Description = "基于Bootstrap的普通Edit页面")]
    [RequireAssembly("YJC.Toolkit.Accounting.dll")]
    public class AccountEditTemplate : BaseToolkitTemplate
    {
        public AccountEditTemplate()
        {
            BaseType = typeof(AccountEditTemplate);
        }
    }
}
