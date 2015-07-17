using System.Collections.Generic;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Weixin.Shop
{
    internal class WeGroupProductList : WeGroupId
    {
        internal WeGroupProductList()
        {
            Product = new List<WeGroupProduct>();
        }

        public WeGroupProductList(int groupId, WeGroupProduct product)
            : base(groupId)
        {
            Product = new List<WeGroupProduct>();
            Product.Add(product);
        }

        public WeGroupProductList(int groupId, WeGroupProduct[] productList)
            : base(groupId)
        {
            Product = new List<WeGroupProduct>();
            Product.AddRange(productList);
        }

        [ObjectElement(IsMultiple = true, Order = 20, NamingRule = NamingRule.Camel)]
        public List<WeGroupProduct> Product { get; private set; }
    }
}
