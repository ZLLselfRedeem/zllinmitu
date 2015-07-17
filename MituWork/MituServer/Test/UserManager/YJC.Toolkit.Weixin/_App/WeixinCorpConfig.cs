using YJC.Toolkit.Decoder;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    internal class WeixinCorpConfig : BaseItemConfig, IRegName, IDecoderItem
    {
        #region IRegName 成员

        public string RegName
        {
            get
            {
                return AppId.ToString(ObjectUtil.SysCulture);
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

        string IDecoderItem.Name
        {
            get
            {
                return AppName;
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

        [SimpleAttribute]
        public int AppId { get; private set; }

        [SimpleAttribute]
        public string AppName { get; private set; }
    }
}
