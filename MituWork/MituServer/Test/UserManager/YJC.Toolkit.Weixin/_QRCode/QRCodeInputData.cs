using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public sealed class QRCodeInputData
    {
        public const int MAX_EXPIRE_SECONDS = 1800;

        public QRCodeInputData(int sceneId, int expireSeconds)
        {
            ActionName = QRAction.Scene;
            Scene = new QRScene(sceneId);
            ExpireSeconds = expireSeconds;
        }

        public QRCodeInputData(int sceneId)
        {
            ActionName = QRAction.LimitScene;
            Scene = new QRScene(sceneId);
        }

        [SimpleElement(LocalName = "expire_seconds", Order = 10)]
        public int? ExpireSeconds { get; private set; }

        [SimpleElement(LocalName = "action_name", Order = 20)]
        [TkTypeConverter(typeof(EnumFieldValueTypeConverter), UseObjectType = true)]
        public QRAction ActionName { get; private set; }

        [TagElement(LocalName = "action_info", Order = 30)]
        [ObjectElement(LocalName = "scene", UseConstructor = true)]
        public QRScene Scene { get; private set; }

        public QRCodeResult CreateTick()
        {
            QRCodeResult result = new QRCodeResult();
            string url = WeUtil.GetUrl(WeConst.QR_CREATE_URL);
            result = WeUtil.PostToUri(url, this.WriteJson(WeConst.WRITE_SETTINGS), result);
            return result;
        }
    }
}
