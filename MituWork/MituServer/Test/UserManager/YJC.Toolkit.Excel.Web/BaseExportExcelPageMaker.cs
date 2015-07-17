using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Excel;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Web
{
    public abstract class BaseExportExcelPageMaker : IPageMaker, ISupportMetaData
    {
        private Tk5ListMetaData fMetaData;

        protected BaseExportExcelPageMaker()
            : this(ExcelContentFormat.DefaultHeader, ExcelContentFormat.DefaultContent)
        {
        }

        protected BaseExportExcelPageMaker(ExcelContentFormat header, ExcelContentFormat content)
        {
            TkDebug.AssertArgumentNull(header, "header", null);
            TkDebug.AssertArgumentNull(content, "content", null);

            UserBorder = true;
            Header = header;
            Content = content;
        }      

        #region ISupportMetaData 成员

        public bool CanUseMetaData(IPageStyle style)
        {
            return style.Style == PageStyle.List;
        }

        public void SetMetaData(IPageStyle style, IMetaData metaData)
        {
            fMetaData = metaData as Tk5ListMetaData;
        }

        #endregion

        #region IPageMaker 成员

        public IContent WritePage(ISource source, IPageData pageData, OutputData outputData)
        {
            TkDebug.AssertNotNull(fMetaData, "PageMaker缺少MetaData", this);

            ExcelExporter exporter = new ExcelExporter(UserBorder, Header, Content, fMetaData);
            byte[] data = null;

            data = CreateExcelData(exporter, outputData);
            if (data == null)
                data = new byte[0];
            string fileName = fMetaData.Title + ".xls";
            FileContent file = new FileContent(NetUtil.GetContentType(fileName), fileName, data);
            return new WebFileContent(file);
        }

        #endregion

        public Tk5ListMetaData MetaData
        {
            get
            {
                return fMetaData;
            }
        }

        public bool UserBorder { get; set; }

        public ExcelContentFormat Header { get; protected set; }

        public ExcelContentFormat Content { get; protected set; }

        protected abstract byte[] CreateExcelData(ExcelExporter exporter, OutputData outputData);
    }
}
