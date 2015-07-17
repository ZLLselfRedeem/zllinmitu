using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    internal class AuthStateConfig : IRegName
    {
        [SimpleAttribute]
        public string Key { get; protected set; }

        [SimpleAttribute]
        public string Url { get; protected set; }

        #region IRegName 成员

        public string RegName
        {
            get
            {
                return Key;
            }
        }

        #endregion

        public virtual string GetUrl(string id)
        {
            return Url;
        }
    }
}
