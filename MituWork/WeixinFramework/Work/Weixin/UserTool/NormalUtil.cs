using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;
using YJC.Toolkit.Weixin.User;
using YJC.Toolkit.Weixin.Message;

namespace YJC.Toolkit.Weixin.UserTool
{
    internal class NormalUtil
    {
        public static void DownSync()
        {
            WeFanContainter container = WeFanContainter.GetFans();
            DateTime timeNow = DateTime.Now;
            int timeVersion = (int)timeNow.ToOADate();

            // 公众号测试
            string description = "这是一家创立于北京中关村，致力于向人们提供“简单，可依赖”的信息获取方式";
            string picUrl = "http://p.img.eol.cn/images/1022/2011/0919/1316394859_12_iyeh.jpg";
            Article ar = new Article()
            {
                Title = "企业简介",
                Description = description,
                Url = "http://baike.sogou.com/v6234.htm",
                PicUrl = picUrl
            };
            //NewsCorpMessage n = new NewsCorpMessage();
            //n.SetAllUser();
            //n.Add(ar);
            //WeixinResult result = n.Send(1);

            string oppid = "oyyPUjvZNtOaKqJ3Nh5KIOOsclGA";
            NewsServiceMessage nMsg = new NewsServiceMessage(oppid);
            //TextServiceMessage tMsg = new TextServiceMessage(oppid, "你们在干什么呢？");
            nMsg.Add(ar);
            //WeixinResult result = nMsg.Send();
            WeixinResult result = nMsg.Send();
            Console.WriteLine(result);
            //公众号测试

            using (EmptyDbDataSource source = new EmptyDbDataSource())
            using (TableResolver resolver = new TableResolver("WE_USER", source))
            using (TableResolver subResolver = new TableResolver("WE_SUBSCRIBE_DATA", source))
            {
                subResolver.SetCommands(AdapterCommand.Insert);
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
                        {
                            row = resolver.NewRow();
                            DataRow subRow = subResolver.NewRow();
                            subRow.BeginEdit();
                            subRow["Id"] = subResolver.CreateUniId();
                            subRow["OpenId"] = openId;
                            subRow["SubscribeDate"] = user.SubscribeTime;
                            subRow["IsSubscribe"] = 1;
                            subRow.EndEdit();
                        }
                        user.AddToDataRow(row, WeConst.USER_MODE);
                        row["Version"] = timeVersion;
                    }
                    UpdateUtil.UpdateTableResolvers(source.Context, (Action<Transaction>)null, resolver, subResolver);
                    resolver.HostTable.Rows.Clear();
                    //subResolver.HostTable.Rows.Clear();
                    if (string.IsNullOrEmpty(container.NextOpenId))
                        break;
                    else
                        container = WeFanContainter.GetFans(container);
                }

                resolver.HostTable.Rows.Clear();
                // subResolver.HostTable.Rows.Clear();
                IParamBuilder builder = SqlParamBuilder.CreateParamBuilder(
                    SqlParamBuilder.CreateSingleSql(source.Context, "WU_VERSION", TkDataType.Int, "!=", timeVersion),
                    ParamBuilder.CreateSql("WU_SUBSCRIBE = 1"));

                resolver.Select(builder);
                if (resolver.HostTable.Rows.Count > 0)
                {
                    foreach (DataRow row in resolver.HostTable.Rows)
                    {
                        row["subscribe"] = 0;
                        DataRow subRow = subResolver.NewRow();
                        subRow.BeginEdit();
                        subRow["Id"] = subResolver.CreateUniId();
                        subRow["OpenId"] = row["OpenId"];
                        subRow["Subscribe"] = DateTime.Now;
                        subRow["IsSubscribe"] = 0;
                        subRow.EndEdit();
                    }
                    UpdateUtil.UpdateTableResolvers(source.Context, (Action<Transaction>)null, resolver, subResolver);
                }
            }
        }
    }
}
