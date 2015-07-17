using System;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    class WeixinCorpAuthConfig : ToolkitConfig
    {
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "State",
           ObjectType = typeof(CorpAuthStateConfig))]
        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "DetailState",
            ObjectType = typeof(CorpDetailAuthStateConfig))]
        public RegNameList<CorpAuthStateConfig> States { get; private set; }

        public Tuple<int, string> GetStateUrl(string state)
        {
            if (string.IsNullOrEmpty(state) || States == null)
                return null;

            string[] data = state.Split('-');
            var config = States[data[0]];
            if (config == null)
                return null;

            return Tuple.Create(config.AppId,
                config.GetUrl(data.Length == 2 ? data[1] : string.Empty));
        }
    }
}
