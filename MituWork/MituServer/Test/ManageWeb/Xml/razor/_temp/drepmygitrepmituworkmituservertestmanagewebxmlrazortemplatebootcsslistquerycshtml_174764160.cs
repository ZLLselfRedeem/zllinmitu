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
    using YJC.Toolkit.MetaData;
    using YJC.Toolkit.Sys;
    
    
    public class drepmygitrepmituworkmituservertestmanagewebxmlrazortemplatebootcsslistquerycshtml : YJC.Toolkit.Razor.NormalListTemplate {
        
#line hidden
        
        public drepmygitrepmituworkmituservertestmanagewebxmlrazortemplatebootcsslistquerycshtml() {
        }
        
        public override void Execute() {
  
    IEnumerable<IFieldInfoEx> fields = ViewBag.MetaData.Table.TableList;
    var queryFields = (from field in fields
                       let tk5Field = (Tk5FieldInfoEx)field
                       where tk5Field.ListDetail != null && tk5Field.ListDetail.Search
                       select tk5Field).ToArray();
    DataSet dataSet = (DataSet)Model;
    DataRow queryRow = dataSet.GetRow("_QueryData");
    string json = ViewBag.MetaData.Table.JsonFields;
    NormalListData pageData = (NormalListData)ViewBag.PageData;

WriteLiteral("\r\n");

 if (queryFields.Length > 0)
{

WriteLiteral("    <nav");

WriteLiteral(" class=\"navbar navbar-default\"");

WriteLiteral(" role=\"navigation\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"container-fluid\"");

WriteLiteral(">\r\n            <form");

WriteLiteral(" class=\"navbar-form navbar-left tk-datasearch\"");

WriteLiteral(" role=\"search\"");

WriteLiteral(" id=\"QueryForm\"");

WriteLiteral(" data-check=\"false\"");

WriteLiteral(" data-post=\"");

                                                                                                                      Write(StringUtil.EscapeHtmlAttribute(json));

WriteLiteral("\"");

WriteLiteral(">\r\n");

                
                 foreach (Tk5FieldInfoEx field in queryFields)
                {

WriteLiteral("                    <div");

WriteLiteral(" class=\"form-group\"");

WriteLiteral(">\r\n                        <label");

WriteAttribute("for", Tuple.Create(" for=\"", 1216), Tuple.Create("\"", 1237)
, Tuple.Create(Tuple.Create("", 1222), Tuple.Create<System.Object, System.Int32>(field.NickName
, 1222), false)
);

WriteLiteral(">");

                                                Write(field.DisplayName);

WriteLiteral("</label>\r\n                        <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n");

WriteLiteral("                            ");

                       Write(field.SearchControl(queryRow, dataSet));

WriteLiteral("\r\n                        </span>\r\n");

                        
                         if (field.ListDetail.Span)
                        {

WriteLiteral("                            <label>至</label>\r\n");

WriteLiteral("                            <span");

WriteLiteral(" class=\"tk-control\"");

WriteLiteral(">\r\n");

WriteLiteral("                                ");

                           Write(field.SearchControlEnd(queryRow, dataSet));

WriteLiteral("\r\n                            </span>\r\n");

                        }

WriteLiteral("                    </div>\r\n");

                }

WriteLiteral("                ");

           Write(BootcssUtil.ShowSearchCheckBox(pageData.SearchCheckBox));

WriteLiteral("\r\n                <button");

WriteLiteral(" type=\"button\"");

WriteLiteral(" class=\"btn btn-default btn-search\"");

WriteLiteral(">查询</button>\r\n            </form>\r\n        </div>\r\n    </nav>\r\n");

}
        }
    }
}
