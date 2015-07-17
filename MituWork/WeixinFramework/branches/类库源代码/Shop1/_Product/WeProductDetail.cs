using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    public class WeProductDetail
    {
        [SimpleElement(Order = 10, NamingRule = NamingRule.Camel)]
        public string Text { get; private set; }

        [SimpleElement(Order = 20, NamingRule = NamingRule.Camel)]
        public string Img { get; private set; }

        public static WeProductDetail CreateText(string text)
        {
            TkDebug.AssertArgumentNullOrEmpty(text, "text", null);
            return new WeProductDetail { Text = text };
        }

        public static WeProductDetail CreateImg(string img)
        {
            TkDebug.AssertArgumentNullOrEmpty(img, "img", null);
            return new WeProductDetail { Img = img };
        }

        public override string ToString()
        {
            if (Text != null)
                return string.Format(ObjectUtil.SysCulture, "Text:{0}", Text);
            else
                return string.Format(ObjectUtil.SysCulture, "Img:{0}", Img);
        }
    }
}
