using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using System.IO;

namespace TestData
{
    [Source(Author = "zll", CreateDate = "2015/2/11 16:09:01",
        Description = "数据源")]
    public class ImportExcelSourceSource : ISource, ISupportMetaData
    {
        public ImportExcelSourceSource()
        {
        }

        public Tk5ListMetaData fMetaData;

        public bool CanUseMetaData(IPageStyle style)
        {
            return true;
        }

        public void SetMetaData(IPageStyle style, IMetaData metaData)
        {
            fMetaData = metaData as Tk5ListMetaData;
        }

        public OutputData DoAction(IInputData input)
        {
            NPOIRead.CreateExcelTemplate(fMetaData);

            string strName = @"D:\ImportTest.xls";
            ResultHolder rh = new ResultHolder();
            DataSet dSet = null;
            try
            {
                dSet = NPOIRead.ExcelImport(strName, fMetaData, rh);
            }
            catch
            { 
            }

            return OutputData.Create(dSet);

        }
    }
}
