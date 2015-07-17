﻿using YJC.Toolkit.Sys;

namespace TestData
{
    [PageMakerConfig(NamespaceType = NamespaceType.Toolkit, Author = "YJC",
        CreateDate = "2015-01-23", Description = "PageMaker")]
    internal class ExportExcelPageMakerConfig : IConfigCreator<IPageMaker>, IReadObjectCallBack
    {
        public IPageMaker CreateObject(params object[] args)
        {
            return new ExportExcelPageMaker(this);
        }

        [SimpleAttribute(DefaultValue = true)]
        public bool UserBorder { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, ObjectType = typeof(HeaderFormat))]
        public ExcelContentFormat Header { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, ObjectType = typeof(ContentFormat))]
        public ExcelContentFormat Content { get; private set; }

        public void OnReadObject()
        {
            if (Header == null)
                Header = ExcelContentFormat.DefaultHead;
            if (Content == null)
                Content = ExcelContentFormat.DefaultContent;
        }
    }
}
