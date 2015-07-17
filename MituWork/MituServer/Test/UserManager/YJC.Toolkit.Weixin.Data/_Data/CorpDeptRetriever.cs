using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin
{
    [WeDataObject(Author = "YJC", CreateDate = "2014-11-02",
        Description = "获取企业组织的数据插件")]
    class CorpDeptRetriever : IRetriever
    {
        #region IRetriever 成员

        public WeixinResult RetrieveData()
        {
            return CorpDepartment.GetDepartmentList();
        }

        public WeixinResult ReadData(string json)
        {
            CorpDepartmentCollection result = new CorpDepartmentCollection();
            result.ReadJson(json);
            return result;
        }

        #endregion
    }
}
