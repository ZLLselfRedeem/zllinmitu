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
    using YJC.Toolkit.Sys;
    
    
    public class dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazorusermanagermainpagecshtml : YJC.Toolkit.Razor.NormalCustomTemplate {
        
#line hidden
        
        public dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazorusermanagermainpagecshtml() {
        }
        
        public override void Execute() {
  
    Dictionary<string, string> data = Model;

WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>");

      Write(data["FullName"]);

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

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 574), Tuple.Create("\"", 647)
, Tuple.Create(Tuple.Create("", 581), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/css/bootstrap.min.css".AppVirutalPath()
, 581), false)
);

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 695), Tuple.Create("\"", 771)
, Tuple.Create(Tuple.Create("", 702), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/css/font-awesome.min.css".AppVirutalPath()
, 702), false)
);

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 819), Tuple.Create("\"", 879)
, Tuple.Create(Tuple.Create("", 826), Tuple.Create<System.Object, System.Int32>("toolkitcss/v5/commonM/frame.css".AppVirutalPath()
, 826), false)
);

WriteLiteral(" />\r\n</head>\r\n<body>\r\n    <div");

WriteLiteral(" id=\"MainPage\"");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n        <nav");

WriteLiteral(" class=\"navbar navbar-default\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n                <!-- Brand and toggle get grouped for better mobile display --" +
">\r\n                <div");

WriteLiteral(" class=\"navbar-header\"");

WriteLiteral(">\r\n                    <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"navbar-toggle collapsed\"");

WriteLiteral(" data-toggle=\"collapse\"");

WriteLiteral(" data-target=\"#bs-example-navbar-collapse-1\"");

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"sr-only\"");

WriteLiteral(">Toggle navigation</span>\r\n                        <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                        <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                        <span");

WriteLiteral(" class=\"icon-bar\"");

WriteLiteral("></span>\r\n                    </button>\r\n                    <a");

WriteLiteral(" class=\"navbar-brand\"");

WriteAttribute("href", Tuple.Create(" href=\"", 1640), Tuple.Create("\"", 1695)
, Tuple.Create(Tuple.Create("", 1647), Tuple.Create<System.Object, System.Int32>(StringUtil.EscapeHtmlAttribute(data["HomeUrl"])
, 1647), false)
);

WriteLiteral(">");

                                                                                               Write(data["ShortName"]);

WriteLiteral("</a>\r\n                </div>\r\n\r\n                <!-- Collect the nav links, forms" +
", and other content for toggling -->\r\n                <div");

WriteLiteral(" class=\"collapse navbar-collapse\"");

WriteLiteral(" id=\"bs-example-navbar-collapse-1\"");

WriteLiteral(">\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-nav\"");

WriteLiteral(">\r\n");

WriteLiteral("                        ");

                   Write(data["Menu"]);

WriteLiteral("\r\n                    </ul>\r\n                    <ul");

WriteLiteral(" class=\"nav navbar-nav navbar-right\"");

WriteLiteral(">\r\n                        <li");

WriteLiteral(" class=\"dropdown\"");

WriteLiteral(">\r\n                            <a");

WriteLiteral(" href=\"#\"");

WriteLiteral(" class=\"dropdown-toggle\"");

WriteLiteral(" data-toggle=\"dropdown\"");

WriteLiteral(">");

                                                                                  Write(StringUtil.EscapeHtml(data["UserName"]));

WriteLiteral(" <span");

WriteLiteral(" class=\"caret\"");

WriteLiteral("></span></a>\r\n                            <ul");

WriteLiteral(" class=\"dropdown-menu\"");

WriteLiteral(" role=\"menu\"");

WriteLiteral(">\r\n                                <li><a");

WriteAttribute("href", Tuple.Create(" href=\"", 2415), Tuple.Create("\"", 2542)
, Tuple.Create(Tuple.Create("", 2422), Tuple.Create<System.Object, System.Int32>(StringUtil.EscapeHtmlAttribute("Library/WebModuleRedirectPage.tkx?Source=SimpleLogOff&useSource=true".AppVirutalPath())
, 2422), false)
);

WriteLiteral(@">退出</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
        </nav>
        <div");

WriteLiteral(" class=\"tk-main\"");

WriteLiteral(">\r\n            ");

WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"tk-container\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"tkPages\"");

WriteLiteral(" class=\"tk-page-frame\"");

WriteLiteral(">\r\n                    <iframe");

WriteLiteral(" id=\"tkFrameMain\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3065), Tuple.Create("\"", 3120)
, Tuple.Create(Tuple.Create("", 3071), Tuple.Create<System.Object, System.Int32>(StringUtil.EscapeHtmlAttribute(data["StartUrl"])
, 3071), false)
);

WriteLiteral(" class=\"tk-frame\"");

WriteLiteral(" frameborder=\"0\"");

WriteLiteral(" allowtransparency=\"true\"");

WriteLiteral(" name=\"tkFrameMain\"");

WriteLiteral("></iframe>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div" +
">\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3316), Tuple.Create("\"", 3381)
, Tuple.Create(Tuple.Create("", 3322), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/lib/jquery-1.11.1.min.js".AppVirutalPath()
, 3322), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3428), Tuple.Create("\"", 3498)
, Tuple.Create(Tuple.Create("", 3434), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/js/bootstrap.min.js".AppVirutalPath()
, 3434), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3545), Tuple.Create("\"", 3604)
, Tuple.Create(Tuple.Create("", 3551), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/toolkit.js".AppVirutalPath()
, 3551), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3651), Tuple.Create("\"", 3721)
, Tuple.Create(Tuple.Create("", 3657), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.page.js".AppVirutalPath()
, 3657), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3768), Tuple.Create("\"", 3842)
, Tuple.Create(Tuple.Create("", 3774), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.mainpage.js".AppVirutalPath()
, 3774), false)
);

WriteLiteral("> </script>\r\n</body>\r\n</html>\r\n");

        }
    }
}
