using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    [TypeScheme(Author = "YJC", CreateDate = "2014-11-19", Description = "微信企业号的标签信息")]
    public class CorpTag : WeixinResult, IEntity, IRegName, IDecoderItem
    {
        internal CorpTag()
        {
        }

        public CorpTag(int tagId)
        {
            Id = tagId;
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

        [SimpleElement(LocalName = "tagid", Order = 10)]
        [FieldInfo(IsKey = true)]
        [FieldControl(ControlType.Hidden, Order = 10)]
        public int Id { get; private set; }

        [SimpleElement(LocalName = "tagname", Order = 10)]
        [FieldInfo(Length = 255)]
        [FieldControl(ControlType.Text, Order = 20)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("名称")]
        public string Name { get; set; }

        public CorpTagUserResult AddMembers(IEnumerable<string> userList, IEnumerable<int> partyList)
        {
            TkDebug.AssertArgument(userList != null || partyList != null, "userList",
                "参数userList或者partyList不能全为空", this);

            CorpPostTagUser postData = new CorpPostTagUser(Id, userList, partyList);
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.ADD_TAG_USER,
                WeixinSettings.Current.CorpUserManagerSecret);
            CorpTagUserResult result = WeUtil.PostToUri(url,
                postData.WriteJson(WeConst.WRITE_SETTINGS), new CorpTagUserResult());

            return result;
        }

        public CorpTagUserResult RemoveMembers(IEnumerable<string> userList, IEnumerable<int> partyList)
        {
            TkDebug.AssertArgument(userList != null || partyList != null, "userList",
                "参数userList或者partyList不能全为空", this);

            CorpPostTagUser postData = new CorpPostTagUser(Id, userList, partyList);
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.REMOVE_TAG_USER,
                WeixinSettings.Current.CorpUserManagerSecret);
            CorpTagUserResult result = WeUtil.PostToUri(url,
                postData.WriteJson(WeConst.WRITE_SETTINGS), new CorpTagUserResult());

            return result;
        }

        public WeixinResult Update()
        {
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.UPDATE_TAG,
                WeixinSettings.Current.CorpUserManagerSecret);
            return WeUtil.PostToUri(url, this.WriteJson(WeConst.WRITE_SETTINGS), new WeixinResult());
        }

        public bool Delete()
        {
            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.DELETE_TAG,
                CorpAccessToken.GetTokenWithSecret(WeixinSettings.Current.CorpUserManagerSecret), Id);
            WeixinResult result = WeUtil.GetFromUri<WeixinResult>(url);
            return !result.IsError;
        }

        public CorpTagMembers GetMembers()
        {
            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.QUERY_TAG_USER,
                CorpAccessToken.GetTokenWithSecret(WeixinSettings.Current.CorpUserManagerSecret), Id);
            CorpTagMembers result = WeUtil.GetFromUri(url, new CorpTagMembers());
            return result;
        }

        public override string ToString()
        {
            return Name;
        }

        public static CorpTag Create(string name)
        {
            TkDebug.AssertArgumentNullOrEmpty(name, "name", null);

            CorpTag data = new CorpTag
            {
                Name = name
            };
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.CREATE_TAG,
                WeixinSettings.Current.CorpUserManagerSecret);
            return WeUtil.PostToUri(url, data.WriteJson(WeConst.WRITE_SETTINGS), data);
        }

        internal static CorpTagList GetTagList()
        {
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.QUERY_TAG,
                            WeixinSettings.Current.CorpUserManagerSecret);
            CorpTagList list = WeUtil.GetFromUri(url, new CorpTagList());
            return list;
        }

        public static IList<CorpTag> QueryTags()
        {
            CorpTagList list = GetTagList();
            return list.TagList;
        }
    }
}
