using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class SkuInfo
    {
        //public SkuInfo()
        //{
        //    Vid = new List<string>();
        //}
        //public SkuInfo(string id, string vid)
        //    : this()
        //{
        //    TkDebug.AssertArgumentNullOrEmpty(id, "id", null);
        //    TkDebug.AssertArgumentNullOrEmpty(vid, "vid", null);
        //    Id = id;
        //    Vid.Add(vid);
        //}
        //public SkuInfo(string id, params string[] vid)
        //    : this()
        //{
        //    TkDebug.AssertArgumentNullOrEmpty(id, "id", null);
        //    TkDebug.AssertArgumentNull(vid, "vid", null);
        //    Id = id;
        //    Vid.AddRange(vid);
        //}

        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        public string Id { get; set; }

        [SimpleElement(IsMultiple = true, Order = 20, NamingRule = NamingRule.Camel)]
        public List<string> Vid { get; set; }
    }
}
