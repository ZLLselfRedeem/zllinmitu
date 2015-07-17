using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class GroupInfo2
    {
        internal GroupInfo2()
        {
            Groups = new List<WeShelfGroupId>();
        }

        public GroupInfo2(List<GroupInfo3> groups)
            : this()
        {
            TkDebug.AssertArgumentNull(groups, "groups", null);

            foreach (var g in groups)
            {
                Groups.Add(new WeShelfGroupId(g.GroupId));
            }
        }

        public GroupInfo2(params WeShelfGroupId[] groups)
            : this()
        {
            TkDebug.AssertArgumentNull(groups, "groups", null);

            Groups.AddRange(groups);
        }

        [ObjectElement(IsMultiple = true, Order = 10, NamingRule = NamingRule.Lower)]
        public List<WeShelfGroupId> Groups { get; protected set; }
    }
}
