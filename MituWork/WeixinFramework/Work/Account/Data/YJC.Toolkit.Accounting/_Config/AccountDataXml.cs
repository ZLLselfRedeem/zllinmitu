using System;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using System.IO;

namespace YJC.Toolkit.Accounting
{
    internal class AccountDataXml : ToolkitConfig, ITableSchemeEx, ITableScheme
    {
        [ObjectElement(NamespaceType.Toolkit)]
        internal TableConfigItem Table { get; private set; }

        #region ITableSchemeEx 成员

        public string TableName
        {
            get
            {
                return "ReportData";
            }
        }

        public string TableDesc
        {
            get
            {
                return MultiLanguageText.ToString(Table.TableDesc);
            }
        }

        public IEnumerable<IFieldInfoEx> Fields
        {
            get
            {
                return Table.FieldList;
            }
        }

        #endregion

        #region IFieldInfoIndexer 成员

        public IFieldInfo this[string nickName]
        {
            get
            {
                TkDebug.AssertArgumentNullOrEmpty(nickName, "nickName", this);

                return Table.FieldList[nickName];
            }
        }

        #endregion

        #region ITableScheme 成员


        IEnumerable<IFieldInfo> ITableScheme.Fields
        {
            get
            {
                return Fields;
            }
        }

        #endregion

        public static AccountDataXml Load(string dataXml)
        {
            string path = Path.Combine(BaseAppSetting.Current.XmlPath, "Data", dataXml);
            AccountDataXml result = new AccountDataXml();
            result.ReadXmlFromFile(path);

            return result;
        }
    }
}