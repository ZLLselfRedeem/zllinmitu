using System;
using System.Data;
using System.Linq;
using System.Text;
using YJC.Toolkit.Data;
using YJC.Toolkit.Decoder;
using YJC.Toolkit.MetaData;

using YJC.Toolkit.Sys;

namespace YJC.Toolkit.Web
{
    public static partial class HtmlExtension
    {
        private static string FormatNumber(Tk5FieldInfoEx field, string fieldName, DataRow row)
        {
            object value = null;
            try
            {
                value = row[fieldName];
            }
            catch
            {
            }
            return InternalFormatNumber(field, value);
        }

        private static string InternalTextArea(Tk5FieldInfoEx field, DataRow row, HtmlAttribute addition, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            AddInputAttribute(field, builder);
            AddNormalAttribute(field, builder, field.NickName, needId);
            builder.Add(addition);

            return string.Format(ObjectUtil.SysCulture, "<textarea {0}>{1}</textarea>{2}",
                builder.CreateAttribute(), StringUtil.EscapeHtml(row.GetString(field.NickName)),
                ERROR_LABEL);
        }

        public static string Textarea(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            return InternalTextArea(field, row, null, needId);
        }

        public static string RichText(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            HtmlAttribute ctrlAttr = new HtmlAttribute("data-control", field.InternalControl.Control);
            return InternalTextArea(field, row, ctrlAttr, needId);
        }

        public static string Input(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);
            string value = FormatNumber(field, field.NickName, row);

            return InternalInput(field, field.NickName, value, needId);
        }

        private static string InputEnd(Tk5FieldInfoEx field, DataRow row)
        {
            TkDebug.AssertArgumentNull(field, "field", null);
            string name = GetSearchEndName(field);
            string value = FormatNumber(field, name, row);

            return InternalInput(field, name, value, true);
        }

        private static string InternalCombo(Tk5FieldInfoEx field, string name, DataRow row, DataSet model, bool needId)
        {
            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            AddNormalAttribute(field, builder, name, needId);

            TkDebug.AssertNotNull(field.Decoder, "Combo控件需要配置Decoder", field);
            DataTable codeTable = model.Tables[field.Decoder.RegName];
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
            string value = row.GetString(name);
            if (codeTable != null)
            {
                foreach (DataRow codeRow in codeTable.Rows)
                {
                    string codeValue = codeRow.GetString("Value");
                    options.AppendFormat(ObjectUtil.SysCulture, "<option value=\"{0}\"{1}>{2}</option>\r\n",
                        codeValue, codeValue == value ? " selected" : string.Empty,
                        codeRow.GetString("Name"));
                }
            }

            return string.Format(ObjectUtil.SysCulture, "<select {0}>{1}</select>{2}",
                builder.CreateAttribute(), options, ERROR_LABEL);
        }

        public static string Combo(this Tk5FieldInfoEx field, DataRow row, DataSet model, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);
            TkDebug.AssertArgumentNull(model, "model", null);
            return InternalCombo(field, field.NickName, row, model, needId);
        }

        private static string ComboEnd(Tk5FieldInfoEx field, DataRow row, DataSet model)
        {
            string name = GetSearchEndName(field);

            return InternalCombo(field, name, row, model, true);
        }

        public static string RadioGroup(this Tk5FieldInfoEx field, DataRow row, DataSet model, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);
            TkDebug.AssertArgumentNull(model, "model", null);

            TkDebug.AssertNotNull(field.Decoder, "RadioGroup控件需要配置Decoder", field);
            DataTable codeTable = model.Tables[field.Decoder.RegName];
            StringBuilder options = new StringBuilder();
            if (codeTable != null)
            {
                HtmlAttributeBuilder divBuilder = new HtmlAttributeBuilder();
                AddNormalAttribute(field, divBuilder, field.NickName, needId, true);
                divBuilder.Add("data-control", "RadioGroup");

                HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
                builder.Add("type", "radio");
                builder.Add("name", field.NickName);
                builder.Add("class", "radio-center");

                string value = row.GetString(field.NickName);
                options.AppendFormat(ObjectUtil.SysCulture, "<div {0}>\r\n", divBuilder.CreateAttribute());
                foreach (DataRow codeRow in codeTable.Rows)
                {
                    string codeValue = codeRow.GetString("Value");
                    builder.Add("value", codeValue);
                    options.AppendFormat(ObjectUtil.SysCulture,
                        "  <label class=\"checkbox-inline\"><input {0}{1}> {2}</label>\r\n",
                        builder.CreateAttribute(), codeValue == value ? " checked" : string.Empty,
                        codeRow.GetString("Name"));
                }
                options.Append("</div>").AppendLine(ERROR_LABEL);
            }
            return options.ToString();
        }


        public static string CheckBoxList(this Tk5FieldInfoEx field, DataRow row, DataSet model, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);
            TkDebug.AssertArgumentNull(model, "model", null);

            TkDebug.AssertNotNull(field.Decoder, "CheckBoxList控件需要配置Decoder", field);
            DataTable codeTable = model.Tables[field.Decoder.RegName];
            StringBuilder options = new StringBuilder();
            if (codeTable != null)
            {
                HtmlAttributeBuilder divBuilder = new HtmlAttributeBuilder();
                AddNormalAttribute(field, divBuilder, field.NickName, needId, true);
                divBuilder.Add("data-control", "CheckBoxList");

                HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
                //builder.Add("type", "radio");
                //builder.Add("name", field.NickName);
                //builder.Add("class", "radio-center");

                string value = row.GetString(field.NickName);
                QuoteStringList quoteValue = QuoteStringList.FromString(value);
                options.AppendFormat(ObjectUtil.SysCulture, "<div {0}>\r\n", divBuilder.CreateAttribute());
                foreach (DataRow codeRow in codeTable.Rows)
                {
                    builder.Clear();
                    string codeValue = codeRow.GetString("Value");
                    builder.Add("value", codeValue);
                    if (quoteValue.Contains(codeValue))
                        builder.Add((HtmlAttribute)"checked");
                    options.AppendFormat(ObjectUtil.SysCulture, Html.CheckBoxListItem,
                        builder.CreateAttribute(), codeRow.GetString("Name"));
                }
                options.Append("</div>").AppendLine(ERROR_LABEL);
            }
            return options.ToString();
        }

        private static HtmlAttributeBuilder InternalCheckBox(Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            string checkValue;
            string uncheckValue;
            GetCheckValue(field, out checkValue, out uncheckValue);
            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            builder.Add("type", "checkbox");
            builder.Add("value", checkValue);
            builder.Add("data-uncheck-value", uncheckValue);
            if (row.GetString(field.NickName) == checkValue)
                builder.Add((HtmlAttribute)"checked");
            AddNormalAttribute(field, builder, field.NickName, needId, true);
            return builder;
        }

        public static string CheckBox(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            HtmlAttributeBuilder builder = InternalCheckBox(field, row, needId);
            return string.Format(ObjectUtil.SysCulture, Html.CheckBox,
                builder.CreateAttribute(), field.DisplayName);
        }

        public static string Hidden(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            return InternalHidden(field, row.GetString(field.NickName), needId);
        }

        private static string InternalEasySearch(Tk5FieldInfoEx field, string nickName, DataRow row, bool needId)
        {
            HtmlAttributeBuilder hiddenBuilder = new HtmlAttributeBuilder();
            hiddenBuilder.Add("type", "hidden");
            hiddenBuilder.Add("value", row.GetString(nickName));
            string hiddenName = "hd" + nickName;
            if (needId)
                hiddenBuilder.Add("id", hiddenName);
            hiddenBuilder.Add("name", hiddenName);
            HtmlAttributeBuilder textBuilder = new HtmlAttributeBuilder();
            textBuilder.Add("type", "text");
            textBuilder.Add("data-regName", field.Decoder.RegName);
            AddInputAttribute(field, textBuilder);
            AddNormalAttribute(field, textBuilder, nickName, needId);
            textBuilder.Add("value", row.GetString(nickName + "_Name"));

            string easyUrl = "Library/WebModuleContentPage.tkx?Source=EasySearch&useSource=true".AppVirutalPath();
            string dialogUrl = ("Library/WebModuleRedirectPage.tkx?Source=EasySearchRedirect&useSource=true&RegName="
                + field.Decoder.RegName).AppVirutalPath();

            return string.Format(ObjectUtil.SysCulture, Html.EasySearch,
                hiddenBuilder.CreateAttribute(), textBuilder.CreateAttribute(), ERROR_LABEL,
                StringUtil.EscapeHtmlAttribute(easyUrl), StringUtil.EscapeHtmlAttribute(dialogUrl));
        }

        private static string InternalMultiEasySearch(Tk5FieldInfoEx field, string nickName, DataRow row, bool needId)
        {
            HtmlAttributeBuilder textBuilder = new HtmlAttributeBuilder();
            textBuilder.Add("type", "text");
            textBuilder.Add("data-regName", field.Decoder.RegName);
            AddInputAttribute(field, textBuilder);
            AddNormalAttribute(field, textBuilder, nickName, needId);
            StringBuilder multiItems = new StringBuilder();
            string decodeValue = row.GetString(nickName + "_Name");
            if (string.IsNullOrEmpty(decodeValue))
                multiItems.AppendFormat(Html.MultiEasySearchItem, "hidden", string.Empty, string.Empty);
            else
            {
                MultipleDecoderData data = MultipleDecoderData.ReadFromString(decodeValue);
                HtmlAttributeBuilder decodeBuilder = new HtmlAttributeBuilder();
                foreach (var item in data)
                {
                    decodeBuilder.Clear();
                    decodeBuilder.Add("data-id", item.Value);
                    decodeBuilder.Add("data-name", item.Name);

                    multiItems.AppendFormat(Html.MultiEasySearchItem, "multi-item", 
                        item.Name, decodeBuilder.CreateAttribute());
                }
            }

            string easyUrl = "Library/WebModuleContentPage.tkx?Source=EasySearch&useSource=true".AppVirutalPath();
            string dialogUrl = ("Library/WebModuleRedirectPage.tkx?Source=EasySearchRedirect&useSource=true&RegName="
                + field.Decoder.RegName).AppVirutalPath();

            return string.Format(ObjectUtil.SysCulture, Html.MultipleEasySearch,
                multiItems, textBuilder.CreateAttribute(), ERROR_LABEL,
                StringUtil.EscapeHtmlAttribute(easyUrl), StringUtil.EscapeHtmlAttribute(dialogUrl));
        }


        private static string EasySearchEnd(Tk5FieldInfoEx field, DataRow row)
        {
            string name = GetSearchEndName(field);

            return InternalEasySearch(field, name, row, true);
        }

        public static string EasySearch(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            return InternalEasySearch(field, field.NickName, row, needId);
        }

        public static string MultipleEasySearch(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            return InternalMultiEasySearch(field, field.NickName, row, needId);
        }

        private static string DateEnd(Tk5FieldInfoEx field, DataRow row)
        {
            string name = GetSearchEndName(field);
            string value = row.GetDateTime(name, "yyyy-MM-dd");
            return DateControl(field, "calendar", name, value, "yyyy-mm-dd", 10, true);
        }

        public static string Date(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            string value = row.GetDateTime(field.NickName, "yyyy-MM-dd");
            return DateControl(field, "calendar", field.NickName, value, "yyyy-mm-dd", 10, needId);
        }

        public static string DateTime(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);
            string value = row.GetDateTime(field.NickName, "yyyy-MM-dd hh:mm");
            return DateControl(field, "th", field.NickName, value, "yyyy-mm-dd hh:ii", 16, needId);
        }

        private static string DateTimeEnd(Tk5FieldInfoEx field, DataRow row)
        {
            string name = GetSearchEndName(field);
            string value = row.GetDateTime(name, "yyyy-MM-dd hh:mm");
            return DateControl(field, "th", name, value, "yyyy-mm-dd hh:ii", 16, true);
        }

        public static string Time(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            return DateControl(field, "time", field.NickName, string.Empty, "hh:ii", 5, needId);
        }

        public static string Detail(this Tk5FieldInfoEx field, DataRow row, bool showHint, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            AddNormalAttribute(field, builder, field.NickName, needId, true);
            builder.Add("data-value", row.GetString(field.NickName));
            HtmlAttribute classAttr = builder["class"];
            if (classAttr == null)
                builder.Add("class", "detail-content");
            else
                classAttr.Value = HtmlUtil.MergeClass(classAttr.Value, "detail-content");
            return string.Format(ObjectUtil.SysCulture, "<div {0}>{1}</div>",
                builder.CreateAttribute(), DisplayValue(field, row, showHint));
        }

        public static string DisplayUpload(this Tk5FieldInfoEx field, DataRow row)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            Tk5UploadConfig upload = field.AssertUpload();
            IUploadProcessor processor = upload.CreateUploadProcessor();
            return processor.Display(upload, row);
        }

        public static string DisplayValue(this Tk5FieldInfoEx field, DataRow row)
        {
            return DisplayValue(field, row, false);
        }

        public static string Switcher(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            HtmlAttributeBuilder builder = InternalCheckBox(field, row, needId);
            return string.Format(ObjectUtil.SysCulture, Html.Switcher, builder.CreateAttribute());
        }

        public static string Upload(this Tk5FieldInfoEx field, DataRow row, bool needId)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            var upload = field.AssertUpload();

            HtmlAttributeBuilder builder = new HtmlAttributeBuilder();
            builder.Add("data-control", "Upload");
            builder.Add("data-fileSize", upload.SizeField);
            builder.Add("data-serverPath", upload.ServerPathField);
            builder.Add("data-contentType", upload.MimeTypeField);
            AddNormalAttribute(field, builder, field.NickName, needId, true);

            IUploadProcessor processor = upload.CreateUploadProcessor();
            UploadInfo info = row == null ? null : processor.CreateValue(upload, row);
            if (info != null)
                builder.Add("data-value", info.ToJson());

            return string.Format(ObjectUtil.SysCulture, Html.Upload, builder.CreateAttribute(),
                ERROR_LABEL);
        }

        private static string DisplayValue(Tk5FieldInfoEx field, DataRow row, bool showHint)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            if (field.Upload != null)
                return DisplayUpload(field, row);

            string displayValue = string.Empty;
            string value = string.Empty;
            try
            {
                value = row[field.NickName].ToString();
                if (field.Decoder == null || field.Decoder.Type == DecoderType.None)
                    displayValue = FormatNumber(field, field.NickName, row);
                else
                {
                    ControlType ctrlType = field.InternalControl.SrcControl;
                    string rowValue = row[field.NickName + "_Name"].ToString();
                    if (ctrlType == ControlType.CheckBoxList || ctrlType == ControlType.MultipleEasySearch)
                    {
                        MultipleDecoderData data = MultipleDecoderData.ReadFromString(rowValue);
                        displayValue = string.Join(", ", data);
                    }
                    else
                        displayValue = rowValue;
                }
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
                        linkUrl = HtmlUtil.ParseLinkUrl(row, link.Content);
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


        public static string SearchControlEnd(this Tk5FieldInfoEx field, DataRow dataRow, DataSet dataSet)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            ControlType ctrlType = field.InternalControl.SrcControl;
            string result = string.Empty;

            switch (ctrlType)
            {
                case ControlType.Combo:
                    result = ComboEnd(field, dataRow, dataSet);
                    break;
                case ControlType.Text:
                    result = InputEnd(field, dataRow);
                    break;
                case ControlType.Date:
                    result = DateEnd(field, dataRow);
                    break;
                case ControlType.DateTime:
                    result = DateTimeEnd(field, dataRow);
                    break;
                case ControlType.Time:
                    result = field.Time(dataRow, true);
                    break;
                case ControlType.EasySearch:
                    result = EasySearchEnd(field, dataRow);
                    break;
                case ControlType.TextArea:
                case ControlType.CheckBox:
                case ControlType.RadioGroup:
                case ControlType.Password:
                case ControlType.Label:
                case ControlType.RichText:
                case ControlType.Upload:
                case ControlType.MultipleEasySearch:
                case ControlType.CheckBoxList:
                    result = string.Format(ObjectUtil.SysCulture, "{0}的控件类型为{1}，不支持区间查询",
                        field.NickName, ctrlType);
                    break;
            }
            return result;
        }

        public static string SearchControl(this Tk5FieldInfoEx field, DataRow dataRow, DataSet dataSet)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            ControlType ctrlType = field.InternalControl.SrcControl;
            string result = string.Empty;

            switch (ctrlType)
            {
                case ControlType.Combo:
                case ControlType.RadioGroup:
                    result = field.Combo(dataRow, dataSet, true);
                    break;
                case ControlType.Text:
                case ControlType.TextArea:
                    result = field.Input(dataRow, true);
                    break;
                case ControlType.CheckBox:
                    result = field.CheckBox(dataRow, true);
                    break;
                case ControlType.Date:
                    result = field.Date(dataRow, true);
                    break;
                case ControlType.DateTime:
                    result = field.DateTime(dataRow, true);
                    break;
                case ControlType.Time:
                    result = field.Time(dataRow, true);
                    break;
                case ControlType.EasySearch:
                    result = field.EasySearch(dataRow, true);
                    break;
                case ControlType.Label:
                case ControlType.Password:
                case ControlType.RichText:
                case ControlType.Upload:
                case ControlType.CheckBoxList:
                    result = string.Format(ObjectUtil.SysCulture, "{0}的控件类型为{1}，不支持查询",
                       field.NickName, ctrlType);
                    break;
            }
            return result;
        }

        public static string Control(this Tk5FieldInfoEx field, DataRow dataRow, DataSet dataSet, bool needId = true)
        {
            TkDebug.AssertArgumentNull(field, "field", null);

            ControlType ctrlType = field.InternalControl.SrcControl;
            string result = string.Empty;

            switch (ctrlType)
            {
                case ControlType.TextArea:
                    result = field.Textarea(dataRow, needId);
                    break;
                case ControlType.Combo:
                    result = field.Combo(dataRow, dataSet, needId);
                    break;
                case ControlType.RadioGroup:
                    result = field.RadioGroup(dataRow, dataSet, needId);
                    break;
                case ControlType.CheckBoxList:
                    result = field.CheckBoxList(dataRow, dataSet, needId);
                    break;
                case ControlType.Text:
                case ControlType.Password:
                    result = field.Input(dataRow, needId);
                    break;
                case ControlType.CheckBox:
                    result = field.Switcher(dataRow, needId);
                    break;
                case ControlType.Date:
                    result = field.Date(dataRow, needId);
                    break;
                case ControlType.DateTime:
                    result = field.DateTime(dataRow, needId);
                    break;
                case ControlType.Time:
                    result = field.Time(dataRow, needId);
                    break;
                case ControlType.EasySearch:
                    result = field.EasySearch(dataRow, needId);
                    break;
                case ControlType.MultipleEasySearch:
                    result = field.MultipleEasySearch(dataRow, needId);
                    break;
                case ControlType.Label:
                    result = field.Detail(dataRow, true, needId);
                    break;
                case ControlType.RichText:
                    result = field.RichText(dataRow, needId);
                    break;
                case ControlType.Upload:
                    result = field.Upload(dataRow, needId);
                    break;
            }
            return result;
        }
    }
}
