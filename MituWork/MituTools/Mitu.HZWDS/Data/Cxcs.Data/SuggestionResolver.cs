using System;
using YJC.Toolkit.Data;

namespace Cxcs.Data
{
    [Resolver(Author = "YJC", CreateDate = "2014-08-07",
        Description = "意见咨询(CS_SUGGESTION)的数据访问层类")]
    class SuggestionResolver : Tk5TableResolver
    {
        internal const string DATAXML = "CXCS/Suggestion.xml";

        public SuggestionResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
        }

        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            switch (e.Status)
            {
                case UpdateKind.Insert:
                    e.Row["SugId"] = CreateUniId();
                    e.Row["CreateDate"] = DateTime.Now;
                    break;
                case UpdateKind.Update:
                    break;
                case UpdateKind.Delete:
                    break;
            }
        }
    }
}
