using System;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class ScanCodeWaitmsgEventAttribute : BaseClickEventAttribute
    {
        public ScanCodeWaitmsgEventAttribute(string eventKey)
            : base(eventKey, EventType.ScanCodeWaitmsg)
        {
        }
    }
}
