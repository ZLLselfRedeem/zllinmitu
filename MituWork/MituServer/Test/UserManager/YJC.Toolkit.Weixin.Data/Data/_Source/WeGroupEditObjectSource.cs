using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.User;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-11-19",
        Description = "微信公众号用户组的编辑数据源")]
    [InstancePlugIn, AlwaysCache]
    public class WeGroupEditObjectSource : IInsertObjectSource, IUpdateObjectSource
    {
        public static object Instance = new WeGroupEditObjectSource();

        #region IObjectInsertSource 成员

        public object CreateNew(IInputData input)
        {
            return new WeGroup();
        }

        public OutputData Insert(IInputData input, object instance)
        {
            WeGroupProxy group = instance.Convert<WeGroupProxy>();
            WeGroup newGroup = WeGroup.CreateGroup(group.Name);

            var groups = WeDataUtil.GetCacheData<WeGroupCollection>(WeDataConst.WEGROUP_NAME);
            groups.Groups.Add(newGroup);
            WeDataUtil.SaveData(WeDataConst.WEGROUP_NAME, groups);

            return OutputData.CreateToolkitObject(new KeyData(newGroup));
        }

        #endregion

        #region IObjectUpdateSource 成员

        public OutputData Update(IInputData input, object instance)
        {
            WeGroupProxy group = instance.Convert<WeGroupProxy>();

            var groups = WeDataUtil.GetCacheData<WeGroupCollection>(WeDataConst.WEGROUP_NAME);
            var oldGroup = groups.Groups[group.Id];
            if (oldGroup == null)
                throw new WebPostException(string.Format(ObjectUtil.SysCulture,
                    "提交数据有错误,无法找到Id为{0}的Group", group.Id));

            oldGroup.Name = group.Name;
            oldGroup.Update();
            WeDataUtil.SaveData(WeDataConst.WEGROUP_NAME, groups);

            return OutputData.CreateToolkitObject(new KeyData(oldGroup));
        }

        #endregion

        #region IObjectDetailSource 成员

        public object Query(IInputData input, string id)
        {
            var groups = WeDataUtil.GetCacheData<WeGroupCollection>(WeDataConst.WEGROUP_NAME);
            return groups.Groups[id];
        }

        #endregion

    }
}
