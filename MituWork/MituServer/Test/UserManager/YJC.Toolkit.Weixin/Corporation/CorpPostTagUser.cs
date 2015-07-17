using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    internal class CorpPostTagUser
    {
        public CorpPostTagUser(int tagId)
        {
            TagId = tagId;
            UserList = new List<string>();
            PartyList = new List<int>();
        }

        public CorpPostTagUser(int tagId, IEnumerable<string> userList, IEnumerable<int> partyList)
            : this(tagId)
        {
            if (userList != null)
                UserList.AddRange(userList);
            if (partyList != null)
                PartyList.AddRange(partyList);
        }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 10)]
        public int TagId { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Lower, IsMultiple = true, Order = 20)]
        public List<string> UserList { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Lower, IsMultiple = true, Order = 30)]
        public List<int> PartyList { get; private set; }
    }
}
