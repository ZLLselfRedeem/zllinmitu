using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Weixin.Data
{
    /// <summary>
    ///  微信关注记录(WE_SUBSCRIBE_DATA)的数据访问层类
    /// </summary>
    internal class SubscribeDataResolver : TableResolver
    {
        /// <summary>
        /// 建构函数，设置附着的Xml文件。
        /// </summary>
        /// <param name="context">数据库连接上下文</param>
        /// <param name="source">附着的数据源</param>
        public SubscribeDataResolver(IDbDataSource source)
            : base(MetaDataUtil.CreateTableScheme("SubscribeData.xml"), source)
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
                    e.Row["SD_ID"] = Context.GetUniId(TableName);
                    break;
                case UpdateKind.Update:
                    break;
            }
        }
    }
}