using System;
using System.Collections.Generic;
using YJC.Toolkit.Data;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    internal class ControlConfigItem : IFieldControl
    {

        [SimpleAttribute]
        public ControlType Control { get; internal set; }

        [SimpleAttribute]
        public int Order { get; private set; }

        [ObjectElement(NamespaceType.Toolkit, IsMultiple = true, LocalName = "Attribute")]
        public List<HtmlAttribute> AttributeList { get; private set; }

        #region IFieldControl 成员

        public PageStyle DefaultShow
        {
            get
            {
                return PageStyle.All;
            }
        }

        public ControlType GetControl(IPageStyle style)
        {
            return Control;
        }

        public int GetOrder(IPageStyle style)
        {
            return Order;
        }

        public string GetCustomControl(IPageStyle style)
        {
            return null;
        }

        #endregion
    }
}