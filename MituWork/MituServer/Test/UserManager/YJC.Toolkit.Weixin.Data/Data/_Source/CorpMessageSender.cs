using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Data
{
    [TypeScheme(Author = "YJC", CreateDate = "2014-12-19", Description = "微信企业号发送信息结构")]
    [RegType(Author = "YJC", CreateDate = "2014-12-19", Description = "微信企业号发送信息结构")]
    internal class CorpMessageSender
    {
        [SimpleElement(Order = 10)]
        [FieldControl(ControlType.Combo, Order = 10)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("目标")]
        [FieldDecoder("CorpSendTarget")]
        [FieldInfo(IsEmpty = false)]
        public CorpSendTarget Target { get; set; }

        [SimpleElement(Order = 20)]
        [FieldControl(ControlType.Combo, Order = 90)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("应用")]
        [FieldDecoder("WeixinCorp")]
        [FieldInfo(IsEmpty = false)]
        public int AppId { get; set; }

        [FieldControl(ControlType.Combo, Order = 30)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("标签")]
        [FieldDecoder("CorpTag")]
        [SimpleElement(Order = 30)]
        public string TagId { get; set; }

        [SimpleElement(Order = 40)]
        [FieldControl(ControlType.Combo, Order = 40)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("组织")]
        [FieldDecoder(DecoderType.EasySearch, "CorpDepartment")]
        public string DepartmentId { get; set; }

        [SimpleElement(Order = 50)]
        [FieldControl(ControlType.Text, Order = 50)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("用户")]
        //[FieldDecoder("WeixinCorp")]
        public string UserId { get; set; }

        [SimpleElement(Order = 100)]
        [FieldControl(ControlType.TextArea, Order = 100)]
        [FieldLayout(FieldLayout.PerLine)]
        [DisplayName("内容")]
        [FieldInfo(IsEmpty = false)]
        public string MessageText { get; set; }

        public void SendMessage()
        {
            TextCorpMessage message = new TextCorpMessage(MessageText);
            switch (Target)
            {
                case CorpSendTarget.All:
                    message.SetAllUser();
                    break;
                case CorpSendTarget.Tag:
                    message.SetTag(TagId.Value<int>());
                    break;
                case CorpSendTarget.Department:
                    message.SetParty(DepartmentId.Value<int>());
                    break;
                case CorpSendTarget.User:
                    message.SetUser(UserId);
                    break;
            }
            message.Send(AppId);
        }
    }
}
