using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class GroupInfo4
    {
        internal GroupInfo4()
        {
            Groups = new List<GroupInfo3>();
        }

        public GroupInfo4(params GroupInfo3[] groups)
            : this()
        {
            TkDebug.AssertArgumentNull(groups, "groups", null);

            Groups.AddRange(groups);
        }

        public GroupInfo4(GroupInfos groupInfos)
            : this()
        {
            TkDebug.AssertArgumentNull(groupInfos, "groupInfos", null);

            Groups.AddRange(groupInfos.Groups);
        }

        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.Lower)]
        public List<GroupInfo3> Groups { get; protected set; }
    }
}
