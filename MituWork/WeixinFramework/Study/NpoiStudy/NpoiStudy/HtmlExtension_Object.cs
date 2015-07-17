using System;
using System.Collections.Generic;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;
using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Web
{
    public static partial class HtmlExtension
    {
        private static object MemberValue(string fieldName, object receiver)
        {
            object value = null;
            try
            {
                value = receiver.MemberValue(fieldName);
            }
            catch
            {
            }
            return value;
        }

        private static string FormatNumber(Tk5FieldInfoEx field, string fieldName, object receiver)
        {
            object value = MemberValue(fieldName, receiver);
            return InternalFormatNumber(field, value);
        }

        private static string DisplayValue(Tk5FieldInfoEx field, ObjectContainer container, bool showHint)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            //if (field.Upload != null)
            //    return DisplayUpload(field, row);

            object receiver = container.MainObject;
            string displayValue = string.Empty;
            string value = string.Empty;
            try
            {
                value = receiver.MemberValue(field.NickName).ConvertToString();
                if (field.Decoder == null || field.Decoder.Type == DecoderType.None)
                    displayValue = FormatNumber(field, field.NickName, receiver);
                else
                    displayValue = container.Decoder.GetNameString(field.NickName);
            }
            catch
            {
                displayValue = value;
            }
            if (showHint)
            {
                if (!string.IsNullOrEmpty(field.Hint))
                    displayValue += " " + field.Hint;
            }
            if (field.ListDetail != null && field.ListDetail.Link != null)
            {
                var link = field.ListDetail.Link;
                string linkUrl = string.Empty;
                string target = string.Empty;
                switch (link.RefType)
                {
                    case LinkRefType.Href:
                        linkUrl = HtmlUtil.ParseLinkUrl(receiver, link.Content);
                        linkUrl = WebUtil.ResolveUrl(linkUrl);
                        if (!string.IsNullOrEmpty(link.Base))
                            linkUrl = UriUtil.CombineUri(link.Base, linkUrl).ToString();
                        if (!string.IsNullOrEmpty(link.Target))
                            target = string.Format(ObjectUtil.SysCulture, " target=\"{0}\"", link.Target);
                        break;
                    case LinkRefType.Http:
                        if (!value.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                            linkUrl = "http://";
                        linkUrl += value;
                        target = " target=\"_blank\"";
                        break;
                    case LinkRefType.Email:
                        linkUrl = "mailto:" + value;
                        target = " target=\"_blank\"";
                        break;
                }
                return string.Format(ObjectUtil.SysCulture, "<a href=\"{0}\"{1}>{2}</a>",
                    StringUtil.EscapeHtmlAttribute(linkUrl), target, StringUtil.EscapeHtml(displayValue));
            }
            return displayValue;
        }

        public static string Detail(this Tk5FieldInfoEx field, ObjectContainer container, bool showHint, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            object receiver = container.MainObject;
            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            AddNormalAttribute(field, builder, field.NickName, needId, true);
            builder.Add("data-value", receiver.MemberValue(field.NickName).ConvertToString());
            HtmlAttribute classAttr = builder["class"];
            if (classAttr == null)
                builder.Add("class", "detail-content");
            else
                classAttr.Value = HtmlUtil.MergeClass(classAttr.Value, "detail-content");
            return string.Format(ObjectUtil.SysCulture, "<div {0}>{1}</div>",
                builder.CreateAttribute(), DisplayValue(field, container, showHint));
        }

        public static string Input(this Tk5FieldInfoEx field, ObjectContainer container, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);
            object receiver = container.MainObject;
            string value = FormatNumber(field, field.NickName, receiver);

            return InternalInput(field, field.NickName, value, needId);
        }

        public static string Hidden(this Tk5FieldInfoEx field, ObjectContainer container, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            object receiver = container.MainObject;
            object value = receiver.MemberValue(field.NickName);
            return InternalHidden(field, value.ConvertToString(), needId);
        }

        public static string DisplayValue(this Tk5FieldInfoEx field, ObjectContainer container)
        {
            if (container == null)
                return string.Empty;

            return DisplayValue(field, container, false);
        }

        private static string InternalCombo(Tk5FieldInfoEx field, string name, ObjectContainer container,
            CodeTableContainer codeTables, bool needId)
        {
            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            AddNormalAttribute(field, builder, name, needId);

            TkDebug.AssertNotNull(field.Decoder, "Combo控件需要配置Decoder", field);
            IEnumerable<IDecoderItem> codeTable = codeTables == null ? null :
                codeTables[field.Decoder.RegName];
            StringBuilder options = new StringBuilder();
            if (field.IsEmpty)
            {
                string emptyTitle;
                if (field.Extension != null && field.Extension.EmptyTitle != null)
                    emptyTitle = field.Extension.EmptyTitle;
                else
                    emptyTitle = string.Empty;
                options.Append("<option value=\"\">").Append(emptyTitle).AppendLine("</option>");
            }
            string value = MemberValue(field.NickName, container.MainObject).ConvertToString();
            if (codeTable != null)
            {
                foreach (IDecoderItem codeRow in codeTable)
                {
                    string codeValue = codeRow.Value;
                    options.AppendFormat(ObjectUtil.SysCulture, "<option value=\"{0}\"{1}>{2}</option>\r\n",
                        codeValue, codeValue == value ? " selected" : string.Empty, codeRow.Name);
                }
            }

            return string.Format(ObjectUtil.SysCulture, "<select {0}>{1}</select>{2}",
                builder.CreateAttribute(), options, ERROR_LABEL);
        }

        public static string Combo(this Tk5FieldInfoEx field, ObjectContainer container,
            CodeTableContainer codeTables, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            return InternalCombo(field, field.NickName, container, codeTables, needId);
        }

        private static string InternalTextArea(Tk5FieldInfoEx field, ObjectContainer container, HtmlAttribute addition, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            AddInputAttribute(field, builder);
            AddNormalAttribute(field, builder, field.NickName, needId);
            builder.Add(addition);

            return string.Format(ObjectUtil.SysCulture, "<textarea {0}>{1}</textarea>{2}",
                builder.CreateAttribute(),
                StringUtil.EscapeHtml(MemberValue(field.NickName, container).ConvertToString()),
                ERROR_LABEL);
        }

        public static string Textarea(this Tk5FieldInfoEx field, ObjectContainer container, bool needId)
        {
            return InternalTextArea(field, container, null, needId);
        }

        public static string Control(this Tk5FieldInfoEx field, ObjectContainer container,
            CodeTableContainer codeTables, bool needId = true)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            ControlType ctrlType = field.InternalControl.SrcControl;
            string result = string.Empty;

            switch (ctrlType)
            {
                case ControlType.TextArea:
                    result = field.Textarea(container, needId);
                    break;
                case ControlType.Combo:
                    result = field.Combo(container, codeTables, needId);
                    break;
                //case ControlType.RadioGroup:
                //    result = field.RadioGroup(dataRow, dataSet);
                //    break;
                case ControlType.Text:
                case ControlType.Password:
                    result = field.Input(container, needId);
                    break;
                //case ControlType.CheckBox:
                //    result = field.Switcher(dataRow);
                //    break;
                //case ControlType.Date:
                //    result = field.Date(dataRow);
                //    break;
                //case ControlType.DateTime:
                //    result = field.DateTime(dataRow);
                //    break;
                //case ControlType.Time:
                //    result = field.Time(dataRow);
                //    break;
                //case ControlType.EasySearch:
                //    result = field.EasySearch(dataRow);
                //    break;
                case ControlType.Label:
                    result = field.Detail(container, true, needId);
                    break;
                //case ControlType.RichText:
                //    result = field.RichText(dataRow);
                //    break;
                //case ControlType.Upload:
                //    result = field.Upload(dataRow);
                //    break;
            }
            return result;
        }
    }
}
