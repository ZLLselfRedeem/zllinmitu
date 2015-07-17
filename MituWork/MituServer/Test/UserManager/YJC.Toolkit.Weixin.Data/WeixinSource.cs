using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin
{
    public sealed class WeixinSource : ISource
    {
        #region ISource 成员

        public OutputData DoAction(IInputData input)
        {
            if (!input.IsPost)
            {
                if (WeUtil.CheckSignature(input.QueryString[QueryStringConst.QS_SIGNATURE],
                    input.QueryString[QueryStringConst.QS_TIMESTAMP],
                    input.QueryString[QueryStringConst.QS_NONCE]))
                {
                    return OutputData.Create(input.QueryString[QueryStringConst.QS_ECHO_STR]);
                }
                return OutputData.Create("验名错误");
            }
            else
            {
                ReceiveMessage message = input.PostObject.Convert<ReceiveMessage>();
                BaseSendMessage result = WeixinToolkitSettings.Current.NormalReply(message);
                WeixinToolkitSettings.Current.Log(message);

                if (result != null)
                {
                    string encodeType = input.QueryString[QueryStringConst.QS_ENCODE_TYPE]
                        .Value<string>(QueryStringConst.NORMAL_MSG);
                    if (encodeType == QueryStringConst.NORMAL_MSG)
                        return OutputData.CreateToolkitObject(result);
                    else
                    {
                        EncodeReplyMessage reply = WeUtil.EncryptMsg(result.ToXml(),
                            input.QueryString[QueryStringConst.QS_TIMESTAMP],
                            input.QueryString[QueryStringConst.QS_NONCE]);
                        return OutputData.CreateToolkitObject(reply);
                    }
                }
                else
                    return OutputData.Create(string.Empty);
            }
        }

        #endregion
    }
}
