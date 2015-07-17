using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    public class CorpUser : CorpSimpleUser
    {
        internal CorpUser()
        {
            ExtAttrs = new List<ExtAttribute>();
        }

        public CorpUser(string userId, string userName, IEnumerable<int> department)
            : this()
        {
            TkDebug.AssertArgumentNullOrEmpty(userId, "userId", null);
            TkDebug.AssertArgumentNullOrEmpty(userName, "userName", null);

            Id = userId;
            Name = userName;
            List<int> depart = department as List<int>;
            if (depart != null)
                Department = depart;
            else
                Department = new List<int>(department);
        }

        [SimpleElement(NamingRule = NamingRule.Camel, IsMultiple = true, Order = 30)]
        internal List<int> Department { get; private set; }

        [SimpleElement(LocalName = "Department")]
        internal QuoteStringList DepartmentList
        {
            get
            {
                return null;
            }
            set
            {
                if (value != null)
                    Department = value.ConvertToList<int>();
                else
                    Department = null;
            }
        }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 40)]
        [NameModel(WeCorpConst.USER_MODE)]
        public string Position { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 50)]
        [NameModel(WeCorpConst.USER_MODE)]
        public string Mobile { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 60)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        [NameModel(WeCorpConst.USER_MODE)]
        public CorpSex Gender { get; set; }

        //[SimpleElement(NamingRule = NamingRule.Camel, Order = 70)]
        //public string Tel { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 80)]
        [NameModel(WeCorpConst.USER_MODE)]
        public string Email { get; set; }

        [SimpleElement(NamingRule = NamingRule.Lower, Order = 90)]
        [NameModel(WeCorpConst.USER_MODE, LocalName = "Weixin")]
        public string WeixinId { get; set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 100)]
        public string Avatar { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 120)]
        [TkTypeConverter(typeof(BoolIntConverter))]
        public bool Enable
        {
            get
            {
                return Status == UserStatus.Attention;
            }
            set
            {
                Status = value ? UserStatus.Attention : UserStatus.Frozen;
            }
        }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 110)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public UserStatus Status { get; private set; }

        [TagElement(Order = 130, LocalName = "extattr")]
        [ObjectElement(IsMultiple = true, LocalName = "attrs", UseConstructor = true)]
        public List<ExtAttribute> ExtAttrs { get; private set; }

        public WeixinResult Delete()
        {
            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.DELETE_USER,
                CorpAccessToken.GetTokenWithSecret(WeixinSettings.Current.CorpUserManagerSecret), Id);
            WeixinResult result = WeUtil.GetFromUri<WeixinResult>(url);
            return result;
        }

        public WeixinResult Update()
        {
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.UPDATE_USER,
                WeixinSettings.Current.CorpUserManagerSecret);
            return WeUtil.PostToUri(url, this.WriteJson(WeConst.WRITE_SETTINGS), new WeixinResult());
        }

        public WeixinResult Create()
        {
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.CREATE_USER,
                WeixinSettings.Current.CorpUserManagerSecret);
            return WeUtil.PostToUri(url, this.WriteJson(WeConst.WRITE_SETTINGS), new WeixinResult());
        }

        public static CorpUser GetUser(string userId)
        {
            TkDebug.AssertArgumentNullOrEmpty(userId, "userId", null);

            string url = string.Format(ObjectUtil.SysCulture, WeCorpConst.GET_USER,
                CorpAccessToken.GetTokenWithSecret(WeixinSettings.Current.CorpUserManagerSecret), userId);
            CorpUser user = WeUtil.GetFromUri(url, new CorpUser());
            return user;
        }

        public static WeixinResult BatchDelete(IEnumerable<string> userIds)
        {
            TkDebug.AssertArgumentNull(userIds, "userIds", null);

            CorpUserIdList id = new CorpUserIdList(userIds);
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.BATCH_DELETE_USER,
                WeixinSettings.Current.CorpUserManagerSecret);
            return WeUtil.PostToUri(url, id.WriteJson(WeConst.WRITE_SETTINGS), new WeixinResult());
        }

        public static InviteType Invite(string userId, string tips)
        {
            TkDebug.AssertArgumentNullOrEmpty(userId, "userId", null);
            TkDebug.AssertArgumentNullOrEmpty(tips, "tips", null);

            CorpInviteRequest request = new CorpInviteRequest(userId) { InviteTips = tips };
            string url = WeCorpUtil.GetCorpUrl(WeCorpConst.INVITE_SEND,
                WeixinSettings.Current.CorpUserManagerSecret);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new CorpInviteResult());

            return result.Type;
        }
    }
}
