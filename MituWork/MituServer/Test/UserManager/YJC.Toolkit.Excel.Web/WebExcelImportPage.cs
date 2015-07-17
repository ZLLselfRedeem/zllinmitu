using System;
using YJC.Toolkit.Data;
using YJC.Toolkit.Excel;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Web.Page;

namespace YJC.Toolkit.Web
{
    internal class WebExcelImportPage : WebBaseContentPage
    {
        public WebExcelImportPage()
        {
            Style = (PageStyleClass)PageStyle.List;
        }

        protected override IPageMaker PageMaker
        {
            get
            {
                //return new ExcelImportPageMaker();
                return XmlPageMaker.DEFAULT;
            }
        }

        protected override IPostObjectCreator PostObjectCreator
        {
            get
            {
                return JsonPostDataSetObjectCreator.Creator;
            }
        }

        public override ISource Source
        {
            get
            {
                //return new EmptySource(true);
                return new ImportDataSource();
            }
        }
    }
}
