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
    using System.Web;
    using YJC.Toolkit.Sys;
    
    
    public class dworkspacemygitrepmituworkmituservertestmanagewebxmlrazortemplatebootcsstreetemplatecshtml : YJC.Toolkit.Razor.NormalCustomTemplate {
        
#line hidden
            
    string GetRootUrl(string source)
    {
        string result = string.Format("Library/WebModuleRedirectPage.tkx?Source={0}&Style=CNewChild", source);
        return result.AppVirutalPath();
    }
    string GetDragAttr(NormalTreeData pageData)
    {
        if (pageData.CanMoveNode)
            return "data-drag=\"true\"";
        return string.Empty;
    }

        
        public dworkspacemygitrepmituworkmituservertestmanagewebxmlrazortemplatebootcsstreetemplatecshtml() {
        }
        
        public override void Execute() {
  
    Dictionary<string, string> queryString = Model.QueryString;
    string source = Model.Source;
    NormalTreeData pageData = ViewBag.PageData;

WriteLiteral("\r\n");

DefineSection("DefaultHeader", () => {

WriteLiteral("\r\n    <h1");

WriteLiteral(" class=\"ml15\"");

WriteLiteral(">");

                Write(ViewBag.Title);

WriteLiteral("</h1>\r\n");

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
"=0\"");

WriteLiteral(" />\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/css.cshtml", null));

WriteLiteral("\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1200), Tuple.Create("\"", 1277)
, Tuple.Create(Tuple.Create("", 1207), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/jstree/themes/default/style.min.css".AppVirutalPath()
, 1207), false)
);

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1325), Tuple.Create("\"", 1399)
, Tuple.Create(Tuple.Create("", 1332), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/css/simple-sidebar.css".AppVirutalPath()
, 1332), false)
);

WriteLiteral(" />\r\n    <style>\r\n        #treeContent\r\n        {\r\n            position: fixed;\r\n" +
"            bottom: 30px;\r\n            top: 0px;\r\n            left: 15px;\r\n     " +
"       width: 250px;\r\n");

            
             if (pageData.ShowTitle)
            {

WriteLiteral("            ");

WriteLiteral("margin-top:70px;\r\n");

            }

WriteLiteral("        }\r\n\r\n        #treeBar\r\n        {\r\n            position: fixed;\r\n         " +
"   bottom: 0px;\r\n            height: 30px;\r\n            left: 15px;\r\n           " +
" width: 250px;\r\n            background: #ddd;\r\n        }\r\n    </style>\r\n</head>\r" +
"\n<body");

WriteLiteral(" class=\"tk-dataPage\"");

WriteLiteral(" data-webPath=\"");

                                   Write(HtmlUtil.AppVirtualPath);

WriteLiteral("\"");

WriteLiteral(">\r\n");

    
     if (pageData.ShowTitle)
    {
        
   Write(RenderSectionOrDefault("Header", "DefaultHeader"));

                                                          
    }

WriteLiteral("    <div");

WriteLiteral(" id=\"wrapper\"");

WriteLiteral(">\r\n\r\n        <!-- Sidebar -->\r\n        <div");

WriteLiteral(" id=\"sidebar-wrapper\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"treeContent\"");

WriteLiteral(" class=\"tktree p10 oa bdc\"");

WriteLiteral(" ");

                                                       Write(GetDragAttr(pageData));

WriteLiteral(" data-url=\"");

                                                                                        Write(ObjectExtension.AppVirutalPath(Model.ListUrl));

WriteLiteral("\" data-source=\"");

                                                                                                                                                     Write(Model.Source);

WriteLiteral("\" data-selectFunc=\"Toolkit.tree.detailClick\" data-firstFunc=\"Toolkit.tree._firstC" +
"lick\" data-initValue=\"");

                                                                                                                                                                                                                                                                         Write(queryString.GetKeyValue("InitValue"));

WriteLiteral("\" data-idName=\"");

                                                                                                                                                                                                                                                                                                                             Write(Model.IdField);

WriteLiteral("\" data-detailUrl=\"");

                                                                                                                                                                                                                                                                                                                                                             Write(ObjectExtension.AppVirutalPath(Model.DetailUrl));

WriteLiteral("\">\r\n            </div>\r\n            <div");

WriteLiteral(" id=\"treeBar\"");

WriteLiteral(" class=\"bdc pl5 pt5\"");

WriteLiteral(">\r\n");

                
                 if (pageData.ShowUpDownButton)
                {

WriteLiteral("                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"moveUp\"");

WriteLiteral(" class=\"btn btn-info btn-xs\"");

WriteLiteral(" data-action=\"before\"");

WriteLiteral("><i");

WriteLiteral(" class=\"icon-angle-up\"");

WriteLiteral("></i>上移</button>\r\n");

WriteLiteral("                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" id=\"moveDown\"");

WriteLiteral(" class=\"btn btn-info btn-xs\"");

WriteLiteral(" data-action=\"after\"");

WriteLiteral("><i");

WriteLiteral(" class=\"icon-angle-down\"");

WriteLiteral("></i>下移</button>\r\n");

                }

WriteLiteral("                ");

                 if (pageData.ShowNewRootButton)
                {

WriteLiteral("                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-info btn-xs\"");

WriteLiteral(" data-dialog-url=\"");

                                                                                  Write(GetRootUrl(source));

WriteLiteral("\"");

WriteLiteral("><i");

WriteLiteral(" class=\"icon-plus\"");

WriteLiteral("></i>新建根节点</button>\r\n");

                }

WriteLiteral("            </div>\r\n        </div>\r\n        <!-- /#sidebar-wrapper -->\r\n\r\n       " +
" <!-- Page Content -->\r\n        <div");

WriteLiteral(" id=\"page-content-wrapper bdc\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(" id=\"nodeDetail\"");

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n        <!-- /#page-content-wrapper -->\r\n\r" +
"\n    </div>\r\n");

WriteLiteral("    ");

Write(RenderLayoutPartial("../bin/js.cshtml", null));

WriteLiteral("\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3666), Tuple.Create("\"", 3723)
, Tuple.Create(Tuple.Create("", 3672), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/jstree/jstree.js".AppVirutalPath()
, 3672), false)
);

WriteLiteral("> </script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3771), Tuple.Create("\"", 3841)
, Tuple.Create(Tuple.Create("", 3777), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.tree.js".AppVirutalPath()
, 3777), false)
);

WriteLiteral("> </script>\r\n</body>\r\n</html>\r\n");

        }
    }
}
