using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.User
{
    internal class WeixinAuthConfig : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "State",
            ObjectType = typeof(AuthStateConfig))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "DetailState",
            ObjectType = typeof(DetailAuthStateConfig))]
        public RegNameList<AuthStateConfig> States { get; private set; }

        public string GetStateUrl(string state)
        {
            if (string.IsNullOrEmpty(state) || States == null)
                return null;

            string[] data = state.Split('-');
            var config = States[data[0]];
            if (config == null)
                return null;

            return config.GetUrl(data.Length == 2 ? data[1] : string.Empty);
        }
    }
}
