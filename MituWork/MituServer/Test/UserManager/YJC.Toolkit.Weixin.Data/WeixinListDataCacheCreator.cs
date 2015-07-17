using YJC.Toolkit.Cache;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Data;

namespace YJC.Toolkit.Weixin
{
    [CacheItemCreator(Author = "YJC", CreateDate = "2014-11-10",
        Description = "微信集合数据诸如Tag，Group等数据的缓存对象创建器")]
    [InstancePlugIn, AlwaysCache]
    internal class WeixinListDataCacheCreator : BaseCacheItemCreator
    {
        internal static BaseCacheItemCreator Instance = new WeixinListDataCacheCreator();

        private WeixinListDataCacheCreator()
        {
        }

        public override object Create(string key, params object[] args)
        {
            using (WeixinDataSource source = new WeixinDataSource())
            using (CacheDataResolver resolver = new CacheDataResolver(source))
            {
                return resolver.ReadObject(key);
            }
        }
    }
}
