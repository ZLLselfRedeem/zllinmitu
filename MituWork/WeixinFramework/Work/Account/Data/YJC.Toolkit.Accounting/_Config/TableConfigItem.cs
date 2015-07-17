using System;
using System.Collections.Generic;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    internal class TableConfigItem
    {

        [SimpleAttribute]
        internal string IdName { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        internal MultiLanguageText TableDesc { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "Field")]
        internal RegNameList<FieldConfigItem> FieldList { get; private set; }
    }
}