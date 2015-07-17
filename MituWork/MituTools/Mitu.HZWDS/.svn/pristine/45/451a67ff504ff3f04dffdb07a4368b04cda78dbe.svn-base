using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.Web;
using YJC.Toolkit.Sys;
using System.Web;

namespace Cxcs.WebData
{
    [Source(Author = "YJC", CreateDate = "2014-08-04", Description = "法规条件跳转页面")]
    [OutputRedirector]
    [WebPage(SupportLogOn = false)]
    class SearchFaGuiSource : BaseWebDbSource
    {
        protected override OutputData DoGet(IInputData input)
        {
            using (TableResolver resolver = PlugInFactoryManager.CreateInstance<TableResolver>(
                ResolverPlugInFactory.REG_NAME, "TaxDocument", this))
            {
                MetaDataTableResolver metaResolver = resolver as MetaDataTableResolver;
                string conditionStr = string.Empty;
                if (metaResolver != null)
                {
                    Dictionary<string, string> query = new Dictionary<string, string> 
                    { 
                        { "Title", input.QueryString["Title"] } 
                    };

                    IParamBuilder builder = metaResolver.GetQueryCondition(new QueryConditionObject(false, query));
                    if (builder != null)
                    {
                        QueryCondition condition = new QueryCondition(query, builder);
                        conditionStr = "&Condition=" + HttpUtility.UrlEncode(condition.ToEncodeString());
                    }
                }
                string url = WebUtil.ResolveUrl("~/Library/WebListXmlPage.tkx?Source=Cxcs/FaGui");
                return OutputData.Create(url + conditionStr);
            }
        }

        protected override OutputData DoPost(IInputData input)
        {
            throw new NotSupportedException();
        }
    }
}
