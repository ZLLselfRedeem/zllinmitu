using YJC.Toolkit.Data;
using YJC.Toolkit.Data.Constraint;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    /// <summary>
    ///  微信企业用户(WE_CORP_USER)的数据访问层类
    /// </summary>
    [Resolver(Author = "YJC", CreateDate = "2014-12-04",
        Description = "微信企业用户(WE_CORP_USER)的数据访问层类")]
    internal class CorpUserResolver : MetaDataTableResolver
    {
        class SchemaConfig
        {
            [DynamicElement(TableSchemeConfigFactory.REG_NAME)]
            public IConfigCreator<ITableScheme> Schema { get; set; }
        }

        private const string XML = "<tk:Toolkit xmlns:tk='http://www.qdocuments.net'><tk:DbCustomTable TableName='WE_CORP_USER'/></tk:Toolkit>";
        private readonly CorpUserStatusList fUserList;

        /// <summary>
        /// 建构函数，设置附着的Xml文件。
        /// </summary>
        /// <param name="context">数据库连接上下文</param>
        /// <param name="source">附着的数据源</param>
        public CorpUserResolver(IDbDataSource source)
            : base(CreateSchema(), source)
        {
            FakeDelete = new FakeDeleteInfo("ValidFlag", "1");
            AutoUpdateKey = true;
            AutoTrackField = true;
            fUserList = new CorpUserStatusList();
            if (CommitSource != null)
                CommitSource.CommittedData += CommitSource_CommittedData;
        }

        private void CommitSource_CommittedData(object sender, CommittedDataEventArgs e)
        {
            fUserList.UpdateServer();
        }

        /// <summary>
        /// 在表发生新建、修改和删除的时候触动。注意，千万不要删除base.OnUpdatingRow(e);
        /// UpdatingRow事件附着在基类该函数中。
        /// </summary>
        /// <param name="e">事件参数</param>
        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            CorpUser user = new CorpUser();
            switch (e.Status)
            {
                case UpdateKind.Insert:
                    e.Row["Department"] = "\"1\"";
                    user.ReadFromDataRow(e.Row, WeCorpConst.USER_MODE);
                    fUserList.Add(UpdateKind.Insert, user);
                    break;
                case UpdateKind.Update:
                    user.ReadFromDataRow(e.Row, WeCorpConst.USER_MODE);
                    fUserList.Add(e.InvokeMethod, user);
                    break;
            }
        }

        protected override void SetListSearches()
        {
            base.SetListSearches();

            IFieldInfo nameField = GetFieldInfo("Name");
            MultipleFieldListSearch search = new MultipleFieldListSearch(
                nameField, GetFieldInfo("Mobile"), GetFieldInfo("Weixin"));
            ListSearches.Add(nameField, search);
        }

        protected override void SetConstraints(IPageStyle style)
        {
            base.SetConstraints(style);

            IFieldInfo mobile = GetFieldInfo("Mobile");
            //IFieldInfo email = GetFieldInfo("Email");
            var constraint = new MultipleNotEmptyConstraint(mobile, GetFieldInfo("Weixin"));

            Constraints.Add(constraint);
            //Constraints.Add(new EmailConstraint(email));
            //Constraints.Add(new MobileConstraint(mobile));
            Constraints.Add(new NotEmptyConstraint(GetFieldInfo("Name")));

            IFieldInfo logonName = GetFieldInfo("UserLogonName");
            Constraints.Add(new NotEmptyConstraint(logonName));
            Constraints.Add(new SingleValueConstraint(logonName));
            Constraints.Add(new RegexConstraint(logonName, logonName.DisplayName + "只能由字母和数字构成",
                "^[0-9a-zA-Z]+$"));
        }

        //protected override void AddCodeTable(IPageStyle style, Dictionary<string, CodeTable> codeTables)
        //{
        //    base.AddCodeTable(style, codeTables);

        //    const string CodeName = "CodeSex";
        //    if (!codeTables.ContainsKey(CodeName))
        //    {
        //        CodeTable ct = PlugInFactoryManager.CreateInstance<CodeTable>(
        //            CodeTablePlugInFactory.REG_NAME, CodeName);
        //        codeTables.Add(CodeName, ct);
        //    }
        //}

        public static ITableSchemeEx CreateSchema()
        {
            SchemaConfig config = new SchemaConfig();
            config.ReadXml(XML);
            ITableScheme scheme = config.Schema.CreateObject();
            return scheme.Convert<ITableSchemeEx>();
        }

        //private static Tk5DataXml CreateScheme()
        //{
        //    return Tk5DataXml.Create(ResourceUtil.GetEmbeddedResource("CorpUser.xml"));
        //}
    }
}