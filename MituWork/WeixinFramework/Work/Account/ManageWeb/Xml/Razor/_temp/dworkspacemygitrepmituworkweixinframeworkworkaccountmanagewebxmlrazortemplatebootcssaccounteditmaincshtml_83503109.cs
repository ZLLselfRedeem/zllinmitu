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
    using YJC.Toolkit.MetaData;
    using YJC.Toolkit.Data;
    using YJC.Toolkit.Sys;
    using YJC.Toolkit.Accounting;
    
    
    public class dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazortemplatebootcssaccounteditmaincshtml : YJC.Toolkit.Accounting.AccountEditTemplate {
        
#line hidden
 
    string GetJson(Tk5NormalTableData table)
    {
        var normalJson = "{\"Table\":\"Info\",\"SearchMethod\":\"Id\",\"JsonType\":\"Object\",\"Fields\":[{\"Name\":\"ReportId\",\"Type\":\"Hidden\"},{\"Name\":\"Company\",\"Type\":\"Hidden\"},{\"Name\":\"ReportDate\",\"Type\":\"Date\"},{\"Name\":\"ReportType\",\"Type\":\"Combo\"},{\"Name\":\"ReportName\",\"Type\":\"Hidden\"}]}";
        var json = string.Format("{{\"Tables\":[{0}, {1}]}}", table.JsonFields, normalJson);
        return StringUtil.EscapeHtmlAttribute(json);
    } 

        
        public dworkspacemygitrepmituworkweixinframeworkworkaccountmanagewebxmlrazortemplatebootcssaccounteditmaincshtml() {
        }
        
        public override void Execute() {
  
    NormalEditData pageData = ViewBag.PageData;
    HtmlAttribute retAttr = new HtmlAttribute("data-action", "return");

    Tk5NormalTableData table = ViewBag.MetaData.Table;
    List<Tk5FieldInfoEx> hiddenFields = table.HiddenList;
    List<Tk5FieldInfoEx> normalFields = table.TableList;
    int columnCount = table.ColumnCount;
    int columnWidth = 12 / columnCount;
    int fieldsCount = normalFields.Count;
    int columnFieldCount = fieldsCount / columnCount;
    
     if ((fieldsCount % columnCount) != 0){
        ++columnFieldCount;
    }
     

    ReportObjectData model = Model as ReportObjectData;
    ObjectContainer mainObject = model.Object;// HtmlUtil.GetMainObject(Model, ViewBag);
    ReportInfo rptInfo = model.Info;
    string dateValue = rptInfo.ReportDate == new DateTime() ? string.Empty : rptInfo.ReportDate.ToString("yyyy-MM");
    HtmlAttribute attribute = new HtmlAttribute("data-url", ("Library/WebListXmlPage.tkx?Source=Accounting/ReportData&Company=" + rptInfo.Company).AppVirutalPath());

WriteLiteral("\r\n");

DefineSection("DefaultButtons", () => {

WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"text-center clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

   Write(BootcssUtil.Button(pageData.SaveButtonCaption, "btn-submit", BootcssButton.Primary, false));

WriteLiteral("\r\n");

WriteLiteral("        ");

   Write(BootcssUtil.Button(pageData.CancelCaption, "m10", BootcssButton.Default, false, retAttr, attribute));

WriteLiteral("\r\n    </div>\r\n");

});

  

WriteLiteral("\r\n<form");

WriteAttribute("action", Tuple.Create(" action=\"", 2181), Tuple.Create("\"", 2218)
, Tuple.Create(Tuple.Create("", 2190), Tuple.Create<System.Object, System.Int32>(ViewBag.PageData.FormAction
, 2190), false)
);

WriteLiteral(" method=\"POST\"");

WriteLiteral(" data-toggle=\"validator\"");

WriteLiteral(" id=\"PostForm\"");

WriteLiteral(" class=\"tk-dataform p5 mb15\"");

WriteLiteral(" role=\"form\"");

WriteLiteral(" data-check=\"true\"");

WriteLiteral(" data-post=\"");

                                                                                                                                                                Write(GetJson(table));

WriteLiteral("\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"row tk-datatable table-row\"");

WriteLiteral(" id=\"Info\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"col-sm-4\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"col-sm-4 ver-middle\"");

WriteLiteral(">报表类型：</label>\r\n                <div");

WriteLiteral(" class=\"col-sm-8 \"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n                        <select");

WriteLiteral(" id=\"ReportType\"");

WriteLiteral(" name=\"ReportType\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-title=\"市场板块\"");

WriteLiteral(">\r\n                            <option");

WriteLiteral(" value=\"01\"");

WriteLiteral(" ");

                                                if (rptInfo.ReportType == "01") {
WriteLiteral("  ");

WriteLiteral(" selected\r\n");

                                                                         }
WriteLiteral(">\r\n                                合并报表\r\n                            </option>\r\n " +
"                           <option");

WriteLiteral(" value=\"02\"");

WriteLiteral(" ");

                                                if (rptInfo.ReportType == "02") {
WriteLiteral("  ");

WriteLiteral(" selected\r\n");

                                                                         }
WriteLiteral(">\r\n                                母公司报表\r\n                            </option>\r\n" +
"                        </select>\r\n                    </span>\r\n                " +
"</div>\r\n                <br />\r\n            </div>\r\n        </div>\r\n        <div" +
"");

WriteLiteral(" class=\"col-sm-6\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n                <label");

WriteLiteral(" class=\"col-sm-2 ver-middle\"");

WriteLiteral(">日期：</label>\r\n                <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" id=\"_RptDateCtrl\"");

WriteLiteral(" class=\"input-group date\"");

WriteLiteral(" data-control=\"CustomDate\"");

WriteLiteral(" data-date-format=\"yyyy-mm\"");

WriteLiteral(" data-date=\"");

                                                                                                                               Write(dateValue);

WriteLiteral("\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" size=\"10\"");

WriteLiteral(" readonly");

WriteLiteral(" placeholder=\"日期\"");

WriteLiteral(" id=\"ReportDate\"");

WriteLiteral(" name=\"ReportDate\"");

WriteLiteral(" class=\"form-control\"");

WriteLiteral(" data-title=\"日期\"");

WriteAttribute("value", Tuple.Create(" value=\"", 3854), Tuple.Create("\"", 3872)
                                                                             , Tuple.Create(Tuple.Create("", 3862), Tuple.Create<System.Object, System.Int32>(dateValue
, 3862), false)
);

WriteLiteral(">\r\n                        <span");

WriteLiteral(" class=\"input-group-addon\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-remove\"");

WriteLiteral("></i></span>\r\n                        <span");

WriteLiteral(" class=\"input-group-addon\"");

WriteLiteral("><i");

WriteLiteral(" class=\"glyphicon glyphicon-calendar\"");

WriteLiteral("></i></span>\r\n                    </div>\r\n                </span>\r\n            </" +
"div>\r\n            <br />\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"col-sm-2\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"row ml20\"");

WriteLiteral(">\r\n                <strong");

WriteLiteral(" class=\"ver-middle\"");

WriteLiteral(">单位：元</strong>\r\n                <input");

WriteLiteral(" id=\"ReportName\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4379), Tuple.Create("\"", 4406)
, Tuple.Create(Tuple.Create("", 4387), Tuple.Create<System.Object, System.Int32>(rptInfo.ReportName
, 4387), false)
);

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"Company\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4459), Tuple.Create("\"", 4483)
, Tuple.Create(Tuple.Create("", 4467), Tuple.Create<System.Object, System.Int32>(rptInfo.Company
, 4467), false)
);

WriteLiteral(">\r\n                <input");

WriteLiteral(" id=\"ReportId\"");

WriteLiteral(" type=\"hidden\"");

WriteAttribute("value", Tuple.Create(" value=\"", 4537), Tuple.Create("\"", 4562)
, Tuple.Create(Tuple.Create("", 4545), Tuple.Create<System.Object, System.Int32>(rptInfo.ReportId
, 4545), false)
);

WriteLiteral(">\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <br />\r\n    <div");

WriteAttribute("id", Tuple.Create(" id=\"", 4634), Tuple.Create("\"", 4655)
, Tuple.Create(Tuple.Create("", 4639), Tuple.Create<System.Object, System.Int32>(table.TableName
, 4639), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 4656), Tuple.Create("\"", 4751)
, Tuple.Create(Tuple.Create("", 4664), Tuple.Create<System.Object, System.Int32>(HtmlUtil.MergeClass("tk-datatable table-row", "column" + table.ColumnCount.ToString())
, 4664), false)
);

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"hide\"");

WriteLiteral(">\r\n            ");

WriteLiteral("\r\n        </div>\r\n        <div");

WriteLiteral(" class=\"row\"");

WriteLiteral(">\r\n");

            
             for (int i = 0; i < columnCount; ++i)
            {
                
                  
                int start = i * columnFieldCount;
                int end = start + columnFieldCount;
                if (end > fieldsCount)
                {
                    end = fieldsCount;
                }
                
                 

WriteLiteral("                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 5334), Tuple.Create("\"", 5379)
, Tuple.Create(Tuple.Create("", 5342), Tuple.Create<System.Object, System.Int32>("col-sm-" + columnWidth.ToString()
, 5342), false)
);

WriteLiteral(">\r\n                    <table");

WriteLiteral(" class=\"table\"");

WriteLiteral(">\r\n                        <tr>\r\n                            <th>资产</th>\r\n       " +
"                     <th>行次</th>\r\n                            <th>期末数</th>\r\n    " +
"                    </tr>\r\n");

                        
                         for (int j = start; j < end; ++j)
                        {
                            
                              
                            var field = normalFields[j];

                            Tuple<int, byte, FieldStyle> info = field.Tag as Tuple<int, byte, FieldStyle>;
                            string intendClass = info.Item2 == 0 ? string.Empty : "class=\"pdl-" + info.Item2 + "\"";
                            
                             
                            
                             if (info.Item3 == FieldStyle.Title)
                            {

WriteLiteral("                                <tr");

WriteLiteral(" class=\"info\"");

WriteLiteral(">\r\n                                    <td>");

                                   Write(field.DisplayName);

WriteLiteral("</td>\r\n                                    <td></td>\r\n                           " +
"         <td></td>\r\n                                </tr>\r\n");

                            }
                            else
                            {

WriteLiteral("                                <tr>\r\n                                    <td ");

                                   Write(intendClass);

WriteLiteral(">");

                                                Write(field.DisplayName);

WriteLiteral("</td>\r\n                                    <td>");

                                   Write(info.Item1);

WriteLiteral("</td>\r\n                                    <td>\r\n                                " +
"        <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                                            <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">");

                                                                Write(field.InputByLocalName(mainObject, true));

WriteLiteral("</span>\r\n                                        </div>\r\n                        " +
"            </td>\r\n                                </tr>\r\n");

                            }
                             
                        }

WriteLiteral("                    </table>\r\n                </div>\r\n");

            }

WriteLiteral("        </div>\r\n    </div>\r\n</form>\r\n\r\n");

Write(RenderSectionOrDefault("ModuleButtons", "DefaultButtons"));

WriteLiteral("\r\n");

        }
    }
}
