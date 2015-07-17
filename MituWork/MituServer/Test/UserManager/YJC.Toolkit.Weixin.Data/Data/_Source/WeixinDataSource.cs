using System;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    internal sealed class WeixinDataSource : IDbDataSource, IDisposable
    {
        public WeixinDataSource()
        {
            DataSet = new DataSet() { Locale = ObjectUtil.SysCulture };
            Context = DbContextUtil.CreateDbContext("Weixin");
        }

        #region IDbDataSource 成员

        public DataSet DataSet { get; private set; }

        public TkDbContext Context { get; private set; }

        #endregion

        #region IDisposable 成员

        public void Dispose()
        {
            DataSet.Dispose();
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
