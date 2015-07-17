using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;
using YJC.Toolkit.Weixin.User;
using YJC.Toolkit.Weixin;
using YJC.Toolkit.MetaData;

namespace TestSemantic
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!ConsoleApp.Initialize())
                return;

            DownSync();

            Console.ReadKey();
        }

        private static void DownSync()
        {
            WeFanContainter container = WeFanContainter.GetFans();
            DateTime timeNow = DateTime.Now;
            int timeVersion = (int)timeNow.ToOADate();

            using (EmptyDbDataSource source = new EmptyDbDataSource())
            using (TableResolver resolver = new TableResolver("WE_USER", source))
            {
                resolver.SetCommands(AdapterCommand.Insert | AdapterCommand.Update);
                while (true)
                {
                    if (container.OpenIds == null)
                        break;
                    foreach (var openId in container.OpenIds)
                    {
                        WeUser user = WeUser.GetUser(openId);
                        DataRow row = resolver.TrySelectRowWithKeys(openId);
                        if (row == null)
                            row = resolver.NewRow();
                        user.AddToDataRow(row, WeConst.USER_MODE);
                        row["Version"] = timeVersion;
                    }
                    resolver.UpdateDatabase();
                    resolver.HostTable.Rows.Clear();
                    if (string.IsNullOrEmpty(container.NextOpenId))
                        break;
                    else
                        container = WeFanContainter.GetFans(container);
                }

                resolver.HostTable.Rows.Clear();
                IParamBuilder builder = SqlParamBuilder.CreateParamBuilder(
                    SqlParamBuilder.CreateSingleSql(source.Context, "WU_VERSION", TkDataType.Int, "!=", timeVersion),
                    ParamBuilder.CreateSql("WU_SUBSCRIBE = 1"));
                resolver.Select(builder);
                foreach (DataRow row in resolver.HostTable.Rows)
                {
                    row["subscribe"] = 0;
                }
                resolver.UpdateDatabase();
            }
        }

        //private static void ReadUser()
        //{
        //    var list = CorpDepartment.GetAllUsers(1, true);
        //    foreach (CorpSimpleUser item in list.UserList)
        //    {
        //        Console.WriteLine(item);
        //    }
        //}

        //private static void ReadDb()
        //{
        //    EmptyDbDataSource source = new EmptyDbDataSource();
        //    TableResolver resolver = new TableResolver("WE_CORP_USER", source);

        //    resolver.Select();
        //    foreach (DataRow row in resolver.HostTable.Rows)
        //    {
        //        CorpUser user = new CorpUser("1", "user", new int[] {1});
        //        user.ReadFromDataRow(row, "CorpUser");
        //        Console.WriteLine(user);
        //    }
        //}
    }
}
