//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace YJC.Toolkit.Razor.Dynamic {
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using YJC.Toolkit.Razor;
    using YJC.Toolkit.Web;
    
    
    public class drepgitmanagermituworkmituservertestmanagewebxmlrazortemplatebootcsscustomtemplatecshtml : YJC.Toolkit.Razor.NormalCustomTemplate {
        
#line hidden
        
        public drepgitmanagermituworkmituservertestmanagewebxmlrazortemplatebootcsscustomtemplatecshtml() {
        }
        
        public override void Execute() {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>");

      Write(ViewBag.Title);

WriteLiteral("</title>\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"Content-Type\"");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable" +
"=0;\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/css.cshtml", null));

WriteLiteral(" \r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserCss());

WriteLiteral("\r\n</head>\r\n<body");

WriteLiteral(" data-webPath=\"");

               Write(HtmlUtil.AppVirtualPath);

WriteLiteral("\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

   Write(RenderSectionIfDefined("Header"));

WriteLiteral("\r\n");

WriteLiteral("        ");

   Write(RenderSectionIfDefined("Main"));

WriteLiteral("\r\n");

WriteLiteral("        ");

   Write(RenderSectionIfDefined("Footer"));

WriteLiteral("\r\n    </div>\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/js.cshtml", null));

WriteLiteral("\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserJavaScript());

WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
