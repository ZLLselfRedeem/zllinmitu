﻿using YJC.Toolkit.Cache;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Data;

namespace YJC.Toolkit.Weixin
{
    [CacheItemCreator(Author = "YJC", CreateDate = "2014-11-01",
        Description = "微信公众号媒体文件的缓存对象创建器")]
    [InstancePlugIn, AlwaysCache]
    internal class WeixinMediaCacheCreator : BaseCacheItemCreator
    {
        internal static BaseCacheItemCreator Instance = new WeixinMediaCacheCreator();

        private WeixinMediaCacheCreator()
        {
        }

        public override object Create(string key, params object[] args)
        {
            using (var source = new WeixinDataSource())
            using (var resolver = new MediaCacheResolver(source))
            {
                MediaType type = (MediaType)args[0];
                string path = args[1].Convert<string>();

                return resolver.GetWeixinMediaId(type, path);
            }
        }
    }
}
