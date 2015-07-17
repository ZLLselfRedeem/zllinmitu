using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Sys;
using YJC.Toolkit.MetaData;

namespace YJC.Toolkit.Web
{
    internal class ExcelImportPageMaker : CompositePageMaker
    {
        public ExcelImportPageMaker()
        {
            string defaultFileName = FileUtil.GetRealFileName(@"Razor\Excel\Import.cshtml", 
                FilePathPosition.Xml);
            string postFileName = FileUtil.GetRealFileName(@"Razor\Excel\PostExcel.cshtml",
                FilePathPosition.Xml);
            Add((source, input, output) => Condition(input, "Template"), new ExportExcelHeaderPageMaker());
            Add((source, input, output) => Condition(input, "ErrorExcel"), new ExcelErrorDataPageMaker());
            Add((source, input, output) => Condition(input, "Import"), 
                new PostPageMaker(ContentDataType.Json, PageStyle.Custom, new CustomUrlConfig(false, false, "CloseDialog")));
            Add((source, input, output) => input.IsPost, new FreeRazorPageMaker(postFileName));
            Add((source, input, output) => !input.IsPost, new FreeRazorPageMaker(defaultFileName));
        }

        private static bool Condition(IInputData input, string type)
        {
            return !input.IsPost && input.Style.Operation == type;
        }
    }
}
