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
    using System.Data;
    using YJC.Toolkit.Sys;
    using YJC.Toolkit.MetaData;
    
    
    public class dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazortemplatebootcssaccountedittemplatecshtml : YJC.Toolkit.Accounting.AccountEditTemplate {
        
#line hidden
        
        public dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazortemplatebootcssaccountedittemplatecshtml() {
        }
        
        public override void Execute() {
  
    NormalEditData pageData = (NormalEditData)ViewBag.PageData;
    Tk5NormalTableData table = ViewBag.MetaData.Table;
    string title = table.TableDesc;

WriteLiteral("\r\n");

DefineSection("DefaultHeader", () => {

WriteLiteral("\r\n");

    
     if (pageData.Header != null)
    {
        
   Write(RenderRazorOutputData(pageData.Header, Model));

                                                      
    }
    else
    {

WriteLiteral("        <br />\r\n");

WriteLiteral("        <h1");

WriteLiteral(" class=\"text-center\"");

WriteLiteral(">");

                           Write(title);

WriteLiteral("</h1>\r\n");

WriteLiteral("        <br />\r\n");

    }

});

DefineSection("DefaultFooter", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

Write(RenderRazorOutputData(pageData.Footer, Model));

WriteLiteral("\r\n");

});

WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>");

      Write(title);

WriteLiteral("</title>\r\n    <meta");

WriteLiteral(" http-equiv=\"X-UA-Compatible\"");

WriteLiteral(" content=\"IE=edge\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" http-equiv=\"Content-Type\"");

WriteLiteral(" content=\"text/html; charset=utf-8\"");

WriteLiteral(" />\r\n    <meta");

WriteLiteral(" name=\"viewport\"");

WriteLiteral(" content=\"width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable" +
"=0\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/css.cshtml", null));

WriteLiteral("\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserCss());

WriteLiteral(@"
    <style>
        td {
            vertical-align: middle !important;
        }

        .pdl-1 {
            padding-left: 1.5em !important;
        }

        .pdl-2 {
            padding-left: 2.5em !important;
        }
    </style>
</head>
<body");

WriteAttribute("id", Tuple.Create(" id=\"", 1329), Tuple.Create("\"", 1378)
, Tuple.Create(Tuple.Create("", 1334), Tuple.Create<System.Object, System.Int32>(HtmlUtil.GetDynamicPageId(Model.CallerInfo)
, 1334), false)
);

WriteLiteral(" class=\"tk-dataPage\"");

WriteLiteral(" data-webpath=\"");

                                                                                     Write(HtmlUtil.AppVirtualPath);

WriteLiteral("\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(" data-toggle=\"validator\"");

WriteLiteral(">\r\n");

        
         if (pageData.ShowTitle)
        {
            
       Write(RenderSectionOrDefault("Header", "DefaultHeader"));

                                                              
        }

WriteLiteral("        ");

   Write(RenderSectionIfDefined("Main", "main.cshtml", Model));

WriteLiteral("\r\n");

WriteLiteral("        ");

   Write(RenderSectionOrDefault("Footer", "DefaultFooter"));

WriteLiteral("\r\n    </div>\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/js.cshtml", null));

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1836), Tuple.Create("\"", 1906)
, Tuple.Create(Tuple.Create("", 1842), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.edit.js".AppVirutalPath()
, 1842), false)
);

WriteLiteral("> </script>\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserJavaScript());

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        $(document).ready(function () {
            Toolkit.load('datetimepicker', function () {
                $(""#_RptDateCtrl"").each(function () {
                    var element = $(this);
                    element.datetimepicker({
                        language: 'zh-CN',
                        autoclose: true,
                        todayHighlight: false,
                        todayBtn: false,
                        startView: 3,
                        minView: 3,
                    });
                });
            });
        });
    </script>
</body>
</html>
");

        }
    }
}