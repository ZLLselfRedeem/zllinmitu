using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Semantic
{
    public class WeCarInstructionDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Lower)]
        public int Number { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower, ObjectType = typeof(CarPosition))]
        [TkTypeConverter(typeof(EnumIntTypeConverter), UseObjectType = true)]
        public CarPosition? Position { get; private set; }

        [SimpleElement(Order = 30, NamingRule = NamingRule.Lower)]
        public string Operator { get; private set; }
    }
}
