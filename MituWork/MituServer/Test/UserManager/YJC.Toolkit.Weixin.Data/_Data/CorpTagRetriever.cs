using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin
{
    [WeDataObject(Author = "YJC", CreateDate = "2014-11-02",
        Description = "获取企业标签（相当于用户组）的数据插件")]
    class CorpTagRetriever : IRetriever
    {
        #region IRetriever 成员

        public WeixinResult RetrieveData()
        {
            return CorpTag.GetTagList();
        }

        public WeixinResult ReadData(string json)
        {
            CorpTagList result = new CorpTagList();
            result.ReadJson(json);
            return result;
        }

        #endregion
    }
}
