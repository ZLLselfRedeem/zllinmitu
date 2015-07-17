using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;
using System.Linq;
using ConvertToJson;
using System.IO;
using System.Text;


namespace YJC.Toolkit.Weixin.Shop
{
    class CorTest
    {
        public CorTest(int i)
        {
            iField = i;
            intField = i;
        }
        public string sField { get; set; }
        public int iField { get; private set; }
        public int intField { get; set; }
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
            ToolApp.Initialize(false);
            // 注意这种形式不是命名参数
            // 对象初始化器

            //WeVideoDescription des = new WeVideoDescription("This is a test", "It occurs at 2015-04-13");
            //string desStr = des.WriteJson();
            //string imgPath = @"D:\WebPage\Img\ImageTest.jpg";
            //string fileName = "ImageTest.jpg";
            //byte[] fileData = File.ReadAllBytes(imgPath);
            //string formDataBoundary = string.Format(ObjectUtil.SysCulture,
            //    "----------{0:N}", Guid.NewGuid());
            //string contentType = "multipart/form-data; boundary=" + formDataBoundary;
            //byte[] Result = GetMultipartsFormData(formDataBoundary, "media", fileName, fileData, desStr);
            //ASCIIEncoding encoding = new ASCIIEncoding();
            //string resStr = encoding.GetString(Result);

            //
            // 等价如下的形式：？？？
            //
            //CorTest ct2 = new CorTest(5);
            //ct2.intField = 10;
            //ct2.sField = "Hello corr";
        }

        //private static void CardTest()
        //{
        //    //LocationInit li1 = new LocationInit("麦当劳", "浙江", "杭州市", "西湖区", "浙江省杭州市西湖区东部软件园2号楼", "0571-1325641", "软件开发区", 115.23563, 36.2563251) { BranchName = "赤岗店" };
        //    //LocationInit li2 = new LocationInit("麦当劳", "浙江", "杭州市", "西湖区", "浙江省杭州市西湖区zhejiangdax", "0571-1325641", "软件开发区", 115.23563, 36.2563251) { BranchName = "紫金港店" };
        //    //WeLocationBatchAdd locationAdd = new WeLocationBatchAdd(li1, li2);
        //    //string resultTest = locationAdd.WriteJson();
        //    //WeLocationId lId = new WeLocationId();
        //    //lId.ReadJson(DataString.LocationBatchAddResult);
        //    //string LocationAddResult = lId.WriteJson();
        //    //WeLocationBatchGet locationGet = new WeLocationBatchGet(0, 2);
        //    //resultTest = locationGet.WriteJson();
        //    //WeLocationBatch locationBtach = new WeLocationBatch();
        //    //locationBtach.ReadJson(DataString.LocationBatchGetResult);
        //    //resultTest = locationBtach.WriteJson();
        //    //WeColors color = new WeColors();
        //    //color.ReadJson(DataString.Color);
        //    //resultTest = color.WriteJson();

        //    //CardBaseInfo baseInfo = new CardBaseInfo("//http:www.supadmin.cn/uploads/allimg/120216/1_120216214725_1.jpg", 
        //    //    CodeType.CodeTypeText, "海底捞", "132元双人火锅套餐","Color010", "使用时向服务员出示此券", 
        //    //    "不可与其他餐前不可打本单谢绝自带酒水饮料", new DateInfo(new DateTime(2014, 12, 14), new DateTime(2015, 2, 3)), 50000000);
        //    //Groupon go = new Groupon(baseInfo, "以下过低");
        //    //CardInfo cardInfo = new CardInfo(CardType.GroupOn, go);
        //    //WeCard wc = new WeCard(cardInfo);
        //    WeQrcodeCreate qrCode = new WeQrcodeCreate("QR_CARD", new QrcodeInfo("pF57Fjg") { Code = "13123", OpenId = "asdf", ExpireSeconds = 1800, IsUniqueCode = false, OuterId = 1 });
        //    string resultTest = qrCode.WriteJson();
        //    WeQrcodeTicket ticket = new WeQrcodeTicket();
        //    ticket.ReadJson(DataString.Ticket);
        //    resultTest = ticket.WriteJson();
        //    WeApiTicket apiTicket = new WeApiTicket();
        //    apiTicket.ReadJson(DataString.ApiTicket);
        //    resultTest = apiTicket.WriteJson();
        //    WeBatchAddCard batch = new WeBatchAddCard("po_2Djks4-yP5PGtgGY4GkbAIIt0", new CardExt(new DateTime(2015, 3, 1)) {  Code = "code", OpenId = "UserId", OuterId = 1, Balance = 1000});
        //    WeCardList cardList = new WeCardList(batch);
        //    resultTest = cardList.WriteJson();
        //    WeBatchAddCardResponse response = new WeBatchAddCardResponse();
        //    response.ReadJson(DataString.BatchAddCard);
        //    resultTest = response.WriteJson();
        //    WeCardConsume consume = new WeCardConsume("110213123123") {  CardId = "pFS7"};
        //    resultTest = consume.WriteJson();
        //    WeCardConsumeResponse re = new WeCardConsumeResponse();
        //    re.ReadJson(DataString.Consume);
        //    resultTest = re.WriteJson();
        //    WeChooseCard card = new WeChooseCard("wx0f283743a74d29e4", new DateTime(2015, 3, 23)) {  CardId = "wo shi cardId", CardType = CardType.GeneralCoupon};
        //    resultTest = card.WriteJson();
        //    WeChooseCardResponse chooseCard = new WeChooseCardResponse();
        //    chooseCard.ReadJson(DataString.ChooseCard);
        //    resultTest = chooseCard.WriteJson();

        //    WeCodeDecrypt decrypt = new WeCodeDecrypt("woshi decrypt code");
        //    resultTest = decrypt.WriteJson();
        //    WeCode code = new WeCode();
        //    code.ReadJson(DataString.Code);
        //    resultTest = code.WriteJson();
        //    WeCardId cardId = new WeCardId("p1falsdf");
        //    WeCode cod = new WeCode("12123123123");
        //    resultTest = cardId.WriteJson();
        //    resultTest = cod.WriteJson();
        //    WeCodeResponse res = new WeCodeResponse();
        //    res.ReadJson(DataString.CodeRes);
        //    resultTest = res.WriteJson();
        //    WeCardBatch cb = new WeCardBatch();
        //    cb.ReadJson(DataString.CardBatch);
        //    resultTest = cb.WriteJson();
        //    //WeCard card1 = new WeCard();
        //    //card1.ReadJson(DataString.Card);
        //    //resultTest = card1.WriteJson();
        //    WeCardModifyStock modify = new WeCardModifyStock("xxxx_card_id") { IncreaseStockValue = 123131, ReduceStockValue = 1231231};
        //    resultTest = modify.WriteJson();

        //    WeMembercardActivate activate = new WeMembercardActivate("123123123", "AA00012321") { InitBonus = 300, InitBalance = 20000, CardId = "xxxcardId", Balance = "xafd", Bonus = "xaxf"};
        //    resultTest = activate.WriteJson();
        //    WeMembercardUpdate update = new WeMembercardUpdate("12312313") {  AddBalance = -300, AddBonus = 3, CardId = "psfsf", RecordBalance = "fasdf", RecordBonus = "坏糖朵儿"};
        //    resultTest = update.WriteJson();
        //    WeMembercardUpdateResponse resp = new WeMembercardUpdateResponse();
        //    resp.ReadJson(DataString.CardUpdate);
        //    resultTest = resp.WriteJson();
        //    WeMovieTicketUpdate mt = new WeMovieTicketUpdate("277217129962", "4D", new DateTime(2015, 3, 14), 120, "5号厅", "5排14号", "5排15号", "5排16号");
        //    resultTest = mt.WriteJson();
        //    WeBoardingPassCheckin check = new WeBoardingPassCheckin("198374613512", "乘客信命", "头等创", "电子可票号") {  CardId = "pasofua", Seat = "座位号", IsCancel = false, QrcodeData = "二维码数据"};
        //    resultTest = check.WriteJson();
        //    WeLuckyMoneyUpdate lucky = new WeLuckyMoneyUpdate("123123123", 123123) { CardId = "xxx_card_id"};
        //    resultTest = lucky.WriteJson();
        //    WeMeetingTicketUpdate meeting = new WeMeetingTicketUpdate("97654892", new DateTime(2015, 4, 2), new DateTime(2015, 4, 5)) { CardId = "pXchd", Zone = "C区",Entrance = "东北门",SeatNumber = "2排15号"};
        //    resultTest = meeting.WriteJson();

        //    WeTestWhiteList lst = new WeTestWhiteList(ListType.Id, "afdvvf", "abcd");
        //    resultTest = lst.WriteJson();
        //} 

        //static void TestModuleRead()
        //{
        //    WeShelves request = new WeShelves();
        //    request.ReadJson(DataString.WeShelves);

        //    WeShelfInfo result = new WeShelfInfo();
        //    result.ReadJson(DataString.WeShelf);
        //    WeShelf sf = new WeShelf(new ShelfControlList(result.ShelfInfo), result.ShelfBanner,
        //        result.ShelfName, result.ShelfId);
        //    Console.WriteLine(result.WriteJson());
        //    Console.WriteLine(sf.WriteJson());

        //    var convertResult = from weshelf in request.Shelves
        //                        select new WeShelf(new ShelfControlList(weshelf.ShelfInfo),
        //                            weshelf.ShelfBanner, weshelf.ShelfName, weshelf.ShelfId);
        //    Test te = new Test(convertResult);
        //    Console.WriteLine(request.WriteJson());
        //    Console.WriteLine(te.WriteJson());
        //}

        //public class C
        //{
        //    internal C()
        //    {

        //    }
        //}

        //public class D
        //{
        //    public List<C> test { get; private set; }
        //}

        //public class Test
        //{
        //    Test()
        //    {
        //    }

        //    public Test(IEnumerable<WeShelf> lw)
        //    {
        //        wesflist = new List<WeShelf>();
        //        wesflist.AddRange(lw);
        //    }

        //    [ObjectElement(IsMultiple = true, Order = 10)]
        //    public List<WeShelf> wesflist { get; private set; }
        //}

        //static void TestModuleWrite()
        //{
        //    GroupInfo1 gi1 = new GroupInfo1(2, 50);
        //    ShelfControl1 m1 = new ShelfControl1(gi1);
        //    GroupInfo2 gi2 = new GroupInfo2(new WeShelfGroupId(49),
        //                                   new WeShelfGroupId(50),
        //                                   new WeShelfGroupId(51));
        //    ShelfControl2 m2 = new ShelfControl2(gi2);

        //    GroupInfo3 g3 = new GroupInfo3(52,
        //        "http://mmbiz.qpic.cn/mmbiz/4whpV1VZl29nqqObBwFwnIX3licVPnFV5Jm"
        //         + "64z4I0TTicv0TjN7Vl9bykUUibYKIOjicAwIt6Oy0Y6a1Rjp5Tos8tg/0");
        //    ShelfControl3 m3 = new ShelfControl3(g3);

        //    GroupInfo4 gi4 = new GroupInfo4(new GroupInfo3(49, "I an Img!"),
        //                                    g3,
        //                                    new GroupInfo3(50, "I am another Img!"));
        //    ShelfControl4 m4 = new ShelfControl4(gi4);
        //    List<GroupInfo3> lg = new List<GroupInfo3>() { g3 };
        //    ShelfControl5 m5 = new ShelfControl5(new GroupInfo5(lg, "I am the ImgBackGround"));
        //    ShelfControlList request = new ShelfControlList(m2, m1, m3, m4, m5);
        //    WeShelf ws = new WeShelf(request, "http://mmbiz.qpic.cn/mmbiz/4whpV1VZl2ibrWQn8zWFUh1YznsMV0XEiavFfLzDWYyvQOBBszXlMaiabGWzz5B2KhNn2IDemHa3iarmCyribYlZYyw/0", "测试货架");
        //    string json = ws.WriteJson();
        //    Console.WriteLine(json);
        //    Console.ReadKey();
        //}
            //static void TestGoods()
            //{
            //    DeliveryType dType = DeliveryType.TemplateId;
            //    Express exp1, exp2;
            //    exp1 = new Express(ExpressType.EMS, 16);
            //    exp2 = new Express(ExpressType.OrdinaryMail, 63);
            //    List<Express> exp = new List<Express>();
            //    exp.Add(exp1);
            //    exp.Add(exp2);
            //    DeliveryInfo di = new DeliveryInfo(dType, 7382618, exp1);

            //    List<string> categoryId = new List<string>();
            //    categoryId.Add("537074298");
            //    List<WeProductDetail> dt = new List<WeProductDetail>();
            //    dt.Add(WeProductDetail.CreateText("test first"));
            //    dt.Add(WeProductDetail.CreateImg("http://mmbiz.qpic.cn/mmbiz/4whpV1VZl2iccsvYbHvnphky"
            //        + "GtnvjD3ul1UcLcwxrFdwTKYhH9Q5YZoCfX4Ncx655ZK6ibnlibCCErbKQtReySaVA/0"));
            //    dt.Add(WeProductDetail.CreateText("test again"));
            //    ProductProperty pt = new ProductProperty();
            //    pt.Id = "12122212451";
            //    pt.Vid = "12512523355";
            //    SkuInfo si = new SkuInfo();
            //    si.Vid.Add("asdfljdfa");
            //    si.Id = "sadflasfdhalk";

            //    WeProductBase pB = new WeProductBase("5370742989", pt, "Hz", si, "mainImg", "img", WeProductDetail.CreateImg("test frist"));
            //    List<ProductProperty> lp = new List<ProductProperty>();

            //    List<SkuListElement> ls = new List<SkuListElement>();
            //    SkuListElement se = new SkuListElement();
            //    se.SkuId = "1075741873:1079742386";
            //    se.Price = 30;
            //    se.IconUrl = "http://mmbiz.qpic.cn/mmbiz/4whpV1VZl28bJj62XgfHPibY3ORKicN1oJ4CcoIr4BMbf"
            //        + "A8LqyyjzOZzqrOGz3f5KWq1QGP3fo6TOTSYD3TBQjuw/0";
            //    se.ProductCode = "testing";
            //    se.OriPrice = 9000000;
            //    se.Quantity = 800;
            //    ls.Add(se);

            //    Attrex ax = new Attrex();
            //    Location lt = new Location();
            //    lt.Country = "zhonguo";
            //    lt.Province = "zhejiang";
            //    lt.City = "hangzhou";
            //    lt.Address = "wensanRoad";
            //    ax.Location = lt;
            //    ax.IsPostFree = false;
            //    ax.IsHasReceipt = true;
            //    ax.IsUnderGuaranty = false;
            //    ax.IsSupportReplace = false;

            //    AddRequest request = new AddRequest(pB,di); 
            //    request.SkuLists = ls;
            //    request.Attrex = ax;

            //    ProductElement pe1 = new ProductElement("pDF3iY-CgqlAL3k8Ilz-6sj0UYpk", ModActionType.Add);
            //    ProductElement pe2 = new ProductElement("pDF3iY-CgqlAL3k8Ilz-6sj0UYpk", ModActionType.Remove);
            //    List<ProductElement> lpe = new List<ProductElement>();
            //    lpe.Add(pe1);
            //    lpe.Add(pe2);
            //    ReviseGoodRequest request = new ReviseGoodRequest(23, lp);
            //    ReviseRequest request = new ReviseRequest(pB, di, "pDF3iY6Kr_BV_CXaiYysoGqJhppQ");
            //            StatusGoodsRequest request = new StatusGoodsRequest(5);
            //    Console.WriteLine(exp1.WriteJson());

            //    Console.WriteLine("Response:");
            //    QueryResponse response = new QueryResponse();
            //    response.ReadJson(DataString.QueryResponse);
            //    StatusGoodsResponse response = new StatusGoodsResponse();
            //    response.ReadJson(DataString.StatusGoodResponse);
            //    SubGoodResponse response = new SubGoodResponse();
            //    response.ReadJson(DataString.SubGoodResponse);
            //     WePropertyList response = new WePropertyList();
            //    response.ReadJson(DataString.AllPropertyResponse);
            //    Console.WriteLine(response.WriteJson());



            //}

            //static void TestGroup()
            //{
            //    string[] ls = new string[] { "pDF3iY9cEWyMimNlKbik_NYJTzYU", "pDF3iY4kpZagQfwJ_LVQBaOC-LsM" };
            //    WeGroup gd = new WeGroup(ls);
            //    //AddGroupRequest request = new AddGroupRequest(gd);
            //    //RevisePropertyRequest request = new RevisePropertyRequest("特惠专场",28);
            //    List<WeGroupProduct> lp = new List<WeGroupProduct>();
            //    WeGroupProduct pe1 = new WeGroupProduct("pDF3iY-RewlAL3k8Ilz-6sjsepp9", ModActionType.Add);
            //    WeGroupProduct pe2 = new WeGroupProduct("pDF3iY-RewlAL3k8Ilz-6sjsepp9", ModActionType.Add);
            //    lp.Add(pe1);
            //    lp.Add(pe2);
            //     ReviseGoodRequest request = new ReviseGoodRequest(28,lp);
            //    AddGroupRequest request = new ProductGroup(gd);
            //     Console.WriteLine(request.WriteJson());
            //     Console.WriteLine("Reponse:");
            //    AllGroupResponse response = new AllGroupResponse();
            //    response.ReadJson(DataString.AllGroupResponse);
            //     IdToGroupResponse response = new IdToGroupResponse();
            //     response.ReadJson(DataString.IdToResponse);
            //    Console.WriteLine(response.WriteJson());
            //}

            //static void TestDelivery()
            //{
            //    NormalFeeMethod nfm = new NormalFeeMethod(2, 1, 3, 2);
            //    List<CustomFeeMethod> lcfm = new List<CustomFeeMethod>();
            //    CustomFeeMethod cfm = new CustomFeeMethod(1, 2, 3, 1, "浙江大", "杭州", "文三路");
            //    lcfm.Add(cfm);
            //    DeliveryFee dt = new DeliveryFee(ExpressType.EMS, nfm, cfm);
            //    List<DeliveryFee> topFees = new List<DeliveryFee>();
            //    topFees.Add(dt);
            //    WeDeliveryTemplate deliveryTemplate = new WeDeliveryTemplate("testexpress", AssumeType.Buyer, ValuationType.Quantity, dt);
            //    AddTemplateRequest request = new AddTemplateRequest(deliveryTemplate);
            //    ExpressTemplate request = new ExpressTemplate(deliveryTemplate);
            //    Console.WriteLine(request.WriteJson());
            //    Console.WriteLine("Reponse:");
            //    AddTemplateResponse response = new AddTemplateResponse();
            //    response.ReadJson(DataString.AddTemplateResponse);
            //    WeTemplateInfo response = new WeTemplateInfo();
            //    response.ReadJson(DataString.IdTemplateResponse);
            //    Console.WriteLine(response.WriteJson());
            //}
            //static void TestBill()
            //{
            //                IdToBIllRequset request = new IdToBIllRequset("7197417460812584720");
            //    StatusToBillRequest request = new StatusToBillRequest();
            //    DateTime beg = new DateTime(2012, 11, 13, 17, 13, 11);
            //    DateTime end = new DateTime(2013, 11, 23, 13, 11, 32);
            //    request.BeginTime = beg;
            //    request.EndTime = end;
            //    request.Status = StatusType.Delivery;
            //    WeBillDelivery request = new WeBillDelivery("7197417460812533543", true, false, "059Yunda", "1900659372473");
            //    Console.WriteLine(request.WriteJson());
            //    Console.WriteLine("Response:");

            //    WeBillList response = new WeBillList();
            //    response.ReadJson(DataString.StatusToBillResponse);
            //    Console.WriteLine(response.WriteJson());
            //}

            //static void TestToBill()
            //{
            //    DateTime dateTime = new DateTime(2014, 11, 12, 9, 2, 50);
            //    BillCheckRequest request = new BillCheckRequest(dateTime);
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine("output:{0}", pSign);
            //    //request.CreateSign();
            //    //Console.WriteLine("output:{0}",request.Sign);


            //    BillCheckResponse response = new BillCheckResponse();
            //    response.ReadXml(DataString.BillCheckResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xmlresponse = response.WriteXml();
            //    Console.WriteLine(xmlresponse);
            //}
            //static void TestCallToReport()
            //{
            //    ResultCode resultCode = ResultCode.Success;
            //    ResultCode returnCode = ResultCode.Success;
            //    CallToReportRequest request = new CallToReportRequest("https://api.mch.weixin.qq.com/pay/unifiedorder", 300, returnCode, resultCode);
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine("output:{0}", pSign);

            //    CallToReportResponse response = new CallToReportResponse();
            //    response.ReadXml(DataString.CallToReportResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}

            //static void TestClose()
            //{
            //    CloseRequest request = new CloseRequest();
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine("output:{0}", pSign);

            //    CloseResponse response = new CloseResponse();
            //    response.ReadXml(DataString.CloseResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}

            //static void TestConversion()
            //{
            //    ConversionRequest request = new ConversionRequest("http://sdfwesfnmernsdfkhke/sdjfk");
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine(pSign);

            //    ConversionResponse response = new ConversionResponse();
            //    response.ReadXml(DataString.ConversionResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}

            //static void TestJSApi()
            //{
            //    JSApiRequest request = new JSApiRequest("xiaoxiong", "1521210200210", "MD5", "ScriptWrite");
            //    Console.WriteLine(request.ToXml());
            //}

            //static void TestMicroPay()
            //{
            //    MicroPayRequest request = new MicroPayRequest("flower", 1250, "2542561");
            //    request.CreateSign();
            //    Console.WriteLine(request.ToXml());

            //    MicroPayResponse respose = new MicroPayResponse();
            //    respose.ReadXml(DataString.MicroPayResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    Console.WriteLine(respose.WriteXml());
            //}
            //static void TestNative()
            //{
            //    NativeRequest1 request1 = new NativeRequest1("125125122233669596");
            //    Console.WriteLine(request1.ToXml());

            //    NativeRequest2 request2 = new NativeRequest2("xiaomibao", true, "125125122233669596");
            //    Console.WriteLine(request2.ToXml());

            //    NativeResponse response = new NativeResponse();
            //    response.ReadXml(DataString.NativeResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}

            //static void TestNotice()
            //{
            //    ResultCode resultCode = ResultCode.Fail;
            //    NoticeBack back = new NoticeBack(resultCode, "AllisOk");
            //    Console.WriteLine(back.ToXml());

            //    NoticeResponse response = new NoticeResponse();
            //    response.ReadXml(DataString.NoticeResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}

            //static void TestOrderQuery()
            //{
            //    OrderQueryRequest request = new OrderQueryRequest();
            //    Console.WriteLine(request.ToXml());

            //    OrderQueryResponse response = new OrderQueryResponse();
            //    response.ReadXml(DataString.OrderQueryResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    Console.WriteLine(response.WriteXml());
            //}
            //static void TestPayment()
            //{
            //    TradeType tradeType = TradeType.Native;
            //    PaymentRequest request = new PaymentRequest("shangpu", 1250, "http://wwww.shkxh.cont", tradeType);
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine("output:{0}", pSign);
            //    Console.WriteLine("Ip:{0}", request.SpbillCreateIp);

            //    PaymentResponse response = new PaymentResponse();
            //    response.ReadXml(DataString.PaymentResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}

            //static void TestRefundApplication()
            //{
            //    RefundApplicationRequest request = new RefundApplicationRequest("111111", 1230, 1000, "jchsandsalj");
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine("output:{0}", pSign);

            //    RefundApplicationResponse response = new RefundApplicationResponse();
            //    response.ReadXml(DataString.RefundApplicationResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}

            //static void TestRefundInquiry()
            //{
            //    RefundInquiryRequest request = new RefundInquiryRequest("tianmmao", "11111");
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine("output:{0}", pSign);

            //    RefundInquiryResponse response = new RefundInquiryResponse();
            //    response.ReadXml(DataString.RefundInquiryResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //    SWeUtil.Traversal(response);
            //}

            //static void TestReverse()
            //{
            //    ReverseRequest request = new ReverseRequest();
            //    Console.WriteLine(request.ToXml());

            //    ReverseResponse response = new ReverseResponse();
            //    response.ReadXml(DataString.ReverseResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    Console.WriteLine(response.WriteXml());
            //}

            //static void TestSeach()
            //{
            //    SeachRequest request = new SeachRequest();
            //    Console.WriteLine(request.ToXml());
            //    string pSign = request.WriteQueryString(QueryStringOutput.WeixinOutput);
            //    Console.WriteLine("output:{0}", pSign);

            //    SeachResponse response = new SeachResponse();
            //    response.ReadXml(DataString.SeachResponse, ReadSettings.Default, WePayConst.QNAME_XML);
            //    string xml = response.WriteXml();
            //    Console.WriteLine(xml);
            //}
        }
    }
