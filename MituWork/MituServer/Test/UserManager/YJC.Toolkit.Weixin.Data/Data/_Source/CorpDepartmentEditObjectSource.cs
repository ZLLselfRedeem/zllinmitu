using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-11-20",
        Description = "微信企业号组织部门的编辑数据源")]
    [InstancePlugIn, AlwaysCache]
    internal class CorpDepartmentEditObjectSource : IInsertObjectSource,
        IUpdateObjectSource, IDeleteObjectSource
    {
        public static object Instance = new CorpDepartmentEditObjectSource();

        private CorpDepartmentEditObjectSource()
        {
        }

        #region IInsertObjectSource 成员

        public object CreateNew(IInputData input)
        {
            int parentId = input.QueryString["ParentId"].Value<int>(1);
            CorpDepartment dept = new CorpDepartment() { ParentId = parentId };
            return dept;
        }

        public OutputData Insert(IInputData input, object instance)
        {
            CorpDepartmentProxy dept = instance.Convert<CorpDepartmentProxy>();
            var deptList = WeDataUtil.GetCacheData<CorpDepartmentCollection>(
                WeCorpConst.CORP_DEPT_NAME);

            var lastNode = deptList.Department[deptList.Department.Count - 1];
            var newDept = CorpDepartment.Create(dept.ParentId, dept.Name, lastNode.Id + 1);
            deptList.Department.Add(newDept);
            WeDataUtil.SaveData(WeCorpConst.CORP_DEPT_NAME, deptList);

            return OutputData.CreateToolkitObject(new KeyData(newDept));
        }

        #endregion

        #region IUpdateObjectSource 成员

        public OutputData Update(IInputData input, object instance)
        {
            CorpDepartmentProxy dept = instance.Convert<CorpDepartmentProxy>();

            CorpDepartmentCollection deptList;
            var oldDept = FindDept(dept.Id, out deptList);
            oldDept.Name = dept.Name;
            oldDept.Update();
            WeDataUtil.SaveData(WeCorpConst.CORP_DEPT_NAME, deptList);

            return OutputData.CreateToolkitObject(new KeyData(oldDept));
        }

        #endregion

        #region IDetailObjectSource 成员

        public object Query(IInputData input, string id)
        {
            CorpDepartmentCollection deptList;
            return FindDept(id, out deptList);
        }

        #endregion

        #region IDeleteObjectSource 成员

        public OutputData Delete(IInputData input, string id)
        {
            CorpDepartmentCollection deptList;
            var dept = FindDept(id, out deptList);

            deptList.Department.Remove(dept);
            dept.Delete();
            WeDataUtil.SaveData(WeCorpConst.CORP_DEPT_NAME, deptList);

            return OutputData.CreateToolkitObject(new KeyData(dept));
        }

        #endregion

        private static CorpDepartment FindDept(string id, out CorpDepartmentCollection deptList)
        {
            deptList = WeDataUtil.GetCacheData<CorpDepartmentCollection>(WeCorpConst.CORP_DEPT_NAME);
            CorpDepartment result = deptList.Department[id];
            TkDebug.AssertNotNull(result, string.Format(ObjectUtil.SysCulture,
                "数据有错误,无法找到Id为{0}的Department", id), null);
            return result;
        }
    }
}
