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
    
    
    public class dmituservertestmanagewebxmlrazortemplatebootcsseditmaincshtml : YJC.Toolkit.Razor.NormalEditTemplate {
        
#line hidden
 
    string GetJson(Tk5NormalTableData table)
    {
        var json = string.Format("{{\"Tables\":[{0}]}}", table.JsonFields);
        return StringUtil.EscapeHtmlAttribute(json);
    } 

        
        public dmituservertestmanagewebxmlrazortemplatebootcsseditmaincshtml() {
        }
        
        public override void Execute() {
  
    NormalEditData pageData = ViewBag.PageData;
    HtmlAttribute attribute = pageData.DialogMode ? new HtmlAttribute("data-dialog-action", "close")
        : new HtmlAttribute("data-url", HtmlUtil.GetRetUrl((DataSet)Model));
    HtmlAttribute retAttr = new HtmlAttribute("data-action", "return");

WriteLiteral("\r\n");

DefineSection("DefaultButtons", () => {

WriteLiteral("\r\n    <div");

WriteLiteral(" class=\"text-center clearfix\"");

WriteLiteral(">\r\n");

WriteLiteral("        ");

   Write(BootcssUtil.Button(pageData.SaveButtonCaption, "btn-submit", BootcssButton.Primary, false));

WriteLiteral("\r\n");

WriteLiteral("        ");

   Write(BootcssUtil.Button(pageData.CancelCaption, "m10", BootcssButton.Default, false, attribute, retAttr));

WriteLiteral("\r\n    </div>\r\n");

});

  
    DataRow dataRow = HtmlUtil.GetMainRow((DataSet)Model, ViewBag);
    Tk5NormalTableData table = ViewBag.MetaData.Table;
    List<Tk5FieldInfoEx> hiddenFields = table.HiddenList;
    List<Tk5FieldInfoEx> normalFields = table.TableList;
    bool showCaption = pageData.ShowCaption;
    string dataClass = showCaption ? string.Empty : "class=\"nocaption\"";

WriteLiteral("\r\n<form");

WriteAttribute("action", Tuple.Create(" action=\"", 1428), Tuple.Create("\"", 1465)
, Tuple.Create(Tuple.Create("", 1437), Tuple.Create<System.Object, System.Int32>(ViewBag.PageData.FormAction
, 1437), false)
);

WriteLiteral(" method=\"POST\"");

WriteLiteral(" id=\"PostForm\"");

WriteLiteral(" class=\"tk-dataform p5 mb15\"");

WriteLiteral(" role=\"form\"");

WriteLiteral(" data-check=\"true\"");

WriteLiteral(" data-post=\"");

                                                                                                                                        Write(GetJson(table));

WriteLiteral("\"");

WriteLiteral(">\r\n    <div");

WriteAttribute("id", Tuple.Create(" id=\"", 1591), Tuple.Create("\"", 1612)
, Tuple.Create(Tuple.Create("", 1596), Tuple.Create<System.Object, System.Int32>(table.TableName
, 1596), false)
);

WriteAttribute("class", Tuple.Create(" class=\"", 1613), Tuple.Create("\"", 1708)
, Tuple.Create(Tuple.Create("", 1621), Tuple.Create<System.Object, System.Int32>(HtmlUtil.MergeClass("tk-datatable table-row", "column" + table.ColumnCount.ToString())
, 1621), false)
);

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"hide\"");

WriteLiteral(">\r\n");

            
             foreach (Tk5FieldInfoEx field in hiddenFields)
            {
                
           Write(RenderHidden(dataRow, field, true));

                                                   
            }

WriteLiteral("        </div>\r\n        <div");

WriteLiteral(" class=\"p10 pull-left w100p\"");

WriteLiteral(">\r\n");

            
             foreach (Tk5FieldInfoEx field in normalFields)
            {
                
                  
                    string fieldString = RenderFieldItem(dataRow, field);
                 
                  
                if (fieldString != null)
                {
                
           Write(fieldString);

                            
                }
                else
                {

WriteLiteral("                <div");

WriteAttribute("class", Tuple.Create(" class=\"", 2305), Tuple.Create("\"", 2378)
, Tuple.Create(Tuple.Create("", 2313), Tuple.Create<System.Object, System.Int32>(HtmlUtil.MergeClass("tk-column form-group", field.LayoutClass())
, 2313), false)
);

WriteLiteral(">\r\n                    <dl ");

                   Write(dataClass);

WriteLiteral(">\r\n");

                        
                         if (showCaption)
                            {

WriteLiteral("                            <dt>");

                           Write(field.DisplayName);

WriteLiteral("</dt>\r\n");

                            }

WriteLiteral("                        <dd>\r\n                            <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

                           Write(field.Control(dataRow, (DataSet)Model, true));

WriteLiteral("\r\n                            </span>\r\n                        </dd>\r\n           " +
"         </dl>\r\n                </div>\r\n");

                }
            }

WriteLiteral("        </div>\r\n    </div>\r\n</form>\r\n");

Write(RenderSectionOrDefault("ModuleButtons", "DefaultButtons"));

WriteLiteral("\r\n");

        }
    }
}
