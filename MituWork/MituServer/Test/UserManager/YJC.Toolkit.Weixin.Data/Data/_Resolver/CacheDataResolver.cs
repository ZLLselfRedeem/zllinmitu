using System;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Data
{
    class CacheDataResolver : TableResolver
    {
        public CacheDataResolver(IDbDataSource source)
            : base(MetaDataUtil.CreateTableScheme("CacheData.xml"), source)
        {
        }

        public void WriteObject(string name, object data)
        {
            DataRow row = TrySelectRowWithKeys(name);
            if (row != null)
            {
                row["Data"] = data.WriteJson();
                SetCommands(AdapterCommand.Update);
                UpdateDatabase();
            }
        }

        public object ReadObject(string name)
        {
            DateTime current = DateTime.Now;
            DataRow row = TrySelectRowWithKeys(name);
            IRetriever retriever = PlugInFactoryManager.CreateInstance<IRetriever>(
                WeDataObjectPlugInFactory.REG_NAME, name);
            WeixinResult result;
            if (row == null)
            {
                result = retriever.RetrieveData();
                if (!result.IsError)
                {
                    row = NewRow();
                    row.BeginEdit();
                    row["DataKey"] = row["DataPlug"] = name;
                    row["Data"] = result.WriteJson();
                    row["CreateDate"] = current;
                    row["ValidDate"] = current.AddDays(3);
                    row.EndEdit();
                    SetCommands(AdapterCommand.Insert);
                    UpdateDatabase();
                }
            }
            else
            {
                if (row["ValidDate"].Value<DateTime>() >= current)
                    result = retriever.ReadData(row["Data"].ToString());
                else
                {
                    result = retriever.RetrieveData();
                    if (!result.IsError)
                    {
                        row.BeginEdit();
                        row["Data"] = result.WriteJson();
                        row["ValidDate"] = current.AddDays(3);
                        row.EndEdit();
                        SetCommands(AdapterCommand.Update);
                        UpdateDatabase();
                    }
                }
            }

            return result;
        }
    }
}
