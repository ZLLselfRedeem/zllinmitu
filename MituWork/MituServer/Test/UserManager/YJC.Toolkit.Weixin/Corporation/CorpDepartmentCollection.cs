using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Cache;
using YJC.Toolkit.Collections;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    [DayChangeCache]
    internal class CorpDepartmentCollection : WeixinResult
    {
        [ObjectElement(IsMultiple = true, NamingRule = NamingRule.Camel, Order = 30, UseConstructor = true)]
        public RegNameList<CorpDepartment> Department { get; private set; }

        public IEnumerable<CorpDepartment> GetChildren(int id)
        {
            if (Department == null)
                return Enumerable.Empty<CorpDepartment>();

            var result = from item in Department
                         where item.ParentId == id
                         orderby item.Order
                         select item;
            return result;
        }

        public CorpDepartment GetParent(int parentId)
        {
            if (Department == null)
                return null;

            return Department[parentId.ToString(ObjectUtil.SysCulture)];
        }
    }
}
