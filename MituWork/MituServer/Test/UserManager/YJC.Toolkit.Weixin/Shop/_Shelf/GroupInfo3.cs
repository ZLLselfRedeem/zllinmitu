using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class GroupInfo3 : WeShelfGroupId
    {
        internal GroupInfo3()
        {
        }

        internal GroupInfo3(GroupInfo groupInfo)
            : this(groupInfo.GroupId, groupInfo.Img)
        {
        }

        public GroupInfo3(int groupId, string img)
            : base(groupId)
        {
            TkDebug.AssertArgumentNullOrEmpty(img, "img", null);
            Img = img;
        }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Lower)]
        public string Img { get; private set; }

        public override string ToString()
        {
            return string.Format(ObjectUtil.SysCulture, "Img:{0}", Img);
        }
    }
}
