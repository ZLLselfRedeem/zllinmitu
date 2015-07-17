using System;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class LocationSelectEventAttribute : BaseClickEventAttribute
    {
        public LocationSelectEventAttribute(string eventKey)
            : base(eventKey, EventType.LocationSelect)
        {
        }
    }
}
