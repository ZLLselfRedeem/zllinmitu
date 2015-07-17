using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Message;

namespace Cxcs.WebData
{
    [Source(Author = "YJC", CreateDate = "2015/01/28",
        Description = "数据源")]
    internal class TestSendMsgSource : ISource
    {

        #region ISource 成员

        public OutputData DoAction(IInputData input)
        {
            string openId = input.QueryString["OpenId"];
            string text = input.QueryString["Text"];
            TextServiceMessage msg = new TextServiceMessage(openId, text);
            msg.Send();

            return OutputData.CreateToolkitObject(new KeyData("OK", string.Empty));
        }

        #endregion
    }
}
