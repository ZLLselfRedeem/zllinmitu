using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace MyTypeViewer
{
    public class ExcelContentFormat
    {
        internal static ExcelContentFormat DefaultHead = new ExcelContentFormat { Align = Alignment.Center, FontBold = true };
        internal static ExcelContentFormat DefaultContent = new ExcelContentFormat { Align = Alignment.Right, FontBold = false };

        [SimpleAttribute(DefaultValue = "宋体")]
        public string FontName { get; protected set; }

        [SimpleAttribute(DefaultValue = 10)]
        public short FontSize { get; protected set; }

        public bool FontBold { get; protected set; }

        public Alignment Align { get; protected set; }
    }
}
