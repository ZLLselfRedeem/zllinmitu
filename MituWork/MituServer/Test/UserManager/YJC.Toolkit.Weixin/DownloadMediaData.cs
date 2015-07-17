namespace YJC.Toolkit.Weixin
{
    public sealed class DownloadMediaData
    {
        internal DownloadMediaData(WeixinResult errorInfo)
        {
            IsError = true;
            ErrorInfo = errorInfo;
        }

        internal DownloadMediaData(byte[] fileData)
        {
            IsError = false;
            FileData = fileData;
        }

        public bool IsError { get; private set; }

        public WeixinResult ErrorInfo { get; private set; }

        public byte[] FileData { get; private set; }
    }
}
