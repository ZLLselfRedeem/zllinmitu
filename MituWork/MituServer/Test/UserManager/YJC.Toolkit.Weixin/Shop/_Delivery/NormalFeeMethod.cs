using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class NormalFeeMethod
    {
        public NormalFeeMethod()
        {
        }

        public NormalFeeMethod(int startStandards, int startFees, int addStandards, int addFees)
        {
            StartStandards = startStandards;
            StartFees = startFees;
            AddStandards = addStandards;
            AddFees = addFees;
        }

        [SimpleElement(Order = 10)]
        public int StartStandards { get; protected set; }

        [SimpleElement(Order = 20)]
        public int StartFees { get; protected set; }

        [SimpleElement(Order = 30)]
        public int AddStandards { get; protected set; }

        [SimpleElement(Order = 40)]
        public int AddFees { get; protected set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "NormalFeeMethod:{0},{1}",
                StartStandards, StartFees);
        }
    }
}
