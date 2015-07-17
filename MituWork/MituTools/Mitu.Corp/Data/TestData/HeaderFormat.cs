﻿using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace TestData
{
    internal class HeaderFormat : ExcelContentFormat
    {
        [SimpleAttribute(DefaultValue = Alignment.Center, LocalName = "Align")]
        public Alignment InternalAlign
        {
            get
            {
                return Align;
            }
            set
            {
                Align = value;
            }
        }

        [SimpleAttribute(DefaultValue = true, LocalName = "FontBold")]
        public bool InternalFontBold
        {
            get
            {
                return FontBold;
            }
            set
            {
                FontBold = value;
            }
        }
    }
}
