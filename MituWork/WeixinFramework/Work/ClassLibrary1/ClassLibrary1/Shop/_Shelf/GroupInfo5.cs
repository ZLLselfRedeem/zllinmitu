using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class GroupInfo5 : GroupInfo2
    {
        internal GroupInfo5()
        {
        }

        public GroupInfo5(GroupInfo2 gi2, string imgBackground)
        {
            this.Groups = gi2.Groups;
            ImgBackground = imgBackground;
        }

        public GroupInfo5(List<GroupInfo3> groups, string imgBackground)
            : base(groups)
        {
            TkDebug.AssertArgumentNullOrEmpty(imgBackground, "imgBackground", null);

            ImgBackground = imgBackground;
        }

        internal GroupInfo5(GroupInfos groupInfos)
            : this(groupInfos.Groups, groupInfos.ImgBackground)
        {
        }

        [SimpleElement(Order = 20, NamingRule = NamingRule.UnderLineLower)]
        public string ImgBackground { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "ImgBackground:{0}", ImgBackground);
        }
    }
}
