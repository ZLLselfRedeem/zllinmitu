using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Rule
{
    [Expression(Author = "YJC", CreateDate = "2014-03-16",
       Description = "获取微信消息中用户的OpenId，要求参数中传入ReceiveMessage")]
    internal class OpenIdExpression : IExpression, ICustomData
    {
        private ReceiveMessage fMessage;

        #region IExpression 成员

        public string Execute()
        {
            return fMessage.FromUserName;
        }

        #endregion

        #region ICustomData 成员

        public void SetData(params object[] args)
        {
            fMessage = ObjectUtil.ConfirmQueryObject<ReceiveMessage>(this, args);
            //TkDebug.AssertNotNull(fMessage,
            //    "宏OpenId需要ReceiveMessage对象，但是没有从外部对象中找到", this);
        }

        #endregion
    }
}
