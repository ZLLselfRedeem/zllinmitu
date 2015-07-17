using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin
{
    public sealed class WeixinCorpSource : ISource
    {
        #region ISource 成员

        public OutputData DoAction(IInputData input)
        {
            if (!input.IsPost)
            {
                int appId = input.QueryString["AppId"].Value<int>();
                string returnStr = WeCorpUtil.VerifyURL(appId,
                    input.QueryString[QueryStringConst.QS_MSG_SIGNATURE],
                    input.QueryString[QueryStringConst.QS_TIMESTAMP],
                    input.QueryString[QueryStringConst.QS_NONCE],
                    input.QueryString[QueryStringConst.QS_ECHO_STR]);
                if (!string.IsNullOrEmpty(returnStr))
                {
                    return OutputData.Create(returnStr);
                }
                return OutputData.Create("验名错误");
            }
            else
            {
                if (input.PostObject == null)
                    return OutputData.Create(string.Empty);

                ReceiveMessage message = input.PostObject.Convert<ReceiveMessage>();
                BaseSendMessage result = WeixinToolkitSettings.Current.CorpReply(message);
                EncodeReplyMessage reply;
                if (result != null)
                    reply = WeCorpUtil.EncryptMsg(message.AgentId, result.ToXml(),
                        input.QueryString[QueryStringConst.QS_TIMESTAMP],
                        input.QueryString[QueryStringConst.QS_NONCE]);
                else
                    reply = null;

                WeixinToolkitSettings.Current.Log(message);

                if (result != null)
                    return OutputData.CreateToolkitObject(reply);
                else
                    return OutputData.Create(string.Empty);
            }
        }

        #endregion
    }
}
