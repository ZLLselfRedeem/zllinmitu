using YJC.Toolkit.Collections;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [EasySearch(Author = "YJC", CreateDate = "2015-01-05", Description = "微信企业号组织部门的EasySearch")]
    internal class CorpDepartmentEasySearch : CodeDataEasySearch<CorpDepartment>, IConfigCreator<ITree>
    {
        public CorpDepartmentEasySearch()
            : base(CreateList())
        {
        }

        #region IConfigCreator<ITree> 成员

        public ITree CreateObject(params object[] args)
        {
            return CorpDepartmentTree.Instance;
        }

        #endregion

        internal static RegNameList<CorpDepartment> CreateList()
        {
            var list = WeDataUtil.GetCacheData<CorpDepartmentCollection>(WeCorpConst.CORP_DEPT_NAME);
            return list.Department;
        }
    }
}
