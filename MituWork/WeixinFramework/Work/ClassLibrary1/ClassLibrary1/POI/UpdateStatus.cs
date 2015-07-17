using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Card
{
    [EnumCodeTable(Author = "YJC", CreateDate = "2015-03-27", UseIntValue = false,
       Description = "门店更新状态")]
    public enum UpdateStatus
    {
        [DisplayName("没有更新或更新已生效，可以再次更新")]
        UpdatedOrNoUpdate = 0,
        [DisplayName("正在更新中，尚未生效")]
        Updating = 1
    }
}
