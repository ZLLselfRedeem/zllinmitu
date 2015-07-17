using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Data
{
    [EasySearch(Author = "YJC", CreateDate = "2015-01-03", Description = "公众号用户的EasySearch")]
    class WeUserEasySearch : BaseSchemeEasySearch
    {
        public WeUserEasySearch(ITableScheme scheme)
            : base(scheme)
        {
            ContextName = "Weixin";
        }
    }
}
