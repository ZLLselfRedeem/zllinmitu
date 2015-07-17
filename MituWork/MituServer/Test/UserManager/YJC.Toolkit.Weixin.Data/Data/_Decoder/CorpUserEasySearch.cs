using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Data
{
    [EasySearch(Author = "YJC", CreateDate = "2015-01-03", Description = "企业用户的EasySearch")]
    class CorpUserEasySearch : BaseSchemeEasySearch
    {
        public CorpUserEasySearch()
            : base(MetaDataUtil.CreateTableScheme("CorpEasySearchUser.xml"))
        {
            ContextName = "Weixin";
        }
    }
}
