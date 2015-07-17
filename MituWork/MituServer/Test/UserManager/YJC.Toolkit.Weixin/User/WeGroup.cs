using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    [TypeScheme(Author = "YJC", CreateDate = "2014-11-12", Description = "微信用户组信息")]
    public class WeGroup : WeixinResult, IEntity, IRegName, IDecoderItem
    {
        internal WeGroup()
        {
        }

        #region IRegName 成员

        public string RegName
        {
            get
            {
                return Id.ToString(ObjectUtil.SysCulture);
            }
        }

        #endregion

        #region IEntity 成员

        string IEntity.Id
        {
            get
            {
                return RegName;
            }
        }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 20)]
        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("组名")]
        public string Name { get; set; }

        #endregion

        #region IDecoderItem 成员

        string IDecoderItem.Value
        {
            get
            {
                return RegName;
            }
        }

        string IDecoderItem.this[string name]
        {
            get
            {
                return null;
            }
        }

        #endregion

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 10)]
        [FieldInfo(IsKey = true)]
        [FieldControl(ControlType.Hidden, Order = 10)]
        public int Id { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 30)]
        [FieldControl(ControlType.Label, Order = 30, DefaultShow = PageStyle.List)]
        [DisplayName("人数")]
        public int? Count { get; private set; }

        public WeixinResult Update()
        {
            string url = WeUtil.GetUrl(WeConst.UPDATE_GROUP);
            WeGroupData data = new WeGroupData(this);
            WeixinResult result = new WeixinResult();
            return WeUtil.PostToUri(url, data.WriteJson(WeConst.WRITE_SETTINGS), result);
        }

        public WeixinResult AddUser(string openId)
        {
            string url = WeUtil.GetUrl(WeConst.ADD_GROUP_USER);
            WeGroupUser data = new WeGroupUser
            {
                OpenId = openId,
                GroupId = Id
            };
            WeixinResult result = new WeixinResult();
            return WeUtil.PostToUri(url, data.WriteJson(WeConst.WRITE_SETTINGS), result);
        }

        public override string ToString()
        {
            return Name;
        }

        public static WeGroup CreateGroup(string name)
        {
            TkDebug.AssertArgumentNullOrEmpty(name, "name", null);

            WeGroupData group = new WeGroupData(name);
            string url = WeUtil.GetUrl(WeConst.CREATE_GROUP);
            group = WeUtil.PostToUri(url, group.WriteJson(WeConst.WRITE_SETTINGS), group);
            group.Group.Count = 0;
            return group.Group;
        }

        internal static WeGroupCollection GetWeGroupList()
        {
            string url = WeUtil.GetUrl(WeConst.QUERY_GROUP);
            WeGroupCollection collection = WeUtil.GetFromUri<WeGroupCollection>(url);
            return collection;
        }

        public static IList<WeGroup> GetAllGroups()
        {
            WeGroupCollection collection = GetWeGroupList();
            return collection.Groups;
        }

        public static int GetUserGroupId(string openId)
        {
            TkDebug.AssertArgumentNullOrEmpty(openId, "openId", null);

            WeGroupUser user = new WeGroupUser { OpenId = openId };
            WeGroupId group = new WeGroupId();
            string url = WeUtil.GetUrl(WeConst.QUERY_USER_GROUP);
            group = WeUtil.PostToUri(url, user.WriteJson(WeConst.WRITE_SETTINGS), group);
            return group.GroupId;
        }
    }
}
