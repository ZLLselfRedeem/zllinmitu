using System;
using System.Collections.Generic;
using System.Linq;
using YJC.Toolkit.Cache;
using YJC.Toolkit.Data;
using YJC.Toolkit.Sys;
using YJC.Toolkit.Weixin.Corporation;

namespace YJC.Toolkit.Weixin.Data
{
    [Tree(Author = "YJC", CreateDate = "2014-11-24", Description = "生成组织的树")]
    [InstancePlugIn, AlwaysCache]
    internal class CorpDepartmentTree : ITree, ITreeOperation
    {
        public readonly static ITree Instance = new CorpDepartmentTree();
        private readonly static ITreeOperation Operation =
            new DefaultTreeOperation(TreeOperation.NewChild, string.Empty);

        private CorpDepartmentTree()
        {
        }

        #region ITree 成员

        public int TopLevel
        {
            get
            {
                return 1;
            }
        }

        public string RootParentId
        {
            get
            {
                return "0";
            }
        }

        public IEnumerable<ITreeNode> RootNodes
        {
            get
            {
                var list = GetDepartments();
                return from item in list.Department
                       orderby item.Order
                       select new ObjectTreeNode(item, "0");
            }
        }

        public ITreeNode GetTreeNode(string id)
        {
            var list = GetDepartments();
            return list.Department[id];
        }

        public IEnumerable<ITreeNode> GetDisplayTreeNodes(string id)
        {
            return RootNodes;
        }

        public IEnumerable<ITreeNode> GetChildNodes(string parentId)
        {
            var list = GetDepartments();
            return from item in list.GetChildren(parentId.Value<int>())
                   select new ObjectTreeNode(item, "0");
        }

        #endregion

        #region ITreeOperation 成员

        public TreeOperation Support
        {
            get
            {
                return TreeOperation.NewChild | TreeOperation.MoveUpDown;
            }
        }

        public string RootId
        {
            get
            {
                return string.Empty;
            }
        }

        public string IdFieldName
        {
            get
            {
                return DbTreeDefinition.ID_FIELD;
            }
        }

        public string ParentFieldName
        {
            get
            {
                return DbTreeDefinition.PARENT_ID_FIELD;
            }
        }

        public object MoveTreeNode(string srcNodeId, string dstNodeId)
        {
            throw new NotSupportedException();
        }

        public object MoveUpDown(string nodeId, TreeNodeMoveDirection direction)
        {
            CorpDepartmentCollection depts = GetDepartments();
            var node = depts.Department[nodeId];
            var list = depts.GetChildren(node.ParentId).ToArray();
            int index = Array.IndexOf(list, node);
            CorpDepartment swapNode = null;
            switch (direction)
            {
                case TreeNodeMoveDirection.Up:
                    if (index == 0)
                        break;
                    swapNode = list[index - 1];
                    break;
                case TreeNodeMoveDirection.Down:
                    if (index == list.Length - 1)
                        break;
                    swapNode = list[index + 1];
                    break;
            }
            if (swapNode != null)
            {
                node.VerifyOrder();
                swapNode.VerifyOrder();
                int swap = node.Order;
                node.Order = swapNode.Order;
                swapNode.Order = swap;

                node.Update();
                swapNode.Update();
                WeDataUtil.SaveData(WeCorpConst.CORP_DEPT_NAME, depts);
            }

            return new KeyData("Id", nodeId);
        }

        #endregion

        private static CorpDepartmentCollection GetDepartments()
        {
            return WeDataUtil.GetCacheData<CorpDepartmentCollection>(
                WeCorpConst.CORP_DEPT_NAME);
        }
    }
}
