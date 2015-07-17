using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public abstract class GroupMassMessage : BaseMassMessage
    {
        protected GroupMassMessage(int groupId)
        {
            GroupId = groupId;
        }

        [TagElement(LocalName = "filter", Order = 10)]
        [SimpleElement(LocalName = "group_id")]
        public int GroupId { get; protected set; }

        public long Send()
        {
            string url = WeUtil.GetUrl(WeConst.GROUP_MASS_MESSAGE_URL);
            var msg = WeUtil.PostToUri(url, this.WriteJson(), new MassMessageResult());
            return msg.ResultId;
        }
    }
}
