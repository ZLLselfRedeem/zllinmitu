using System;
using YJC.Toolkit.Sys;
using System.Collections.Generic;
using System.IO;
using System.Text;
using YJC.Toolkit.Weixin.Corporation;
using YJC.Toolkit.Weixin.Service;
using YJC.Toolkit.Weixin.Material;

namespace YJC.Toolkit.Weixin
{
    class A 
    {
        public A()
        {
            age = 10;
        }
        public int age { get; set; }
    }

    class B : A 
    {
        public B()
        {
            Borthday = DateTime.Now;
        }
        public DateTime Borthday { get; set; }
    }
    class Program
    {
        private static byte[] GetMultipartsFormData(string boundary, string controlName,
            string fileName, byte[] fileData, string description)
        {
            Encoding encoding = Encoding.UTF8;
            MemoryStream formDataStream = new MemoryStream();
            using (formDataStream)
            {
                bool needsCLRF = false;
                if (needsCLRF)
                {
                    formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));
                }
                needsCLRF = true;
                string header = string.Format(ObjectUtil.SysCulture,
                    "--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                    new object[] { boundary, controlName, Path.GetFileName(fileName), NetUtil.GetContentType(fileName) });
                formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));
                formDataStream.Write(fileData, 0, fileData.Length);

                if (description != null)
                {
                    header = string.Format(ObjectUtil.SysCulture,
                        "\r\n--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n",
                        new object[] { boundary, "description" });
                    formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));
                    byte[] desData = Encoding.ASCII.GetBytes(description);
                    formDataStream.Write(desData, 0, desData.Length);
                }

                string footer = "\r\n--" + boundary + "--\r\n";
                formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));
                return formDataStream.ToArray();
            }
        }
        static void Main(string[] args)
        {
            // 该配置了配置文件路径
            if (!ConsoleApp.Initialize())
                return;

            //string media = @"D:\WebPage\Img\1-1402121AK4-lp.jpg";
            //WeImageMaterial img = new WeImageMaterial(media);
            //var ress = img.Add();

            # region
            //string fileName = @"D:\WebPage\Img\MituHeadImg.jpg";
            //byte[] fileData = File.ReadAllBytes(fileName);
            //var resultList = ServiceAccount.GetAccountList();
            //foreach (var ac in resultList)
            //{
            //    res = ac.UploadHeadImg(fileName, fileData);
            //}

            //KfSession session = new KfSession("zll@mitutools", "oyyPUjvZNtOaKqJ3Nh5KIOOsclGA") { Text = "这是一段附加信息" };
            //var rest = session.Create();
            //rest = session.Close();
            // var result = KfSession.QueryClientSession("oyyPUjvZNtOaKqJ3Nh5KIOOsclGA");
            //var resutl = KfSession.QueryKfSession("zll@mitutools");
            //var res = KfSession.QueryWaitingSession();
            //string test = session.WriteJson();
            //WeixinResult resu = session.Create();
            //var res1 = KfSession.QueryWaitingSession();

            // var result = ServiceSession.GetSeesionRecord(null, new DateTime(2015, 5, 19, 5, 12, 23), new DateTime(2015, 5, 19, 20, 00, 00), 1, 20);

            //WeNewsMaterial news = new WeNewsMaterial(new NewsArticle("Test", "这是测试的一份图文消息", ress.MediaId) { Author = "zll", Digest = "这是摘要", ShowCoverPic = true, ContentSourceUrl = "wwww.baidu.com" });
            //var result = news.Add();
            //var newsArticle = result.CreateNewsMaterial();
            // var re = ServiceAccount.GetAccountList();


            #region
            //CorpAppList list = new CorpAppList();
            //list.ReadJson(DataString.AgentList);
            //CorpAppList agents = CorpAgent.GetAgents();
            //string agentStr = agents.WriteJson();

            //CorpAgentInfo agentInfo = CorpApp.Query(3);
            //string result = agentInfo.WriteJson();
            //agentInfo.ReadJson(DataString.AgentGet);
            //string result = agentInfo.WriteJson();

            //MediaId id = WeCorpUtil.UploadFile("z0tGHPtVrFDHIyr7gstasl6yCsFsQxa2p6Fm2o49iKPPcPCThv9mlHwQiltoU6t6", MediaType.Image, @"D:\WebPage\Img\images (23).jpg");
            //CorpAgent agent = new CorpAgent(3) { ReportLocationFlag = WeThirdPartyLocationFlag.Reported, LogoMediaId = id.Id, Description = "这是最近更新的agent" };
            //var ret = agent.Update();
            
            //agentInfo = CorpAgent.Query(3);
            //result = agentInfo.WriteJson();

            //int a = WeVideoMaterial.TotalCount;
            //var re = WeVideoMaterial.GetMaterials(0, 20);
            //foreach (var id in re.Items)
            //{
            //    WeixinResult resu = id.Delete();
            //}

            //a = WeVideoMaterial.TotalCount;
            //a = WeImageMaterial.TotalCount;
            //a = WeVoiceMaterial.TotalCount;
            //a = WeNewsMaterial.TotalCount;

          
            //WeReplyRule result = WeReplyRule.Get();
           // WeVideoDescription des = new WeVideoDescription("This is a test", "It occurs at 2015-04-13");
           // string desStr = des.WriteJson();
           // string imgPath = @"D:\WebPage\Img\videoTest.mp4";
           // string fileName = @"D:\WebPage\Img\ImageTest.jpg";
           // byte[] fileData = File.ReadAllBytes(fileName);
           // string formDataBoundary = string.Format(ObjectUtil.SysCulture,
           //     "----------{0:N}", Guid.NewGuid());
           // string contentType = "multipart/form-data; boundary=" + formDataBoundary;
           //// byte[] Result = GetMultipartsFormData(formDataBoundary, "media", fileName, fileData, desStr);
           // string url = WeUtil.GetUrl("http://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}");
           // KeyValuePair<string, string> desPair = new KeyValuePair<string, string>("description", desStr);
           //// var result = NetUtil.ReadObjectFromResponse(NetUtil.FormUploadFile(new Uri(url), "media", fileName, desPair), null, new WeMediaId());

            //WeMaterialAdd thumb = new WeMaterialAdd(MediaType.Thumb, @"D:\WebPage\Img\thumb.jpg");
            //string thumbId = WeNewsAdd.MaterialAdd(thumb);
            //string fileName = @"D:\WebPage\Img\thumb.jpg";
            //MediaId mediaId = WeUtil.UploadFile(MediaType.Image, fileName);
            //DownloadMediaData dData = WeUtil.DownloadFile(mediaId.Id);



            //// article 创建
            //WeMaterialAdd video = new WeMaterialAdd(@"D:\WebPage\Img\videoTest.mp4", "吃货", "一个萌萌哒的妹子在进食");
            //string videoId = WeNewsAdd.MaterialAdd(video);
           // WeNewsArticle article1 = new WeNewsArticle("小清新", thumbId, "zll", true, "这是一张有去的图片", "http://mindhacks.cn/");
            //WeNewsAdd news = new WeNewsAdd(article);
            //string newsId = news.NewsAdd();
            //WeNewsAdd newResult = new WeNewsAdd();
            //newResult.MaterialNewsGet(newsId);
           // WeNewsArticle article2 = new WeNewsArticle("狗蛋", thumbId, "zll", true, "这是一张有去的图片", "http://mindhacks.cn/");
           // WeNewsAdd news = new WeNewsAdd(article1, article2);
            //string newsId = news.NewsAdd();
            //WeNewsArticle articleUpdate = new WeNewsArticle("狗蛋", thumbId, "zllandzyd", true, "<p>neirong</p>", "http://mindhacks.cn/");
            //WeNewsAdd update = new WeNewsAdd(articleUpdate);
            //var result = WeNewsAdd.MaterialUpdate(newsId, 0, articleUpdate);
            //WeVideoItem videoResutl = WeNewsAdd.MaterialVideoGet(videoId);

            //var result = WeUtil.UploadFile(url, fileName, fileData, new WeMediaId());
           // var result = WeNewsAdd.MaterialVideoGet(videoId);

            //WeNewsAdd.MateriaGet(thumbId);

            //WeMaterialCount matCount = WeNewsAdd.MaterialCount();
           // WeixinResult wr;

            //WeBatchMaterial testresult = WeNewsAdd.BatchMaterialGet(MediaType.Video, 0, 50);
            //foreach (var item in testresult.Item)
            //{
            //    var result = WeNewsAdd.MaterialDel(item.MediaId);
           // }

            //WeVideoMaterial vm = new WeVideoMaterial(@"D:\WebPage\Img\videoTest.mp4", "进食小视频", "A girl eat cake in caoshimial");
            //string videoId = vm.Add();
            //WeOtherMaterial other = new WeOtherMaterial(@"D:\WebPage\Img\thumb.jpg");
            //string imgId = other.Add();

            //MpNewsArticle mp = new MpNewsArticle("小小图文", imgId, "<p>zhedasldfa这是一段对话</p>");

            //MpNewsArticle mps = new MpNewsArticle("小小图文", imgId, "<p>zhedasldfa这是一段对话</p>") { Author = "zll"};
            //WeNewsMaterial newUpdate = new WeNewsMaterial(mps);

            //WeNewsMaterial news = new WeNewsMaterial(mp, mps);
            //string newsId = news.Add();

            ////var result = WeNewsMaterial.Get(newsId);

            //WeixinResult wxResult = newUpdate.Update(newsId, 0);

            ////result = WeNewsMaterial.Get(newsId);
            //var resul = WeOtherMaterial.Get(imgId);

            //var res = WeBaseMaterial.Count();
            //var resu = WeBaseMaterial.MaterialsGet(MediaType.News, 0, 10);
            //WeixinResult re = WeBaseMaterial.Delete(newsId);
            //var results = WeBaseMaterial.MaterialsGet(MediaType.News, 0, 10);
            //matCount = WeNewsAdd.MaterialCount();
            #endregion

        }

        public static string JsonTest<T>() where T: new()
        {
            T session = new T();
            session.ReadJson(DataString.json);
            return session.WriteJson();
        }

        //private static void TestKf()
        //{

        //    string resStr = null;
        //    var result = ServiceAccount.GetAccountList();

        //    resStr = result.WriteJson();
        //    WeixinResult res = ServiceAccount.Add("test1@mitutools", "test", null);
        //    result = ServiceAccount.GetAccountList();
        //    string fileName = @"D:\WebPage\Img\1-131229113T7-lp.jpg";

        //    foreach (var re in result)
        //    {
        //        res = re.Update("hangzhoumitu");
        //        res = re.Modify("testa3");
        //        res = re.UploadHeadImg("fileName", File.ReadAllBytes(fileName));
        //        result = ServiceAccount.GetAccountList();

        //        res = re.Delete();
        //    }
        //}
        //private static void KFTest()
        //{
        //    WeKFInfo kfInfo0 = WeKFAccount.GetKfInfoList();

        //    WeKFAccount kf1 = new WeKFAccount("test1@mitutools", "test1");
        //    WeKFAccount kf2 = new WeKFAccount("test1@mitutools", "test2");
        //    WeKFAccount kf3 = new WeKFAccount("test3@mitutools", "test10");

        //    kfInfo0 = WeKFAccount.GetKfInfoList();

        //    WeixinResult result1 = kf1.Add();
        //    WeixinResult result4 = kf3.Update();
        //    WeKFInfo kfInfo1 = WeKFAccount.GetKfInfoList();

        //    result1 = kf2.Update();
        //    result1 = kf3.Update();
        //    kfInfo1 = WeKFAccount.GetKfInfoList();

        //    string filePath = @"D:\img1.jpg";
        //    string fileName = "img1.jpg";
        //    byte[] fileData = File.ReadAllBytes(filePath);

        //    WeixinResult resultOfImg = kf1.UploadHeading(fileName, fileData);
        //    WeKFInfo kfi = new WeKFInfo();
        //    kfi.ReadJson(DataString.KF);
        //    string kfResult = kfi.WriteJson();

        //    kfInfo1 = WeKFAccount.GetKfInfoList();

        //    WeixinResult result3 = kf2.Delete();


        //    Console.ReadKey();

        //    KFInfos kfInfos = KFAccount.GetKfList();
        //    WeixinResult result = kf.Delete();
        //    Console.WriteLine(result.WriteJson());
        //}
        private static void SemanticGenericTest()
        {
            //private static void WeRestaurantTest()
            //{
            //string query = "附近有什么川菜";
            //string city = "北京";
            //string category = "restaurant";
            //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
            //    var result = mr.RestaurantQuery();
            //    Console.WriteLine(result.WriteJson());
            //}

            //WeServer<WeRestaurantDetail> result = WeSemanticsUtility.Query<WeRestaurantDetail>(query, category, city, null);
            // WeServer<WeRestaurantDetail> result = new WeServer<WeRestaurantDetail>();
            // result.ReadJson(DataString.Restaurant);
            //string testResult = result.WriteJson();
        }

        //private static void NewsTest()
        //{
        //    string gUrl = "https://qyapi.weixin.qq.com/cgi-bin/message/send?access_token={0}";
        //    SendMessage request = new SendMessage("zllinmitutest", "text", 1, "hello weixin", false);
        //    NewsCorpMessage tuWen = new NewsCorpMessage() { };
        //    tuWen.SetAllUser();

        //    Article atcle = new Article();
        //    //atcle.Description = "C# 2.0 中";
        //    atcle.Title = "C#基础知识系列教学对你说：C# 2.0 中还引入了可空类型，可空类型也是值类型，只是可空类型是包括null的值类型的，下面就介绍下C#2.0中对可空类型的支持具体有哪些内容(最近一直都在思考如何来分享这篇文章的,因为刚开始觉得可空类型使用过程中比较简单,觉得没有讲的必要,但是考虑到这个系列的完整性,决定还是唠叨下吧,希望";
        //    atcle.Description = "回复";
        //    atcle.Url = "http://www.cnblogs.com/zhili/archive/2012/11/23/Nullable.html";
        //    // atcle.PicUrl = "http://pic.baike.soso.com/p/20121025/20121025081910-1797713468.jpg";

        //    Article arc = new Article();
        //    arc.Title = "C# 2.0 中还引入了可空类型，可空类型也是值类型，只是可空类型是包括null的值类型的，下面就介绍下C#2.0中对可空类型的支持具体有哪些内容(最近一直都在思考如何来分享这篇文章的,因为刚开始觉得可空类型使用过程中比较简单,觉得没有讲的必要,但是考虑到这个系列的完整性,决定还是唠叨下吧,希望对一些不熟悉的人有帮";
        //    // arc.Description = "C#基础教学";

        //    Article ac = new Article();
        //    ac.Title = "回复";
        //    ac.Url = "http://www.cnblogs.com/zhili/archive/2012/11/23/Nullable.html";
        //    // ac.Description = "C#基础教学";

        //    tuWen.Add(atcle);
        //    //tuWen.Add(arc);
        //    //tuWen.Add(ac);

        //    string forView = tuWen.WriteJson();
        //    var result = tuWen.Send(0);
        //    string rs = result.WriteJson();
        //    //string url = WeCorpUtil.GetCorpUrl(gUrl, WeixinSettings.Current.CorpUserManagerSecret);
        //    //var result = WeUtil.PostToUri(url, forView, new MsgReturn());
        //    //string rs = result.WriteJson();
        //}

        //private static void AgentTest()
        //{
        //    //CorpAppInfo result = CorpApp.Get(1);
        //    string rer = result.WriteJson();
        //    //CorpAppInfo ai = new CorpAppInfo();
        //    //ai.ReadJson(DataString.AgentGet);
        //    //string aiJson = ai.WriteJson();
        //    Console.WriteLine(result.WriteJson());

        //    CorpApp agentSet = new CorpApp(1) { Description = "用于测试的小应用", RedirectDomain = "www.qq.com" };
        //    agentSet.ReadJson(DataString.AgentSetting);
        //    string dsResult = agentSet.WriteJson();
        //    var weixinResult = agentSet.Set();
        //}

        private static void CategoryTest()
        {
            //WeSkuList wsList = new WeSkuList();
            //var result = wsList.QueryAllSku("537874913");
            //Console.WriteLine(result.WriteJson());
        }

        //private static void KFTest()
        //{
        //    WeKFInfo kfInfo0 = WeKFAccount.GetKfInfoList();

        //    WeKFAccount kf1 = new WeKFAccount("test1@mitutools", "test1");
        //    WeKFAccount kf2 = new WeKFAccount("test1@mitutools", "test2");
        //    WeKFAccount kf3 = new WeKFAccount("test3@mitutools", "test10");

        //    kfInfo0 = WeKFAccount.GetKfInfoList();

        //    WeixinResult result1 = kf1.Add();
        //    WeixinResult result4 = kf3.Update();
        //    WeKFInfo kfInfo1 = WeKFAccount.GetKfInfoList();

        //    result1 = kf2.Update();
        //    result1 = kf3.Update();
        //    kfInfo1 = WeKFAccount.GetKfInfoList();

        //    string filePath = @"D:\img1.jpg";
        //    string fileName = "img1.jpg";
        //    byte[] fileData = File.ReadAllBytes(filePath);

        //    WeixinResult resultOfImg = kf1.UploadHeading(fileName, fileData);
        //    WeKFInfo kfi = new WeKFInfo();
        //    kfi.ReadJson(DataString.KF);
        //    string kfResult = kfi.WriteJson();

        //    kfInfo1 = WeKFAccount.GetKfInfoList();

        //    WeixinResult result3 = kf2.Delete();


        //    Console.ReadKey();

        //    KFInfos kfInfos = KFAccount.GetKfList();
        //    WeixinResult result = kf.Delete();
        //    Console.WriteLine(result.WriteJson());
        //}

 
        //private static void DataStatisticsTest()
        //{
        //    DateTime begTime = new DateTime(2014, 12, 2);
        //    DateTime endTime = new DateTime(2014, 12, 2);

        //    WeDataTimespan dtSpan = new WeDataTimespan(begTime, endTime);
        //    Console.WriteLine(dtSpan.WriteJson());
        //    WeDataUserSummary us = dtSpan.GetUserSummary();
        //    WeDataUserCumulate uc = dtSpan.GetUserCumulate();

        //    var articleSummary = dtSpan.GetArticleSummary();
        //    var articleTotal = dtSpan.GetArticleSummary();
        //    var userRead = dtSpan.GetUserRead();
        //    var userReadHour = dtSpan.GetUserReadHour();
        //    var userReadShare = dtSpan.GetUserShare();
        //    var userShareHour = dtSpan.GetUserShareHour();

        //    var msg = dtSpan.GetUpStreamMsg();
        //    var msgHour = dtSpan.GetUpStreamMsgHour();
        //    var msgWeek = dtSpan.GetUpStreamMsgWeek();
        //    var msgMonth = dtSpan.GetUpStreamMsgMonth();
        //    var msgDist = dtSpan.GetUpStreamMsgDist();
        //    var msgDistWeek = dtSpan.GetUpStreamMsgDistWeek();
        //    var msgDistMonth = dtSpan.GetUpStreamMsgDistMonth();

        //    var interfaceSummary = dtSpan.GetInterfaceSummary();
        //    var interfaceSummaryHour = dtSpan.GetInterfaceSummaryHour();

        //    WeDataTimespan tSpan = new WeDataTimespan(begTime, endTime);
        //    Console.WriteLine(tSpan.WriteJson());
        //    var result = tSpan.GetUserShare();
        //    Console.WriteLine(result.WriteJson());
        //    WeDataUpStreamMsgDist test = new WeDataUpStreamMsgDist();
        //    test.ReadJson(DataString.upstreammsgdist);
        //    Console.WriteLine(test.WriteJson());

        //    var result1 = tSpan.GetArticleSummary();
        //    var result2 = tSpan.GetArticleTotal();
        //    var result3 = tSpan.GetUserReadHour();
        //    var result4 = tSpan.GetUserShareHour();
        //    var res = tSpan.GetUpStreamMsg();

        //    Console.WriteLine(result1.WriteJson());
        //    Console.WriteLine(result2.WriteJson());
        //    Console.WriteLine(result3.WriteJson());
        //    Console.WriteLine(result4.WriteJson());

        //    Console.WriteLine(result2.WriteJson());
        //    Console.WriteLine(result.WriteJson());
        //}

        #region 语义理解测试

        //private static void WeRestaurantTest()
        //{
        //    string query = "附近有什么川菜";
        //    string city = "北京";
        //    string category = "restaurant";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.RestaurantQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeMapTest()
        //{
        //    string query = "我在中关村7天酒店这儿要去希格玛大厦";
        //    string city = "北京";
        //    string category = "map";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.MapQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeNearbyTest()
        //{
        //    string query = "附近有啥100元以内的保龄球馆";
        //    string city = "北京";
        //    string category = "nearby";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.NearbyQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeCouponTest()
        //{
        //    string query = "附近有什么优惠券";
        //    string city = "北京";
        //    string category = "coupon";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var resutl = mr.CouponQuery();
        //    Console.WriteLine(resutl.WriteJson());
        //}

        //private static void WeHotelTest()
        //{
        //    string query = "附近有什么五星级酒店";
        //    string city = "北京";
        //    string category = "hotel";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var resutl = mr.HotelQuery();
        //    Console.WriteLine(resutl.WriteJson());
        //}

        //private static void WeTravelTest()
        //{
        //    string query = "故宫门票多少钱";
        //    string city = "北京";
        //    string category = "travel";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var resutl = mr.TravelQuery();
        //    Console.WriteLine(resutl.WriteJson());
        //}

        //private static void WeFlightTest()
        //{
        //    string query = "查一下明天从北京到上海的南航机票";
        //    string city = "北京";
        //    string category = "flight";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var resutl = mr.FlightQuery();
        //    Console.WriteLine(resutl.WriteJson());
        //}

        //private static void WeTrainTest()
        //{
        //    string query = "明天从北京到上海的软卧";
        //    string city = "北京";
        //    string category = "train";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.TrainQuery();
        //    //WeTrain test = new WeTrain();
        //    //test.ReadJson(DataString.SeatTest);
        //    //Console.WriteLine(test.WriteJson());

        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeMovieTest()
        //{
        //    string query = "最近上映了哪些刘德华的电影";
        //    string city = "北京";
        //    string category = "movie";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.MovieQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeMusicTest()
        //{
        //    string query = "我想听周杰伦的东风破";
        //    string city = "北京";
        //    string category = "music";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.MusicQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeVideoTest()
        //{
        //    string query = "我想看李连杰的电影";
        //    string city = "北京";
        //    string category = "video";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.VideoQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeNovelTest()
        //{
        //    string query = "来电言情小说";
        //    string city = "北京";
        //    string category = "novel";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.NovelQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeWeatherTest()
        //{
        //    string query = "未来三天北京天气预报";
        //    string city = "北京";
        //    string category = "weather";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.WeatherQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeStockTest()
        //{
        //    string query = "查一下腾讯股价";
        //    string city = "北京";
        //    string category = "stock";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.StockQuery();
        //    //WeStock test = new WeStock();
        //    //test.ReadJson(DataString.StockResult);
        //    //Console.WriteLine(test.WriteJson());
        //    //Console.WriteLine("resutl:");
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeRemindTest()
        //{
        //    string query = "提醒一下我明天上午十点开会";
        //    string city = "北京";
        //    string category = "remind";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.RemindQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeTelephoneTest()
        //{
        //    string query = "招行的客服电话";
        //    string city = "北京";
        //    string category = "telephone";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.TelephoneQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeCookbookTest()
        //{
        //    string query = "豆腐能做什么菜";
        //    string city = "北京";
        //    string category = "cookbook";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.CookbookQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeBaikeTest()
        //{
        //    string query = "刘德华是谁";
        //    string city = "北京";
        //    string category = "baike";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.BaikeQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeNewsTest()
        //{
        //    string query = "有什么刘德华的新闻";
        //    string city = "北京";
        //    string category = "news";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.NewsQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeTvTest()
        //{
        //    string query = "非诚勿扰什么时候播放";
        //    string city = "北京";
        //    string category = "tv";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.TvQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeInstructionTest()
        //{
        //    string query = "打开静音模式";
        //    string city = "北京";
        //    string category = "instruction";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.InstructionQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeTvInstructionTest()
        //{
        //    string query = "把北京卫视设置为1台";
        //    string city = "北京";
        //    string category = "tv_instruction";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.TvInstructionQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeCarInstructionTest()
        //{
        //    string query = "请将司机旁的窗户打开";
        //    string city = "北京";
        //    string category = "car_instruction";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.CarInstructionQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeAppTest()
        //{
        //    string query = "帮我打开愤怒的小鸟";
        //    string city = "北京";
        //    string category = "app";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.AppQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeWebsiteTest()
        //{
        //    string query = "我要浏览腾讯网";
        //    string city = "北京";
        //    string category = "website";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.WebsiteQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        //private static void WeSearchTest()
        //{
        //    string query = "百度一下意大利对乌拉圭";
        //    string city = "北京";
        //    string category = "search";
        //    WeSemanticRequest mr = new WeSemanticRequest(query, category, city);
        //    var result = mr.SearchQuery();
        //    Console.WriteLine(result.WriteJson());
        //}

        #endregion

        //private static void ReadWeixinUser()
        //{
        //    WeFanContainter container = WeFanContainter.GetFans();

        //    foreach (var openId in container.OpenIds)
        //    {
        //        WeUser user = WeUser.GetUser(openId);
        //        Console.WriteLine(user);
        //    }
        //}

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
            #endregion
    }
}
