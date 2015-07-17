using System.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Web;

namespace TestData
{
    public class ExportExcelPageMaker : IPageMaker, ISupportMetaData
    {
        public ExportExcelPageMaker(ExcelContentFormat header, ExcelContentFormat content)
        {
            TkDebug.AssertArgumentNull(header, "header", null);
            TkDebug.AssertArgumentNull(content, "content", null);

            Header = header;
            Content = content;
        }

        public Tk5ListMetaData fMetaData;

        internal ExportExcelPageMaker(ExportExcelPageMakerConfig exportExcelPageMakerConfig)
        {
            UserBorder = exportExcelPageMakerConfig.UserBorder;
            Header = exportExcelPageMakerConfig.Header;
            Content = exportExcelPageMakerConfig.Content;
        }

        public IContent WritePage(ISource source, IPageData pageData, OutputData outputData)
        {
            //DataSet ds = outputData.Data as DataSet;
            //TkDebug.AssertArgumentNull(ds, "ds", null);
            //DataTable table = ds.Tables[fMetaData.Table.TableName];

            byte[] midArray = NPOIWrite.ExportExcel(outputData, this);
            string fileName = fMetaData.Table.TableDesc + ".xls";
            FileContent file = new FileContent(NetUtil.GetContentType(fileName), fileName, midArray);
            return new WebFileContent(file);
        }

        public bool CanUseMetaData(IPageStyle style)
        {
            return style.Style == PageStyle.List;
        }

        public void SetMetaData(IPageStyle style, IMetaData metaData)
        {
            fMetaData = metaData as Tk5ListMetaData;
        }

        public bool UserBorder { get; set; }

        [ObjectElement(NamespaceType.Toolkit, ObjectType = typeof(HeaderFormat))]
        public ExcelContentFormat Header { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, ObjectType = typeof(ContentFormat))]
        public ExcelContentFormat Content { get; private set; }
    }
}
