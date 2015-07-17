using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Excel
{
    public sealed class ImportResultData : IDisposable
    {

        public ImportResultData(DataSet import, DataSet error, IEnumerable<ImportWarningItem> items)
        {
            TkDebug.AssertArgumentNull(import, "import", null);

            Key = Guid.NewGuid().ToString();
            ImportDataSet = import;
            ImportErrorDataSet = error;
            ErrorItems = items;
        }

        #region IDisposable 成员

        public void Dispose()
        {
            ImportDataSet.DisposeObject();
            ImportErrorDataSet.DisposeObject();
        }

        #endregion

        public string Key { get; private set; }

        public DataSet ImportDataSet { get; private set; }

        public DataSet ImportErrorDataSet { get; private set; }

        public IEnumerable<ImportWarningItem> ErrorItems { get; private set; }
    }
}
