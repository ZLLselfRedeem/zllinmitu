using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin
{
    public class QRScene
    {
        internal QRScene()
        {
        }

        public QRScene(int sceneId)
        {
            SceneId = sceneId;
        }

        [SimpleElement(LocalName = "scene_id")]
        public int SceneId { get; private set; }
    }
}
