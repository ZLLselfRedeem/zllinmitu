using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    class CorpUserStatusList
    {
        private Dictionary<UpdateKind, List<CorpUser>> fDictionary;

        public CorpUserStatusList()
        {
            fDictionary = new Dictionary<UpdateKind, List<CorpUser>>();
        }

        private List<CorpUser> GetList(UpdateKind kind)
        {
            List<CorpUser> list;
            if (fDictionary.TryGetValue(kind, out list))
                return list;

            list = new List<CorpUser>();
            fDictionary.Add(kind, list);
            return list;
        }

        public void Add(UpdateKind kind, CorpUser user)
        {
            var list = GetList(kind);

            list.Add(user);
        }

        public void UpdateServer()
        {
            foreach (var item in fDictionary)
            {
                switch (item.Key)
                {
                    case UpdateKind.Insert:
                        foreach (var user in item.Value)
                            user.Create();
                        break;
                    case UpdateKind.Update:
                        foreach (var user in item.Value)
                        {
                            user.Enable = true;
                            user.Update();
                        }
                        break;
                    case UpdateKind.Delete:
                        foreach (var user in item.Value)
                            user.Delete();
                        break;
                }
            }
        }
    }
}
