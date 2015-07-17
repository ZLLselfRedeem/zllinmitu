using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;

namespace YJC.Toolkit.Excel
{
    [Resolver(Author = "YJC", CreateDate = "2015-06-25",
        Description = "Excell导入对象")]
    internal class ImportResolver : Tk5TableResolver
    {
        public const string DATAXML = "UserManager/Part.xml";

        public ImportResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
        }
    }
}
