using System;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.Data
{
    /// <summary>
    ///  微信地理位置(WE_USER_LOCATION)的数据访问层类
    /// </summary>
    internal class UserLocationResolver : TableResolver
    {
        /// <summary>
        /// 建构函数，设置附着的Xml文件。
        /// </summary>
        /// <param name="context">数据库连接上下文</param>
        /// <param name="source">附着的数据源</param>
        public UserLocationResolver(IDbDataSource source)
            : base(MetaDataUtil.CreateTableScheme("UserLocation.xml"), source)
        {

        }

        public void Insert(ReceiveMessage message)
        {
            DataRow row = NewRow();
            row.BeginEdit();
            row["Id"] = Context.GetUniId(TableName);
            row["OpenId"] = message.FromUserName;
            row["CreateDate"] = DateTime.Now;
            row["Latitude"] = message.Latitude;
            row["Longitude"] = message.Longitude;
            row["Precision"] = message.Precision;
            row["CityCode"] = WeDataUtil.GetSXCode(Context, message.Latitude, message.Longitude);
            row.EndEdit();
            SetCommands(AdapterCommand.Insert);
            UpdateDatabase();
        }
    }
}