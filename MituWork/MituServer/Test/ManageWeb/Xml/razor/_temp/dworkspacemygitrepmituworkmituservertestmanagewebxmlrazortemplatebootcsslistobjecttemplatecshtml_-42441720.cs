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
    using YJC.Toolkit.Data;
    using YJC.Toolkit.Sys;
    
    
    public class dworkspacemygitrepmituworkmituservertestmanagewebxmlrazortemplatebootcsslistobjecttemplatecshtml : YJC.Toolkit.Razor.NormalObjectListTemplate {
        
#line hidden
        
        public dworkspacemygitrepmituworkmituservertestmanagewebxmlrazortemplatebootcsslistobjecttemplatecshtml() {
        }
        
        public override void Execute() {
  
    NormalListData pageData = (NormalListData)ViewBag.PageData;
    ObjectListModel listModel = (ObjectListModel)Model;

WriteLiteral("\r\n");

DefineSection("DefaultHeader", () => {

WriteLiteral("\r\n");

    
     if (pageData.Header != null)
    {
        
   Write(RenderRazorOutputData(pageData.Header, Model));

                                                      
    }
    else
    {

WriteLiteral("        <h1>");

       Write(ViewBag.Title);

WriteLiteral("</h1>\r\n");

    }

});

DefineSection("DefaultFooter", () => {

WriteLiteral("\r\n");

WriteLiteral("    ");

Write(RenderRazorOutputData(pageData.Footer, Model));

WriteLiteral("\r\n");

});

DefineSection("DefaultListButton", () => {

WriteLiteral("\r\n");

    
     if (BootcssUtil.HasListButtons(listModel) || pageData.ShowExportExcel)
    {

WriteLiteral("        <div");

WriteLiteral(" class=\"panel panel-info\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"panel-body\"");

WriteLiteral(">\r\n");

                
                 if (BootcssUtil.HasListButtons(listModel))
                {
                    
               Write(BootcssUtil.CreateListButtons(listModel));

                                                             
                }

WriteLiteral("                ");

                 if (pageData.ShowExportExcel)
                {
                    
               Write(BootcssUtil.CreateExcelButton());

                                                    
                }

WriteLiteral("            </div>\r\n        </div>\r\n");

    }

});

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

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1533), Tuple.Create("\"", 1596)
, Tuple.Create(Tuple.Create("", 1540), Tuple.Create<System.Object, System.Int32>("toolkitcss/v5/commonM/datalist.css".AppVirutalPath()
, 1540), false)
);

WriteLiteral(" />\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserCss());

WriteLiteral("\r\n</head>\r\n<body");

WriteAttribute("id", Tuple.Create(" id=\"", 1653), Tuple.Create("\"", 1706)
, Tuple.Create(Tuple.Create("", 1658), Tuple.Create<System.Object, System.Int32>(HtmlUtil.GetDynamicPageId(listModel.CallerInfo)
, 1658), false)
);

WriteLiteral(" class=\"tk-dataPage\"");

WriteLiteral(" data-webpath=\"");

                                                                                         Write(HtmlUtil.AppVirtualPath);

WriteLiteral("\"");

WriteLiteral(" data-dialog-height=\"");

                                                                                                                                       Write(pageData.DialogHeight);

WriteLiteral("\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n");

        
         if (pageData.ShowTitle){
            
       Write(RenderSectionOrDefault("Header", "DefaultHeader"));

                                                              
        }
        
                                                                   

WriteLiteral("        <div");

WriteLiteral(" class=\"tk-datalist\"");

WriteLiteral(">\r\n");

            
             if (pageData.OperatorPosition != OperatorPosition.None)
            {
                
           Write(RenderSectionOrDefault("ListButtons", "DefaultListButton"));

                                                                           
            }

WriteLiteral("            <div");

WriteLiteral(" id=\"listData\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

           Write(RenderSectionIfDefined("Main", "listmain.cshtml", Model));

WriteLiteral("\r\n            </div>\r\n        </div>\r\n");

WriteLiteral("        ");

   Write(RenderSectionOrDefault("Footer", "DefaultFooter"));

WriteLiteral("\r\n    </div>\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/js.cshtml", null));

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 2542), Tuple.Create("\"", 2622)
, Tuple.Create(Tuple.Create("", 2548), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.normallist.js?v=1".AppVirutalPath()
, 2548), false)
);

WriteLiteral("> </script>\r\n");

WriteLiteral("    ");

Write(ViewBag.Script.CreateUserJavaScript());

WriteLiteral("\r\n</body>\r\n</html>\r\n");

        }
    }
}
