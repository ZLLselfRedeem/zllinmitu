using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
     class AvailableStateConverter : NullableConverter
    {
        public AvailableStateConverter()
            : base(new EnumIntTypeConverter(typeof(AvailableState)))
        {
        }
    }
}
