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
    
    
    public class dcinternalfilemitucorpweixinwebxmlrazorcxcsgeshuicshtml : YJC.Toolkit.Razor.ToolkitTemplate {
        
#line hidden
        
        public dcinternalfilemitucorpweixinwebxmlrazorcxcsgeshuicshtml() {
        }
        
        public override void Execute() {
WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <title>个税计算器</title>\r\n    <meta");

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

WriteAttribute("href", Tuple.Create(" href=\"", 422), Tuple.Create("\"", 495)
, Tuple.Create(Tuple.Create("", 429), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/css/bootstrap.min.css".AppVirutalPath()
, 429), false)
);

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 543), Tuple.Create("\"", 622)
, Tuple.Create(Tuple.Create("", 550), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/css/bootstrap-theme.min.css".AppVirutalPath()
, 550), false)
);

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 670), Tuple.Create("\"", 746)
, Tuple.Create(Tuple.Create("", 677), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/css/font-awesome.min.css".AppVirutalPath()
, 677), false)
);

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 794), Tuple.Create("\"", 858)
, Tuple.Create(Tuple.Create("", 801), Tuple.Create<System.Object, System.Int32>("toolkitcss/v5/commonM/style.css?v=1".AppVirutalPath()
, 801), false)
);

WriteLiteral(" />\r\n    <link");

WriteLiteral(" rel=\"stylesheet\"");

WriteLiteral(" type=\"text/css\"");

WriteAttribute("href", Tuple.Create(" href=\"", 906), Tuple.Create("\"", 952)
, Tuple.Create(Tuple.Create("", 913), Tuple.Create<System.Object, System.Int32>("usercss/input.css".AppVirutalPath()
, 913), false)
);

WriteLiteral(" />\r\n</head>\r\n<body");

WriteLiteral(" id=\"WebInsertXmlPage\"");

WriteLiteral(" class=\"tk-dataPage\"");

WriteLiteral(" data-webpath=\"/WebSite/\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"container\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" id=\"metaData\"");

WriteLiteral(" class=\"hide\"");

WriteLiteral(" data-toolbar=\"false\"");

WriteLiteral(" data-option=\"false\"");

WriteLiteral("></div>\r\n");

WriteLiteral("        ");

   Write(RenderLocalPartial("EditTitle.cshtml", null));

WriteLiteral("\r\n        <form");

WriteLiteral(" action=\".\"");

WriteLiteral(" method=\"POST\"");

WriteLiteral(" id=\"PostForm\"");

WriteLiteral(" class=\"tk-dataform form-horizontal p5 mt15 mb15\"");

WriteLiteral(" role=\"form\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" id=\"TEST_TOUSU\"");

WriteLiteral(" class=\"tk-datatable table-row\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"hide\"");

WriteLiteral(">\r\n                </div>\r\n                <div");

WriteLiteral(" class=\"p10\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"Content\"");

WriteLiteral(" class=\"col-xs-3 col-sm-3 col-md-3 col-lg-3 pv1 text-right control-label lv-vam\"");

WriteLiteral(">应税收入</label>\r\n                        <div");

WriteLiteral(" class=\"col-xs-9 col-sm-9 col-md-9 col-lg-9 lv-vam\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" type=\"Number\"");

WriteLiteral(" placeholder=\"应税收入\"");

WriteLiteral(" id=\"RawMoney\"");

WriteLiteral(" name=\"RawMoney\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-title=\"应税收入\"");

WriteLiteral(" />\r\n                                <label");

WriteLiteral(" class=\"help-block\"");

WriteLiteral("></label>\r\n                            </span>\r\n                        </div>\r\n " +
"                   </div>\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"Name\"");

WriteLiteral(" class=\"col-xs-3 col-sm-3 col-md-3 col-lg-3 pv1 text-right control-label lv-vam\"");

WriteLiteral(">应交个税</label>\r\n                        <div");

WriteLiteral(" class=\"col-xs-9 col-sm-9 col-md-9 col-lg-9 lv-vam\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" type=\"Text\"");

WriteLiteral(" disabled");

WriteLiteral(" placeholder=\"应交个税\"");

WriteLiteral(" id=\"Tax\"");

WriteLiteral(" name=\"Tax\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-title=\"应交个税\"");

WriteLiteral(" />\r\n                                <label");

WriteLiteral(" class=\"help-block\"");

WriteLiteral("></label>\r\n                            </span>\r\n                        </div>\r\n " +
"                   </div>\r\n                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"Phone\"");

WriteLiteral(" class=\"col-xs-3 col-sm-3 col-md-3 col-lg-3 pv1 text-right control-label lv-vam\"");

WriteLiteral(">税后收入</label>\r\n                        <div");

WriteLiteral(" class=\"col-xs-9 col-sm-9 col-md-9 col-lg-9 lv-vam\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n                                <input");

WriteLiteral(" type=\"Text\"");

WriteLiteral(" disabled");

WriteLiteral(" placeholder=\"税后收入\"");

WriteLiteral(" id=\"Money\"");

WriteLiteral(" name=\"Money\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-title=\"税后收入\"");

WriteLiteral(" />\r\n                                <label");

WriteLiteral(" class=\"help-block\"");

WriteLiteral("></label>\r\n                            </span>\r\n                        </div>\r\n " +
"                   </div>\r\n                </div>\r\n            </div>\r\n         " +
"   <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-primary btn-block btn-cal\"");

WriteLiteral(">计算</button>\r\n        </form>\r\n    </div>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3577), Tuple.Create("\"", 3641)
, Tuple.Create(Tuple.Create("", 3583), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/lib/jquery-1.7.2.min.js".AppVirutalPath()
, 3583), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3688), Tuple.Create("\"", 3758)
, Tuple.Create(Tuple.Create("", 3694), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/bootstrap/js/bootstrap.min.js".AppVirutalPath()
, 3694), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3805), Tuple.Create("\"", 3864)
, Tuple.Create(Tuple.Create("", 3811), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/toolkit.js".AppVirutalPath()
, 3811), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 3911), Tuple.Create("\"", 3981)
, Tuple.Create(Tuple.Create("", 3917), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.page.js".AppVirutalPath()
, 3917), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4028), Tuple.Create("\"", 4102)
, Tuple.Create(Tuple.Create("", 4034), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.data.js?v=7".AppVirutalPath()
, 4034), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4149), Tuple.Create("\"", 4225)
, Tuple.Create(Tuple.Create("", 4155), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.weixin.js?v=5".AppVirutalPath()
, 4155), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4272), Tuple.Create("\"", 4340)
, Tuple.Create(Tuple.Create("", 4278), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.ui.js".AppVirutalPath()
, 4278), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4387), Tuple.Create("\"", 4457)
, Tuple.Create(Tuple.Create("", 4393), Tuple.Create<System.Object, System.Int32>("toolkitjs/v5/toolkit/coreT/toolkit.edit.js".AppVirutalPath()
, 4393), false)
);

WriteLiteral("></script>\r\n    <script");

WriteLiteral(" type=\"text/javascript\"");

WriteAttribute("src", Tuple.Create(" src=\"", 4504), Tuple.Create("\"", 4548)
, Tuple.Create(Tuple.Create("", 4510), Tuple.Create<System.Object, System.Int32>("userjs/geshui.js".AppVirutalPath()
, 4510), false)
);

WriteLiteral("></script>\r\n</body>\r\n</html>\r\n");

        }
    }
}
