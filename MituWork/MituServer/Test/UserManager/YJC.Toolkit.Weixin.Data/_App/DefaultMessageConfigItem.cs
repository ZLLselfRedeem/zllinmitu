using System.Collections.Generic;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Rule;

namespace YJC.Toolkit.Weixin
{
    class DefaultMessageConfigItem
    {
        [TagElement(NamespaceType.Toolkit)]
        [DynamicElement(ReplyMessageConfigFactory.REG_NAME)]
        public IConfigCreator<IRule> Global { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true)]
        public List<TypeDefaultConfigItem> TypeDefault { get; private set; }
    }
}
