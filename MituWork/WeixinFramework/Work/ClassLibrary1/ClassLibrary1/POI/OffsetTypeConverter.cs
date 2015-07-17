using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    class OffsetTypeConverter : NullableConverter
    {
        public OffsetTypeConverter()
            : base(new EnumIntTypeConverter(typeof(OffsetType)))
        { 
        }
    }
}
