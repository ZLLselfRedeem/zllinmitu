using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;
using YJC.Toolkit.Weixin.Rule;

namespace YJC.Toolkit.Weixin
{
    class TypeDefaultConfigItem
    {
        [SimpleAttribute]
        public MessageType MessageType { get; private set; }

        [DynamicElement(ReplyMessageConfigFactory.REG_NAME)]
        public IConfigCreator<IRule> Message { get; private set; }
    }
}
