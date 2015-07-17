namespace YJC.Toolkit.Weixin
{
    internal interface IRetriever
    {
        WeixinResult RetrieveData();

        WeixinResult ReadData(string json);
    }
}
