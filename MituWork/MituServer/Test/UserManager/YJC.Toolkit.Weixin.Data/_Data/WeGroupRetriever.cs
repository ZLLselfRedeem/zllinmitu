using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin
{
    [WeDataObject(Author = "YJC", CreateDate = "2014-11-02",
        Description = "获取微信用户组的数据插件")]
    class WeGroupRetriever : IRetriever
    {
        #region IRetriever 成员

        public WeixinResult RetrieveData()
        {
            return WeGroup.GetWeGroupList();
        }

        public WeixinResult ReadData(string json)
        {
            WeGroupCollection result = new WeGroupCollection();
            result.ReadJson(json);

            return result;
        }

        #endregion
    }
}
