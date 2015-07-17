using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Corporation
{
    [RegType(Author = "YJC", CreateDate = "2014-11-20", RegName = "CorpDepartment",
       Description = "微信企业号的组织部门信息")]
    class CorpDepartmentProxy
    {
        [SimpleAttribute]
        public string Id { get; private set; }

        [SimpleAttribute]
        public string Name { get; private set; }

        [SimpleAttribute]
        public int ParentId { get; private set; }
    }
}
