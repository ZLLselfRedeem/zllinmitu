using System;
using YJC.Toolkit.MetaData;        
using YJC.Toolkit.Data;        
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Accounting
{
    internal class FieldConfigItem : IFieldInfo, IFieldInfoEx, IRegName, IReadObjectCallBack
    {
        private static readonly FieldLayoutAttribute fLayout = new FieldLayoutAttribute();

        #region IFieldInfoEx 成员

        public int Length
        {
            get
            {
                return 0;
            }
        }

        [SimpleAttribute(DefaultValue = true)]
        public bool IsEmpty { get; private set; }

        [SimpleAttribute]
        public int Precision { get; private set; }

        public FieldKind Kind
        {
            get
            {
                return Style == FieldStyle.Title ? FieldKind.Virtual : FieldKind.Data;
            }
        }

        public string Expression
        {
            get
            {
                return null;
            }
        }

        public IFieldLayout Layout
        {
            get
            {
                return fLayout;
            }
        }


        IFieldControl IFieldInfoEx.Control
        {
            get
            {
                return Control;
            }
        }

        public IFieldDecoder Decoder
        {
            get
            {
                return null;
            }
        }

        public IFieldUpload Upload
        {
            get
            {
                return null;
            }
        }

        #endregion

        #region IFieldInfo 成员


        [SimpleElement(NamespaceType.Toolkit)]
        public string FieldName { get; private set; }

        string IFieldInfo.DisplayName
        {
            get
            {
                return DisplayName.ToString();
            }
        }

        public string NickName
        {
            get
            {
                return FieldName;
            }
        }

        [SimpleAttribute]
        public TkDataType DataType { get; private set; }

        public bool IsKey
        {
            get
            {
                return false;
            }
        }

        public bool IsAutoInc
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region IRegName 成员

        public string RegName
        {
            get
            {
                return FieldName;
            }
        }

        #endregion

        [SimpleAttribute]
        public int OrderNumber { get; private set; }

        [SimpleAttribute(DefaultValue = FieldStyle.Data)]
        public FieldStyle Style { get; private set; }

        [SimpleAttribute]
        public byte Indent { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public MultiLanguageText DisplayName { get; private set; }

        [ObjectElement(NamespaceType.Toolkit)]
        public ControlConfigItem Control { get; private set; }
        
        [ObjectElement(NamespaceType.Toolkit)]
        public MultiLanguageText Hint { get; private set; }

        [SimpleElement(NamespaceType.Toolkit)]
        internal string SummaryDef { get; private set; }

        #region IReadObjectCallBack 成员

        public void OnReadObject()
        {
            if (Style == FieldStyle.Title)
                Control.Control = ControlType.Label;
        }

        #endregion
    }
}