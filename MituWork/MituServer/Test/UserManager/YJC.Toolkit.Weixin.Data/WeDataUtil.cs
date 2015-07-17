using System;
using YJC.Toolkit.BaiduMap;
using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Data;

namespace YJC.Toolkit.Weixin
{
    public static class WeDataUtil
    {
        public static string GetSXCode(TkDbContext context, string province, string city)
        {
            return GetSXCode(context, province, city, "000000");
        }

        public static string GetSXCode(TkDbContext context, string province, string city,
            string defaultCode)
        {
            TkDebug.AssertArgumentNull(context, "context", null);

            if (string.IsNullOrEmpty(province) || string.IsNullOrEmpty(city))
                return defaultCode;

            const string sql = "SELECT MIN(CODE_VALUE) FROM CD_SX";
            IParamBuilder builder = SqlParamBuilder.CreateParamBuilder(
                SqlParamBuilder.CreateEqualSql(context, "CODE_WX_PROVINCE", TkDataType.String, province),
                SqlParamBuilder.CreateEqualSql(context, "CODE_WX_CITY", TkDataType.String, city));
            object value = DbUtil.ExecuteScalar(sql, context, builder);
            if (value == DBNull.Value)
                return defaultCode;
            return value.ToString();
        }

        public static string GetSXCode(TkDbContext context, double latitude, double longitude)
        {
            TkDebug.AssertArgumentNull(context, "context", null);

            var result = MapUtil.GetAddress(latitude, longitude);
            if (result.Status == 0 && !string.IsNullOrEmpty(result.Result.CityCode))
            {
                IParamBuilder builder = SqlParamBuilder.CreateEqualSql(context, "CODE_VALUE",
                    TkDataType.Int, result.Result.CityCode);
                object value = DbUtil.ExecuteScalar("SELECT CODE_GB FROM CD_BAIDU_CITY", context, builder);
                if (value == DBNull.Value)
                    return "000000";
                return value.ToString();
            }
            return "000000";
        }

        private static string CreateCacheKey(MediaType mediaType, string path)
        {
            return string.Format(ObjectUtil.SysCulture, "{0}+{1}", mediaType, path);
        }

        public static string GetMediaId(MediaType mediaType, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            string key = CreateCacheKey(mediaType, path);
            MediaId result = CacheManager.GetItem("WeixinMedia", key, mediaType, path).Convert<MediaId>();
            return result.Id;
        }

        public static string GetMediaId(int appId, MediaType mediaType, string path)
        {
            string secret = WeixinSettings.Current.GetCorpSecret(appId);

            return GetMediaId(secret, mediaType, path);
        }

        public static string GetMediaId(string secret, MediaType mediaType, string path)
        {
            TkDebug.AssertArgumentNullOrEmpty(secret, "secret", null);
            TkDebug.AssertArgumentNullOrEmpty(path, "path", null);

            string key = CreateCacheKey(mediaType, path);
            MediaId result = CacheManager.GetItem("WeCorpMedia", key, mediaType,
                path, secret).Convert<MediaId>();
            return result.Id;
        }

        internal static void SaveData(string name, object data)
        {
            using (WeixinDataSource source = new WeixinDataSource())
            using (CacheDataResolver resolver = new CacheDataResolver(source))
            {
                resolver.WriteObject(name, data);
            }
        }

        internal static EmptyDbDataSource CreateSource()
        {
            EmptyDbDataSource source = new EmptyDbDataSource()
            {
                Context = DbContextUtil.CreateDbContext("Weixin")
            };
            return source;
        }

        internal static T GetCacheData<T>(string name) where T : class
        {
            T result = CacheManager.GetItem("WeixinListData", name).Convert<T>();
            return result;
        }
    }
}
