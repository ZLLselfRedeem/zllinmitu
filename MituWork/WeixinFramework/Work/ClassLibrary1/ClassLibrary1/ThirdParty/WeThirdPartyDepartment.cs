using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.ThirdParty
{
    public class WeThirdPartyDepartment
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Id { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Name { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public int ParentId { get; private set; }

        [SimpleElement(Order = 40, NamingRule = NamingRule.Lower)]
        [TkTypeConverter(typeof(LowerCaseEnumConverter), UseObjectType = true)]
        public bool Writable { get; private set; }
    }
}
