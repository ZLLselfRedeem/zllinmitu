using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    internal sealed class EmptyRuleAttribute : RuleAttribute
    {
        public static readonly RuleAttribute EmptyRule = new EmptyRuleAttribute();

        private EmptyRuleAttribute()
            : base(MessageType.Text)
        {
        }

        public override bool Match(ReceiveMessage message)
        {
            return false;
        }
    }
}
