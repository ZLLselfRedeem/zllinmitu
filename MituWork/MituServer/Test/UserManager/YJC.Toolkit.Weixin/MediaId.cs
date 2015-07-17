using System;
using YJC.Toolkit.Cache;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    [DayChangeCache(2)]
    public class MediaId : WeixinResult
    {
        internal MediaId()
        {
        }

        internal MediaId(string id)
        {
            Id = id;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods")]
        [SimpleElement(LocalName = "type", Order = 10)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public MediaType Type { get; private set; }

        [SimpleElement(LocalName = "media_id", Order = 20)]
        public string Id { get; private set; }

        [SimpleElement(LocalName = "created_at", Order = 30)]
        [TkTypeConverter(typeof(WeixinDateTimeConverter))]
        public DateTime CreateTime { get; private set; }

        public override string ToString()
        {
            return Id;
        }
    }
}
