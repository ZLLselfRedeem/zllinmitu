using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Excel;

namespace YJC.Toolkit.Web
{
    public class ExportExcelHeaderPageMaker : BaseExportExcelPageMaker
    {
        public ExportExcelHeaderPageMaker()
        {
            UserBorder = false;
        }

        public ExportExcelHeaderPageMaker(ExcelContentFormat header, ExcelContentFormat content)
            : base(header, content)
        {
            UserBorder = false;
        }

        protected sealed override byte[] CreateExcelData(ExcelExporter exporter, OutputData outputData)
        {
            byte[] data = exporter.CreateExcelTemplate();
            return data;
        }
    }
}
