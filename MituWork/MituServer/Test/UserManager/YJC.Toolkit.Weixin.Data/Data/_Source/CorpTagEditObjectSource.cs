using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [ObjectSource(Author = "YJC", CreateDate = "2014-11-19",
        Description = "微信企业号标签的编辑数据源")]
    [InstancePlugIn, AlwaysCache]
    public class CorpTagEditObjectSource : IInsertObjectSource, IUpdateObjectSource, IDeleteObjectSource
    {
        public static object Instance = new CorpTagEditObjectSource();

        private CorpTagEditObjectSource()
        {
        }

        #region IObjectInsertSource 成员

        public object CreateNew(IInputData input)
        {
            return new CorpTag();
        }

        public OutputData Insert(IInputData input, object instance)
        {
            CorpTagProxy tag = instance.Convert<CorpTagProxy>();
            var tagList = WeDataUtil.GetCacheData<CorpTagList>(WeDataConst.CORP_TAG_NAME);

            var newTag = CorpTag.Create(tag.Name);
            tagList.TagList.Add(newTag);
            WeDataUtil.SaveData(WeDataConst.CORP_TAG_NAME, tagList);

            return OutputData.CreateToolkitObject(new KeyData(newTag));
        }

        #endregion

        #region IObjectUpdateSource 成员

        public OutputData Update(IInputData input, object instance)
        {
            CorpTagProxy tag = instance.Convert<CorpTagProxy>();

            CorpTagList tagList;
            var oldTag = FindTag(tag.Id, out tagList);
            oldTag.Name = tag.Name;
            oldTag.Update();
            WeDataUtil.SaveData(WeDataConst.CORP_TAG_NAME, tagList);

            return OutputData.CreateToolkitObject(new KeyData(oldTag));
        }

        #endregion

        #region IObjectDetailSource 成员

        public object Query(IInputData input, string id)
        {
            CorpTagList tagList;
            return FindTag(id, out tagList);
        }

        #endregion

        #region IObjectDeleteSource 成员

        public OutputData Delete(IInputData input, string id)
        {
            CorpTagList tagList;
            var tag = FindTag(id, out tagList);

            tagList.TagList.Remove(tag);
            tag.Delete();
            WeDataUtil.SaveData(WeDataConst.CORP_TAG_NAME, tagList);

            return OutputData.CreateToolkitObject(new KeyData(tag));
        }

        #endregion

        internal static CorpTag FindTag(string id, out CorpTagList tagList)
        {
            tagList = WeDataUtil.GetCacheData<CorpTagList>(WeDataConst.CORP_TAG_NAME);
            CorpTag result = tagList.TagList[id];
            TkDebug.AssertNotNull(result, string.Format(ObjectUtil.SysCulture,
                "数据有错误,无法找到Id为{0}的Tag", id), null);
            return result;
        }
    }
}
