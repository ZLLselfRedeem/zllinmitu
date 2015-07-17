using System;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    class MediaCacheResolver : TableResolver
    {
        private readonly static TimeSpan VALID_TIME = new TimeSpan(2, 20, 0, 0);

        public MediaCacheResolver(IDbDataSource source)
            : base(MetaDataUtil.CreateTableScheme("MediaCache.xml"), source)
        {
        }

        private static void SetMediaRow(DataRow row, MediaId mediaId)
        {
            row["MediaId"] = mediaId.Id;
            row["CreateDate"] = mediaId.CreateTime;
            row["ValidDate"] = mediaId.CreateTime + VALID_TIME;
        }

        public MediaId GetWeixinMediaId(MediaType type, string path)
        {
            DataRow row = TrySelectRowWithKeys(type.ToString(), path);
            if (row == null)
            {
                SetCommands(AdapterCommand.Insert);
                MediaId mediaId = WeUtil.UploadFile(type, path);
                row = NewRow();
                row.BeginEdit();
                row["MediaType"] = type.ToString();
                row["MediaKey"] = path;
                SetMediaRow(row, mediaId);
                row.EndEdit();
                UpdateDatabase();

                return mediaId;
            }
            else
            {
                DateTime validDate = row["ValidDate"].Value<DateTime>();
                if (validDate > DateTime.Now)
                    return new MediaId(row["MediaId"].ToString());
                else
                {
                    SetCommands(AdapterCommand.Update);
                    MediaId mediaId = WeUtil.UploadFile(type, path);
                    row.BeginEdit();
                    SetMediaRow(row, mediaId);
                    row.EndEdit();
                    UpdateDatabase();

                    return mediaId;
                }
            }
        }

        public MediaId GetWeCorpMediaId(string secret, MediaType type, string path)
        {
            DataRow row = TrySelectRowWithKeys(type.ToString(), path);
            if (row == null)
            {
                SetCommands(AdapterCommand.Insert);
                MediaId mediaId = WeCorpUtil.UploadFile(secret, type, path);
                row = NewRow();
                row.BeginEdit();
                row["MediaType"] = type.ToString();
                row["MediaKey"] = path;
                SetMediaRow(row, mediaId);
                row["CorpSecret"] = secret;
                row.EndEdit();
                UpdateDatabase();

                return mediaId;
            }
            else
            {
                DateTime validDate = row["ValidDate"].Value<DateTime>();
                if (validDate > DateTime.Now)
                    return new MediaId(row["MediaId"].ToString());
                else
                {
                    SetCommands(AdapterCommand.Update);
                    MediaId mediaId = WeCorpUtil.UploadFile(secret, type, path);
                    row.BeginEdit();
                    SetMediaRow(row, mediaId);
                    row.EndEdit();
                    UpdateDatabase();

                    return mediaId;
                }
            }
        }
    }
}
