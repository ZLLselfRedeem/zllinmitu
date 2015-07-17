using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeGroupProductActionList : WeGroupId
    {
        internal WeGroupProductActionList()
        {
            Product = new List<WeGroupProductAction>();
        }

        public WeGroupProductActionList(int groupId, WeGroupProductAction product)
            : base(groupId)
        {
            Product = new List<WeGroupProductAction>();
            Product.Add(product);
        }

        public WeGroupProductActionList(int groupId, WeGroupProductAction[] productList)
            : base(groupId)
        {
            Product = new List<WeGroupProductAction>();
            Product.AddRange(productList);
        }

        [ObjectElement(IsMultiple = true, Order = 20, NamingRule = NamingRule.Camel)]
        public List<WeGroupProductAction> Product { get; private set; }
    }
}
