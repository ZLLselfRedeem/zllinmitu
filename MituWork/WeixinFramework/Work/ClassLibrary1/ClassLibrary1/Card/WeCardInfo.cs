using System;
using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Card
{
    public class WeCardInfo
    {
        internal WeCardInfo()
        {
        }

        public WeCardInfo(CardType cardType, object cardInfo)
        {
            CardType = cardType;
            TkDebug.AssertArgumentNull(cardInfo, "cardInfo", null);

            switch (cardType)
            {
                case CardType.GeneralCoupon:
                    GeneralCoupon = cardInfo as WeGeneralCoupon;
                    break;
                case CardType.GroupOn:
                    Groupon = cardInfo as WeGroupon;
                    break;
                case CardType.Discount:
                    Discount = cardInfo as WeDiscountCard;
                    break;
                case CardType.Gift:
                    Gift = cardInfo as WeGift;
                    break;
                case CardType.Cash:
                    Cash = cardInfo as WeCash;
                    break;
                case CardType.MemberCard:
                    MemberCard = cardInfo as WeMemberCard;
                    break;
                case CardType.ScenicTicket:
                    ScenicTicket = cardInfo as WeScenicTicket;
                    break;
                case CardType.MovieTicket:
                    MovieTicket = cardInfo as WeMovieTicket;
                    break;
                case CardType.BoardingPass:
                    BoardingPass = cardInfo as WeBoardingPass;
                    break;
                case CardType.LuckyMoney:
                    LuckyMoney = cardInfo as WeLuckyMoney;
                    break;
                case CardType.MeeringTicket:
                    MeetingTicket = cardInfo as WeMeetingTicket;
                    break;
                default:
                    break;
            }
        }

        [SimpleElement(Order = 30, NamingRule = NamingRule.UnderLineLower)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public CardType CardType { get; private set; }

        [ObjectElement(Order = 40, NamingRule = NamingRule.UnderLineLower, UseConstructor = true)]
        public WeGeneralCoupon GeneralCoupon { get; private set; }

        [ObjectElement(Order = 50, NamingRule = NamingRule.Lower)]
        public WeGroupon Groupon { get; private set; }

        [ObjectElement(Order = 60, NamingRule = NamingRule.Lower)]
        public WeGift Gift { get; private set; }

        [ObjectElement(Order = 70, NamingRule = NamingRule.Lower)]
        public WeCash Cash { get; private set; }

        [ObjectElement(Order = 80, NamingRule = NamingRule.Lower)]
        public WeDiscountCard Discount { get; private set; }

        [ObjectElement(Order = 90, NamingRule = NamingRule.UnderLineLower)]
        public WeMemberCard MemberCard { get; private set; }

        [ObjectElement(Order = 100, NamingRule = NamingRule.UnderLineLower)]
        public WeScenicTicket ScenicTicket { get; private set; }

        [ObjectElement(Order = 110, NamingRule = NamingRule.UnderLineLower)]
        public WeMovieTicket MovieTicket { get; private set; }

        [ObjectElement(Order = 120, NamingRule = NamingRule.UnderLineLower)]
        public WeBoardingPass BoardingPass { get; private set; }

        [ObjectElement(Order = 130, NamingRule = NamingRule.UnderLineLower)]
        public WeLuckyMoney LuckyMoney { get; private set; }

        [ObjectElement(Order = 140, NamingRule = NamingRule.UnderLineLower)]
        public WeMeetingTicket MeetingTicket { get; private set; }

        /// <summary>
        /// 上传图片文件大小限制1MB，支持JPG格式
        /// </summary>
        /// <param name="fileName">文件名+扩展名</param>
        /// <param name="fileData">上传文件内容的二进制流</param>
        /// <returns></returns>
        public static string LogoUpload(string fileName, byte[] fileData)
        {
            TkDebug.AssertArgumentNullOrEmpty(fileName, "fileName", null);
            TkDebug.AssertArgumentNull(fileData, "fileData", null);

            string url = WeUtil.GetUrl(WeCardConst.UPLOAD_IMG);
            var result = NetUtil.ReadObjectFromResponse(NetUtil.FormUploadFile(new Uri(url), "buffer", fileName, fileData), null, new WeLogoUrl());
            return result.Url;
        }

        public static List<WeCardColor> ColorsGet()
        {
            string url = WeUtil.GetUrl(WeCardConst.GET_COLORS);
            var result = WeUtil.GetFromUri(url, new WeColors());
            return result.Colors;
        }

        public string CardCreate()
        {
            string url = WeUtil.GetUrl(WeCardConst.CARD_CREATE);
            WeCard request = new WeCard(this);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeCardId());
            return result.CardId;
        }

        public string QrcodeCreate(string actionName, string cardId, string code, string openid, int? expireSeconds, bool isUnique, int? balance, int outerId)
        {
            TkDebug.AssertArgumentNullOrEmpty(actionName, "actionName", null);
            TkDebug.AssertArgumentNull(cardId, "cardId", null);

            WeQrcodeInfo info = new WeQrcodeInfo(cardId)
            {
                Code = code,
                OpenId = openid,
                ExpireSeconds = expireSeconds,
                IsUniqueCode = isUnique,
                Balance = balance,
                OuterId = outerId
            };

            string url = WeUtil.GetUrl(WeCardConst.QRCODE_CREATE);
            WeQrcodeCreate request = new WeQrcodeCreate(actionName, info);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeQrcodeTicket());
            return result.Ticket;
        }

        public static string ApiTicketGet(CardType type)
        {
            string url = string.Format(ObjectUtil.SysCulture, WeCardConst.GET_TICKET,
                AccessToken.CurrentToken, type);
            var result = WeUtil.GetFromUri(url, new WeApiTicket());
            return result.Ticket;
        }

        public static WeCodeConsumeResponse CodeConsume(string code, string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);

            string url = WeUtil.GetUrl(WeCardConst.CODE_CONSUME);
            WeCodeConsume request = new WeCodeConsume(code) { CardId = cardId };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeCodeConsumeResponse());
            return result;
        }

        public string CodeDecrypt(string encryptCode)
        {
            TkDebug.AssertArgumentNullOrEmpty(encryptCode, "encryptCode", null);

            string url = WeUtil.GetUrl(WeCardConst.CODE_DECRYPT);
            WeCodeDecrypt request = new WeCodeDecrypt(encryptCode);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeCode());
            return result.Code;
        }

        public static WeixinResult CardDelete(string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(cardId, "cardId", null);

            string url = WeUtil.GetUrl(WeCardConst.CARD_DELETE);
            WeCardId request = new WeCardId(cardId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeCodeResponse CodeQuery(string code, string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);

            string url = WeUtil.GetUrl(WeCardConst.CODE_GET);
            WeCodeConsume request = new WeCodeConsume(code) { CardId = cardId };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeCodeResponse());
            return result;
        }

        public static List<string> CardBatchGet(int offset, int count)
        {
            string url = WeUtil.GetUrl(WeCardConst.CARD_BATCH_GET);
            WeCardBatchGet request = new WeCardBatchGet(offset, count);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeCardBatch());
            return result.CardIdList;
        }

        public static WeCardInfo CardQuery(string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(cardId, "cardId", null);

            string url = WeUtil.GetUrl(WeCardConst.GET_CARD);
            WeCardId request = new WeCardId(cardId);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeCard());
            return result.Card;
        }

        //
        // 微信允许自定义code的商户对已下发的code进行更改
        //
        public static WeixinResult CodeUpdate(string code, string cardId, string newCode)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);
            TkDebug.AssertArgumentNullOrEmpty(cardId, "cardId", null);
            TkDebug.AssertArgumentNullOrEmpty(newCode, "newCode", null);

            string url = WeUtil.GetUrl(WeCardConst.CODE_UPDATE);
            WeCodeUpdate request = new WeCodeUpdate(code, cardId, newCode);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult CodeUnavailable(string code, string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);

            string url = WeUtil.GetUrl(WeCardConst.CODE_UNAVAILABLE);
            WeCodeUnavailable request = new WeCodeUnavailable(code) { CardId = cardId };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public WeixinResult CardUpdate(string cardId, object cardInfo)
        {
            TkDebug.AssertArgumentNullOrEmpty(cardId, "cardId", null);
            TkDebug.AssertArgumentNull(cardInfo, "cardInfo", null);

            string url = WeUtil.GetUrl(WeCardConst.CARD_UPDATE);
            WeCardUpdate request = new WeCardUpdate(cardId, cardInfo);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult ModifyStock(string cardId, int increase, int reduce)
        {
            TkDebug.AssertArgumentNullOrEmpty(cardId, "cardId", null);

            string url = WeUtil.GetUrl(WeCardConst.MODIFY_STOCK);
            WeCardModifyStock request = new WeCardModifyStock(cardId)
            {
                IncreaseStockValue = increase,
                ReduceStockValue = reduce
            };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult MemberCardActivate(int initBonus, int initBalance, string bonusUrl,
            string balanceUrl, string number, string code, string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(number, "number", null);
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);

            string url = WeUtil.GetUrl(WeCardConst.MEMBERCARD_ACTIVATE);
            WeMembercardActivate request = new WeMembercardActivate(code, number)
            {
                InitBonus = initBonus,
                InitBalance = initBalance,
                Bonus = bonusUrl,
                Balance = balanceUrl,
                CardId = cardId
            };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeMembercardUpdateResponse MemberCardUpdate(string code, int addBonus,
            string recordBonus, int addBalance, string recordBalance, string cardId)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);

            string url = WeUtil.GetUrl(WeCardConst.MEMBERCARD_UPDATE);
            WeMembercardUpdate request = new WeMembercardUpdate(code)
            {
                AddBonus = addBonus,
                RecordBonus = recordBonus,
                AddBalance = addBalance,
                RecordBalance = recordBalance,
                CardId = cardId
            };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeMembercardUpdateResponse());
            return result;
        }

        public static WeixinResult MovieTicketUpdate(string code, string cardId, string ticketClass,
            DateTime showTime, int duration, string screeningRoom, string seatNumber)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);
            TkDebug.AssertArgumentNullOrEmpty(ticketClass, "ticketClass", null);
            TkDebug.AssertArgumentNullOrEmpty(screeningRoom, "screeningRoom", null);
            TkDebug.AssertArgumentNullOrEmpty(seatNumber, "seatNumber", null);

            string url = WeUtil.GetUrl(WeCardConst.MOVIE_TICKET_UPDATE);
            WeMovieTicketUpdate request = new WeMovieTicketUpdate(code, ticketClass, showTime,
                duration, screeningRoom, seatNumber)
            {
                CardId = cardId
            };

            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult BoardingPassChechin(string code, string cardId, string passageName,
            string classType, string seat, string etktBnr, string qrcodeData, bool isCancel)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);
            TkDebug.AssertArgumentNullOrEmpty(passageName, "passageName", null);
            TkDebug.AssertArgumentNullOrEmpty(classType, "classType", null);
            TkDebug.AssertArgumentNullOrEmpty(etktBnr, "etktBnr", null);

            string url = WeUtil.GetUrl(WeCardConst.BOARDING_PASS_CHECHIN);
            WeBoardingPassCheckin request = new WeBoardingPassCheckin(code, passageName, classType, etktBnr)
            {
                CardId = cardId,
                Seat = seat,
                QrcodeData = qrcodeData,
                IsCancel = isCancel
            };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult LuckyMoneyUpdate(string code, string cardId, int balance)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);

            string url = WeUtil.GetUrl(WeCardConst.LUCKY_MONEY_UPDATE);
            WeLuckyMoneyUpdate request = new WeLuckyMoneyUpdate(code, balance) { CardId = cardId };
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult MeetingTicketUpdate(string code, string cardId, string zone,
            string entrance, string seatNumber, DateTime beg, DateTime end)
        {
            TkDebug.AssertArgumentNullOrEmpty(code, "code", null);

            string url = WeUtil.GetUrl(WeCardConst.MEETING_TICKET_UPDATE);
            WeMeetingTicketUpdate request = new WeMeetingTicketUpdate(code, beg, end)
            {
                CardId = cardId,
                Zone = zone,
                Entrance = entrance,
                SeatNumber = seatNumber
            };

            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }

        public static WeixinResult TestListSet(string[] idList, string[] nameList)
        {
            TkDebug.AssertArgumentNull(idList, "idList", null);
            TkDebug.AssertArgumentNull(nameList, "nameList", null);

            string url = WeUtil.GetUrl(WeCardConst.TEST_WHITE_LIST);
            WeTestWhiteList request = new WeTestWhiteList(idList, nameList);
            var result = WeUtil.PostToUri(url, request.WriteJson(), new WeixinResult());
            return result;
        }
    }
}
