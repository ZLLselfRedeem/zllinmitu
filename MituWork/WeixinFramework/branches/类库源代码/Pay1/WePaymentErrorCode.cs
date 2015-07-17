using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Pay
{
    enum WePaymentErrorCode
    {
        [EnumFieldValue("APPID_MCHID_NOT_MATCH")]
        AppidMchidNotMatch,
        [EnumFieldValue("APPID_NOT_EXIST")]
        AppidNotExist,
        [EnumFieldValue("BANKERROR")]
        BankError,
        [EnumFieldValue("INVALID_TRANSACTIONID")]
        InvalidTransactionId,
        [EnumFieldValue("MCHID_NOT_EXIST")]
        MchidNotExist,
        [EnumFieldValue("LACK_PARAMS")]
        LackParams,
        [EnumFieldValue("NOAUTH")]
        NoAuth,
        [EnumFieldValue("NOTENOUGH")]
        NotEnough,
        [EnumFieldValue("NOT_UTF8")]
        NotUtf8,
        [EnumFieldValue("NOTSUPORTCARD")]
        NotSuportCard,
        [EnumFieldValue("ORDERCLOSED")]
        OrderClosed,
        [EnumFieldValue("ORDERNOTEXIST")]
        OrderNotExist,
        [EnumFieldValue("ORDERPAID")]
        OrderPaid,
        [EnumFieldValue("OUT_TRADE_NO_USED")]
        OutTradeNoUsed,
        [EnumFieldValue("PARAM_ERROR")]
        ParamError,
        [EnumFieldValue("POST_DATA_EMPTY")]
        PostDataEmpty,
        [EnumFieldValue("REFUND_FEE_INVALID")]
        RefundFeeInvalid,
        [EnumFieldValue("REQUIRE_POST_METHOD")]
        RequirePostMethod,
        [EnumFieldValue("SIGNERROR")]
        SignError,
        [EnumFieldValue("SYSTEMERROR")]
        SystemError,
        [EnumFieldValue("URLFORMATERROR")]
        UrlFormatError,
        [EnumFieldValue("XML_FORMAT_ERROR")]
        XmlFormatError


    }
}
