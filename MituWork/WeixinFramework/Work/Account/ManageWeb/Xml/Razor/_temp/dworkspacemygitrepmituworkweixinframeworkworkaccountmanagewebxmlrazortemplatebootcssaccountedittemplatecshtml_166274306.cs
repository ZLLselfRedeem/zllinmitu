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

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1068), Tuple.Create("\"", 1130)
, Tuple.Create(Tuple.Create("", 1075), Tuple.Create<System.Object, System.Int32>("usercss/Accounting/ReportForm.css".AppVirutalPath()
, 1075), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserCss());

WriteLiteral("\r\n</head>\r\n<body");

WriteAttribute("id", Tuple.Create(" id=\"", 1187), Tuple.Create("\"", 1236)
, Tuple.Create(Tuple.Create("", 1192), Tuple.Create<System.Object, System.Int32>(HtmlUtil.GetDynamicPageId(Model.CallerInfo)
, 1192), false)
);

WriteLiteral(" class=\"tk-dataPage\"");

WriteLiteral(" data-webpath=\"");

                                                                                     Write(HtmlUtil.AppVirtualPath);

WriteLiteral("\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"container\"");

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

WriteAttribute("src", Tuple.Create(" src=\"", 1670), Tuple.Create("\"", 1740)
, Tuple.Create(Tuple.Create("", 1676), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.edit.js".AppVirutalPath()
, 1676), false)
);

WriteLiteral("> </script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1788), Tuple.Create("\"", 1846)
, Tuple.Create(Tuple.Create("", 1794), Tuple.Create<System.Object, System.Int32>("userjs/Accounting/validator.js".AppVirutalPath()
, 1794), false)
);

WriteLiteral("> </script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 1894), Tuple.Create("\"", 1942)
, Tuple.Create(Tuple.Create("", 1900), Tuple.Create<System.Object, System.Int32>("userjs/polyfiller.js".AppVirutalPath()
, 1900), false)
);

WriteLiteral("> </script>\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserJavaScript());

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteLiteral(@">
        webshims.setOptions('forms-ext', {
            replaceUI: 'auto',
            types: 'number'
        });

        webshims.polyfill('forms forms-ext');
        $(document).ready(function () {
            Toolkit.load('datetimepicker', function () {
                $(""#_RptDateCtrl"").each(function () {
                    var element = $(this);
                    element.datetimepicker({
                        language: 'zh-CN',
                        autoclose: true,
                        todayHighlight: false,
                        todayBtn: false,
                        forceParse: false,
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
