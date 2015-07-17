using System.Collections.Generic;
using System.Drawing;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Message
{
    public class TemplateMessage
    {
        public TemplateMessage(string toUser, string templateName)
        {
            TkDebug.AssertArgumentNullOrEmpty(toUser, "toUser", null);
            TkDebug.AssertArgumentNullOrEmpty(templateName, "templateName", null);

            Data = new Dictionary<string, TemplateKeyData>();
            ToUser = toUser;
            TemplateId = WeixinSettings.Current.GetTemplateId(templateName);
        }

        [SimpleElement(LocalName = "touser", Order = 10)]
        public string ToUser { get; private set; }

        [SimpleElement(LocalName = "template_id", Order = 20)]
        public string TemplateId { get; private set; }

        [SimpleElement(NamingRule = NamingRule.Camel, Order = 30)]
        public string Url { get; set; }

        [SimpleElement(LocalName = "topcolor", Order = 40)]
        [TkTypeConverter(typeof(ColorTypeConverter))]
        public Color TopColor { get; set; }

        [ObjectDictionary(NamingRule = NamingRule.Camel, Order = 50)]
        public Dictionary<string, TemplateKeyData> Data { get; private set; }

        public long Send()
        {
            string url = WeUtil.GetUrl(WeConst.TEMPLATE_MESSAGE_URL);

            TemplateMessageResult result = new TemplateMessageResult();
            result = WeUtil.PostToUri(url, this.WriteJson(), result);
            if (result.IsError)
                return -1L;
            return result.MsgId;
        }
    }
}
