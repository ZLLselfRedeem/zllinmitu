using YJC.Toolkit.Decoder;

namespace YJC.Toolkit.Weixin
{
    [CodeTable(Author = "YJC", CreateDate = "2014-10-30",
        Description = "提供系统配置模板消息的代码表")]
    class WeixinTemplateMessageCodeTable : DataCodeTable
    {
        public WeixinTemplateMessageCodeTable()
        {
            var codeTables = WeixinSettings.Current.TemplateMessages;

            if (codeTables != null)
                foreach (var item in codeTables)
                    Add(item);
        }
    }
}
