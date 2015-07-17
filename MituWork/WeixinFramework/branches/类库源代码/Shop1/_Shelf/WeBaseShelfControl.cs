using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public abstract class WeBaseShelfControl
    {
        protected WeBaseShelfControl()
        {
        }

        [SimpleElement(Order = 100, NamingRule = NamingRule.Lower)]
        public int EId { get; protected set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "Eid:{0}", EId);
        }
    }
}
