using System;
using System.Data;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;

namespace Cxcs.Data
{
    [Resolver(Author = "YJC", CreateDate = "2014-10-29",
        Description = "群发主表(CS_WEIXIN_MASS)的数据访问层类")]
    class WeixinMassResolver : Tk5TableResolver
    {
        internal const string DATAXML = "CXCS/WeixinMass.xml";

        public WeixinMassResolver(IDbDataSource source)
            : base(DATAXML, source)
        {
            AutoTrackField = true;
            AutoUpdateKey = true;
        }

        protected override void OnUpdatingRow(UpdatingEventArgs e)
        {
            base.OnUpdatingRow(e);

            TaxDocumentResolver resolver;
            DataRow docRow;
            switch (e.Status)
            {
                case UpdateKind.Update:
                    int flag = e.Row["SendFlag"].Value<int>();
                    if (flag == 0)
                    {
                        resolver = new TaxDocumentResolver(Source);
                        NonUIResolvers.NonUIResolvers.Add(resolver);
                        docRow = resolver.SelectRowWithKeys(e.Row["DocId"]);
                        docRow["MassFlag"] = 1;
                        resolver.SetCommands(AdapterCommand.Update);
                        e.Row["SendFlag"] = 1;
                    }
                    break;
                case UpdateKind.Delete:
                    resolver = new TaxDocumentResolver(Source);
                    NonUIResolvers.NonUIResolvers.Add(resolver);
                    docRow = resolver.SelectRowWithKeys(e.Row["DocId"]);
                    docRow.BeginEdit();
                    docRow["MassFlag"] = 0;
                    docRow["MassId"] = DBNull.Value;
                    docRow.EndEdit();
                    resolver.SetCommands(AdapterCommand.Update);
                    break;
            }
        }

        public string NewRow(string docId)
        {
            SetCommands(AdapterCommand.Insert);
            DataRow massRow = NewRow();
            massRow.BeginEdit();
            string id = CreateUniId();
            massRow["MassId"] = id;
            massRow["DocId"] = docId;
            massRow["SendFlag"] = 0;
            UpdateTrackField(UpdateKind.Insert, massRow);
            massRow.EndEdit();
            return id;
        }
    }
}
