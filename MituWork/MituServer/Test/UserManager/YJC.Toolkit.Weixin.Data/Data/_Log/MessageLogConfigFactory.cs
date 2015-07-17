using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    public sealed class MessageLogConfigFactory : BaseXmlConfigFactory
    {
        public const string REG_NAME = "_tk_weixin_MessageLog_Config";
        private const string DESCRIPTION = "微信消息日志的配置插件工厂";

        public MessageLogConfigFactory()
            : base(REG_NAME, DESCRIPTION)
        {
        }

    }
}
