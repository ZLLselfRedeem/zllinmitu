using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using YJC.Toolkit.Data;
using YJC.Toolkit.Data.Constraint;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [Source(Author = "YJC", CreateDate = "2015-01-04",
        Description = "设置企业号标签所包含的用户")]
    class CorpTagUserSource : BaseWebDbSource
    {
        private readonly CorpTagResolver fResolver;

        public CorpTagUserSource()
        {
            Context = DbContextUtil.CreateDbContext("Weixin");
            fResolver = new CorpTagResolver(this);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                fResolver.Dispose();
            }

            base.Dispose(disposing);
        }

        private IEnumerable<string> GetUserMembers(CorpTagMembers member)
        {
            if (member.UserList == null || member.UserList.Count == 0)
                return null;

            return (from item in member.UserList
                    select item.Id);
        }

        private IEnumerable<string> GetDeptMembers(CorpTagMembers member)
        {
            if (member.PartyList == null || member.PartyList.Count == 0)
                return null;

            return (from item in member.PartyList
                    select item.ToString(ObjectUtil.SysCulture));
        }

        protected override OutputData DoGet(IInputData input)
        {
            string oper = input.QueryString["Operation"];
            string dataXml = null;
            string tagFieldName = null;
            string dataXmlFieldName = null;
            Func<CorpTagMembers, IEnumerable<string>> getMembers = null;
            switch (oper)
            {
                case "User":
                    dataXml = @"Weixin\CorpTagUser.xml";
                    tagFieldName = "UserList";
                    dataXmlFieldName = "UserId";
                    getMembers = GetUserMembers;
                    break;
                case "Dept":
                    dataXml = @"Weixin\CorpTagDept.xml";
                    tagFieldName = "DepartmentList";
                    dataXmlFieldName = "DeparmentId";
                    getMembers = GetDeptMembers;
                    break;
                default:
                    TkDebug.ThrowImpossibleCode(this);
                    break;
            }
            Tk5TableResolver getResovler = new Tk5TableResolver(dataXml, this);
            using (getResovler)
            {
                DataTable table = getResovler.CreateVirtualTable();
                string tagId = input.QueryString["TagId"];
                DataRow row = fResolver.TrySelectRowWithKeys(tagId);
                if (row != null)
                {
                    QuoteStringList list = row[tagFieldName].Value<QuoteStringList>();
                    if (list != null)
                    {
                        var userList = list.CreateEnumerable();
                        foreach (string item in userList)
                        {
                            DataRow userRow = table.NewRow();
                            userRow[dataXmlFieldName] = item;
                            table.Rows.Add(userRow);
                        }
                    }
                }
                else
                {
                    CorpTag tag = new CorpTag(tagId.Value<int>());
                    CorpTagMembers members = tag.GetMembers();
                    IEnumerable<string> memList = getMembers(members);
                    if (memList != null)
                    {
                        foreach (var item in memList)
                        {
                            DataRow userRow = table.NewRow();
                            userRow[dataXmlFieldName] = item;
                            table.Rows.Add(userRow);
                        }
                    }
                }

                getResovler.Decode(input.Style);
                getResovler.FillCodeTable(input.Style);
                input.CallerInfo.AddInfo(DataSet);
            }
            return OutputData.Create(DataSet);
        }

        private void AddUserMembers(CorpTag tag, QuoteStringList postList, QuoteStringList srcList)
        {
            if (srcList == null)
            {
                List<string> list = postList.ConvertToList<string>();
                if (list.Count > 0)
                    tag.AddMembers(list, null);

                return;
            }

            string[] addList, delList;
            GetAddDelList(postList, srcList, out addList, out delList);
            if (addList.Length > 0)
                tag.AddMembers(addList, null);
            if (delList.Length > 0)
                tag.RemoveMembers(delList, null);
        }

        private void AddDeptMembers(CorpTag tag, QuoteStringList postList, QuoteStringList srcList)
        {
            if (srcList == null)
            {
                List<int> list = postList.ConvertToList<int>();
                if (list.Count > 0)
                    tag.AddMembers(null, list);

                return;
            }

            int[] addList, delList;
            GetAddDelList(postList, srcList, out addList, out delList);
            if (addList.Length > 0)
                tag.AddMembers(null, addList);
            if (delList.Length > 0)
                tag.RemoveMembers(null, delList);
        }

        private void GetAddDelList<T>(QuoteStringList postList, QuoteStringList srcList,
            out T[] addList, out T[] delList)
        {
            var postStrList = postList.ConvertToList<T>();
            if (postStrList == null)
                postStrList = new List<T>();
            var srcStrList = srcList.ConvertToList<T>();
            if (srcStrList == null)
                srcStrList = new List<T>();

            addList = postStrList.Except(srcStrList).ToArray();
            delList = srcStrList.Except(postStrList).ToArray();
        }


        protected override OutputData DoPost(IInputData input)
        {
            string oper = input.QueryString["Operation"];
            string dataXml = null;
            string tagFieldName = null;
            string dataXmlFieldName = null;
            switch (oper)
            {
                case "User":
                    dataXml = @"Weixin\CorpTagUser.xml";
                    tagFieldName = "UserList";
                    dataXmlFieldName = "UserId";
                    break;
                case "Dept":
                    dataXml = @"Weixin\CorpTagDept.xml";
                    tagFieldName = "DepartmentList";
                    dataXmlFieldName = "DeparmentId";
                    break;
                default:
                    TkDebug.ThrowImpossibleCode(this);
                    break;
            }
            Tk5TableResolver getResovler = new Tk5TableResolver(dataXml, this);
            using (getResovler)
            {
                DataSet postDataSet = input.PostObject.Convert<DataSet>();
                getResovler.PrepareDataSet(postDataSet);

                FieldErrorInfoCollection errors = new FieldErrorInfoCollection();
                getResovler.CheckFirstConstraints(input, errors);
                getResovler.CheckLaterConstraints(input, errors);
                errors.CheckError();

                QuoteStringList postList = new QuoteStringList();
                DataTable postTable = postDataSet.Tables[getResovler.TableName];
                if (postTable != null)
                {
                    foreach (DataRow postRow in postTable.Rows)
                        postList.Add(postRow[dataXmlFieldName].ToString());
                }
                string tagId = input.QueryString["TagId"];

                CorpTagList tagList;
                CorpTag tag = CorpTagEditObjectSource.FindTag(tagId, out tagList);

                DataRow row = fResolver.TrySelectRowWithKeys(tagId);
                if (row == null)
                {
                    fResolver.SetCommands(AdapterCommand.Insert);
                    row = fResolver.NewRow();
                    row.BeginEdit();
                    row["TagId"] = tagId;
                    row["Name"] = tag.Name;
                    row[tagFieldName] = postList.ToString();
                    row.EndEdit();
                    switch (oper)
                    {
                        case "User":
                            AddUserMembers(tag, postList, null);
                            break;
                        case "Dept":
                            AddDeptMembers(tag, postList, null);
                            break;
                    }

                    fResolver.UpdateDatabase();
                }
                else
                {
                    fResolver.SetCommands(AdapterCommand.Update);
                    QuoteStringList sourceList = row[tagFieldName].Value<QuoteStringList>();
                    row[tagFieldName] = postList.ToString();

                    switch (oper)
                    {
                        case "User":
                            AddUserMembers(tag, postList, sourceList);
                            break;
                        case "Dept":
                            AddDeptMembers(tag, postList, sourceList);
                            break;
                    }

                    fResolver.UpdateDatabase();
                }

                return OutputData.CreateToolkitObject(fResolver.CreateKeyData());
            }
        }
    }
}
