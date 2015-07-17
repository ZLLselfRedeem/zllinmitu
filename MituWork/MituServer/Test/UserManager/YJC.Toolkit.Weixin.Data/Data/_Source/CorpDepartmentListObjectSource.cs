using System.Collections;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-11-20",
        Description = "微信企业号的组织部门列表数据源")]
    class CorpDepartmentListObjectSource : BaseWeixinListSource
    {
        private readonly IList<CorpDepartment> fDepts;

        public CorpDepartmentListObjectSource()
        {
            var depts = WeDataUtil.GetCacheData<CorpDepartmentCollection>(WeCorpConst.CORP_DEPT_NAME);
            fDepts = depts.Department;
        }

        protected override int Count
        {
            get
            {
                return fDepts == null ? 0 : fDepts.Count;
            }
        }

        protected override IEnumerable AllData
        {
            get
            {
                return fDepts;
            }
        }
    }
}
