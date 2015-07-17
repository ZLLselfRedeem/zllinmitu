using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Data
{
    /// <summary>
    ///  微信组(WE_GROUP)的数据访问层类
    /// </summary>
    internal class InternalCorpUserResolver : TableResolver
    {
        public InternalCorpUserResolver(IDbDataSource source)
            : base(MetaDataUtil.CreateTableScheme("CorpUser.xml"), source)
        {
        }


        /// <summary>
        /// 在表发生新建、修改和删除的时候触动。注意，千万不要删除base.OnUpdatingRow(e);
        /// UpdatingRow事件附着在基类该函数中。
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            switch (e.Status)
            {
                case UpdateKind.Insert:
                    e.Row["WG_ID"] = Context.GetUniId(TableName);
                    break;
                case UpdateKind.Update:
                    break;
            }
        }
    }
}