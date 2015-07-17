using System;
using System.Collections;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    public abstract class BaseWeixinListSource : IListObjectSource
    {
        protected BaseWeixinListSource()
        {
        }

        #region IObjectListSource 成员

        public Tuple<ListSortInfo, CountInfo, object> CreatePageInfo(IInputData input,
            int pageNumber, int pageSize)
        {
            ListSortInfo list = new ListSortInfo(input);
            CountInfo pageInfo = new CountInfo(Count, 0, Count == 0 ? 1 : Count);
            return Tuple.Create<ListSortInfo, CountInfo, object>(list, pageInfo, null);
        }

        public IEnumerable GetList(object queryContext, IInputData input, int start, int pageSize)
        {
            return AllData;
        }

        #endregion

        protected abstract int Count { get; }

        protected abstract IEnumerable AllData { get; }
    }
}
