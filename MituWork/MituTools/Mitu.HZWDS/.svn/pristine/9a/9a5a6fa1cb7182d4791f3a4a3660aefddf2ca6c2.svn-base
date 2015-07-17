// --------------------------------
// Toolkit.list
// --------------------------------
(function ($) {
    if (!$ || !window.Toolkit) return;
    // ----------------------------
    Toolkit.namespace('Toolkit.ui');
    Toolkit.ui.PageContentExecute = function (elm) {
        if (elm.tagName() == 'body' || elm.hasClass('tk-dataPage')) {
            // iframe/ajax加载页面时处理
            elm.find('.tk-datasearch').bindToolkitUI('DataSearchExecute');
            elm.find('.tk-datatab').bindToolkitUI('DataTabExecute');
            elm.find('.tk-datadetail').bindToolkitUI('DataDetailExecute');
            elm.find('.tk-datalist').bindToolkitUI('DataListLoad').bindToolkitUI('DataListExecute');
            elm.find('.tk-dataform').bindToolkitUI('DataFormExecute');
        } else if (elm.hasClass('ui-list-sction')) {
            // 预留加载section时处理
        } else if (elm.hasClass('ui-list-frame')) {
            // 只加载数据列表时处理
            elm.bindToolkitUI('DataTableExecute');
        }
        elm.bindToolkitUI('LoadDataSection');
        elm.bindToolkitUI('dataLinkExecute');
    };
    // Insert/Update页的表单处理
    Toolkit.ui.DataFormExecute = function (elm) {
        // 折叠/展开处理
        //elm.find('.mod-header').bindToolkitUI('DataHeaderCollapse', 'form');
        elm.bindToolkitUI('DataFormDetailExecute');
        elm.bindToolkitUI('DataFormListExecute');
        //Toolkit.ui.UpdateDataFormHeight();
        //
        //elm.find('form').bindToolkitData('LoadDataSet');
        // 提交搜索
        //elm.find('.btn-submit').click(function () {
        //    var url = $(this).attr('href') || '#';
        //    if (url == "#" || url == "##" || url == "###") url = null;
        //    $(this).parents('form').bindToolkitData('UpdateSubmit', url);
        //    return false;
        //});
    };
    Toolkit.ui.DataFormListExecute = function (elm) {
        elm.bindToolkitUI('dataFormListActionExecute');
    };
    Toolkit.ui.DataSearchExecute = function (elm) {
        elm.bindToolkitUI('DataFormElementExecute', 'detail');
    };
    Toolkit.ui.DataFormDetailExecute = function (elm) {
        // 避免list-table下的隐藏模板里的tk-datatable被解析
        elm.find('.tk-datatable').each(function () {
            //if ($(this).parent().tagName() == 'td') return;
            $(this).bindToolkitUI('DataDetailElementExecute');
            $(this).bindToolkitUI('DataFormElementExecute', 'detail');
        });
    };
    Toolkit.ui.DataDetailElementExecute = function (elm) {
        elm.find('[dataControl=DetailHTML]').each(
            function (index, element) {
                $(element).bindToolkitUI('HtmlEditor');
            });
    };
    Toolkit.ui.DataFormElementExecute = function (elm, type) {
        // 基本的UI处理
        //elm.find('[dataControl=Date], [dataControl=DateTime]').bindToolkitUI('DatePicker');
        elm.find('[data-control=EasySearch]').each(
            function (index, element) {
                $(element).bindToolkitUI('easySearchControl');
            });
        elm.find('[data-control=HTML]').each(
            function (index, element) {
                $(element).bindToolkitUI('htmlEditor');
            });
        elm.find('[data-control=Date]').each(
            function (index, element) {
                $(element).bindToolkitUI('dateControl');
            });
        elm.find('[data-control=DateTime]').each(
            function (index, element) {
                $(element).bindToolkitUI('dateTimeControl');
            });
        elm.find('[data-control=Time]').each(
            function (index, element) {
                $(element).bindToolkitUI('timeControl');
            });
        elm.find('[data-control=Upload]').each(
            function (index, element) {
                $(element).bindToolkitUI('uploadControl');
            });
        elm.find('[data-control=CheckBox]').each(
            function (index, element) {
                $(element).bindToolkitUI('checkBoxControl');
            });
        //elm.find('[dataControl=MultiEasySearch]').bindToolkitUI('MultiEasySearch');

        // 基本的Data处理
        //elm.find('input[dataHint],textarea[dataHint]').bindToolkitData('InputHint');
        //elm.find('input[dataLimitType],textarea[dataLimitType]').bindToolkitData('InputLimit');
        //elm.find('input[dataValidType],textarea[dataValidType],input[dataRequired],textarea[dataRequired],select[dataRequired]').bindToolkitData('InputValid');
        // KeyBoard相关处理
        //var type = type || '';
        //if (type == 'detail') {
        //    elm.find('.tk-control input[type=text], .tk-control input[type=password], .tk-control textarea').bindToolkitUI('KeyBoardExecute', 'dl');
        //} else if (type == 'list') {
        //    elm.find('.tk-control input[type=text], .tk-control input[type=password], .tk-control textarea').bindToolkitUI('KeyBoardExecute', 'table');
        //    // 添加折叠和展开
        //    elm.find('.tk-datatable').bindToolkitUI('AddRowFormCollapse');
        //}
    };
    Toolkit.ui.dataFormListActionExecute = function (elm) {
        // 选中状态修改
        elm.find('tbody.list input.row-index').bindToolkitUI('_addDataRowCheck');
        // 全选处理
        elm.find('thead input.e-checkall').click(function () {
            $(this).parents('table').find('tbody.list input.row-index').bindToolkitUI('_checkAll', this);
        });
        // 选择按钮处理
        elm.find('Button.ui-btn-checkall').click(function () {
            elm.find('thead input.e-checkall').prop('checked', true);
            elm.find('tbody.list input.row-index').bindToolkitUI('_checkAll', true);
            return false;
        });
        elm.find('Button.ui-btn-checknone').click(function () {
            elm.find('thead input.e-checkall').prop('checked', false);
            elm.find('tbody.list input.row-index').bindToolkitUI('_checkAll', false);
            return false;
        });
        elm.find('Button.ui-btn-checkreverse').click(function () {
            elm.find('tbody.list input.row-index').bindToolkitUI('_checkReverse');
            return false;
        });
        // 删除处理
        elm.find('.ui-btn-delrow').click(function () {
            var rowlist = elm.find('tbody.list input.row-index:checked');
            if (rowlist.length === 0) {
                Toolkit.page.alert('请选择要删除的数据行');
                return false;
            }
            var element = $(this);
            Toolkit.page.confirm('确认删除所选择的数据行？', function () {
                Toolkit.stat.addFuncStat('Toolit.ui.DeleteDataRow-' + rowlist.length);
                var table = element.parents('.panel').find('table');
                if (rowlist.length === table.find('tbody.list tr').size()) {
                    table.find('tbody.list>tr').remove();
                    //table.bindToolkitData('DeleteAllDataSetRow');
                } else {
                    for (var i = rowlist.length - 1; i >= 0; i--) {
                        var selector = 'tbody.list>tr:eq(' + ($(rowlist[i]).val() - 1) + ')';
                        table.find(selector).remove();
                    }
                    table.find('tbody.list>tr').each(function (i) {
                        $(this).find('input.row-index').val(i + 1);
                        $(this).find('span.row-index').html(i + 1);
                    });
                    //table.bindToolkitData('DeleteDataSetRow', rowlist);
                }
                //Toolkit.ui.UpdateDataFormHeight();
                Toolkit.stat.addFuncStat('Toolit.ui.DeleteDataRow-' + rowlist.length);
            });
            return false;
        });
        elm.find('.ui-btn-delall').click(function () {
            var element = $(this);
            Toolkit.page.confirm('确认删除全部数据行？', function () {
                var table = element.parents('.panel').find('table');
                table.find('tbody.list tr').remove();
                //table.bindToolkitData('DeleteAllDataSetRow');
                //Toolkit.ui.UpdateDataFormHeight();
            });
            return false;
        });
        // 新建列表
        elm.find('.ui-newrow input[type=text]').keydown(function (e) {
            try {
                var code = e.which || e.keyCode || 0;
                if (code === 13) {
                    $(this).blur();
                    $(this).next().click();
                }
            } catch (err) { }
        });
        elm.find('.ui-newrow button.btn').click(function () {
            var element = $(this);
            var txtrow = element.prev();
            var count = txtrow.val();
            if (count === '' || !Toolkit.string.isPositiveInteger(count)) {
                Toolkit.page.alert('请输入要新建的行数', function () {
                    txtrow.focus();
                });
                return false;
            }
            if (count > 100) {
                Toolkit.page.alert('一次最多只能新建100行，请修改行数', function () {
                    txtrow.focus();
                });
                return false;
            }
            //if (count > 10) Toolkit.page.showLoading('正在创建数据行……');
            setTimeout(function () {
                element.parents('.panel').find('table').bindToolkitUI('_createDataRow', count);
                //if (count > 10) Toolkit.page.hideLoading();
            }, 100);
            return false;
        });
    };

    Toolkit.ui._createDataRow = function (elm, count) {
        Toolkit.stat.addFuncStat('Toolit.ui.CreateDataRow-' + count);
        //elm.find('tbody.list .tk-datatable').trigger('collapseRowForm');
        var row = elm.find('tbody.template>tr');
        var rowCount = elm.find('tbody.list>tr').size();
        for (var i = 0; i < count; i++) {
            var newrow = row.clone();
            newrow.addClass("table-row");
            elm.find('tbody.list').append(newrow);
        }
        var rows = (rowCount > 0) ? elm.find('tbody.list>tr:gt(' + (rowCount - 1) + ')') : elm.find('tbody.list>tr');
        rows.each(function (i) {
            $(this).find('input.row-index').val(rowCount + i + 1);
            $(this).find('span.row-index').html(rowCount + i + 1);
            //$(this).bindToolkitData('InsertDataSetRow');
        });
        rows.find('input.row-index').bindToolkitUI('_addDataRowCheck');
        rows.bindToolkitUI('DataDetailElementExecute');
        rows.bindToolkitUI('DataFormElementExecute', 'list');
        //rows.bindToolkitUI('UpdateFormRadioGroup');
        //Toolkit.ui.UpdateDataFormHeight();
        Toolkit.stat.addFuncStat('Toolit.ui.CreateDataRow-' + count);
    };
    Toolkit.ui._addDataRowCheck = function (elm) {
        elm.click(function () {
            $(this).bindToolkitUI('_checkDataRow');
        });
    };
    // ----------------------------
    // 全选
    Toolkit.ui._checkAll = function (elm, chkSource) {
        var checked = true;
        if (typeof (chkSource) == 'object') {
            checked = chkSource.checked;
        } else if (typeof (chkSource) == 'boolean') {
            checked = chkSource;
        }
        elm.each(function () {
            this.checked = checked;
            Toolkit.ui._checkDataRow($(this));
        });
    };
    // 反选
    Toolkit.ui._checkReverse = function (elm) {
        elm.each(function () {
            this.checked = !this.checked;
            Toolkit.ui._checkDataRow($(this));
        });
    };
    // 选中或取消选中当前行
    Toolkit.ui._checkDataRow = function (elm) {
        if (!elm.hasClass("e-checkdatarow")) return;
        if (elm.prop("checked")) {
            elm.parents("tr").addClass("active");
        } else {
            elm.parents("tr").removeClass("active");
        }
    };
    Toolkit.ui._locationUrl = function (url, isRetUrl) {
        if (isRetUrl) {
            document.location.href = url;
            return;
        }
        var retUrl = $("body").triggerHandler("SelfUrl");
        if (retUrl === undefined || retUrl === "")
            document.location.href = url;
        else {
            var uri = new URI(url);
            var params = uri.search(true);
            params.RetURL = retUrl;
            uri.search(params);
            document.location.href = uri.toString();
        }
    };

    Toolkit.ui._ajaxUrl = function (url) {
        $.ajax({
            type: 'get', dataType: 'text', url: url,
            success: _successCommit,
            error: function () {
                Toolkit.page.showError('数据提交失败！请稍候重试。');
            }
        });
    }

    Toolkit.ui.dataLinkExecute = function (elm) {
        elm.find("button[data-url],a[data-url]").click(function () {
            var obj = $(this);
            var url = obj.attr("data-url");
            var useRetUrl = obj.attr("data-action") === "return";
            if (url === undefined || url === "" || url === "#")
                return;
            var confirm = obj.attr("data-confirm");
            if (confirm === undefined || confirm === "")
                Toolkit.ui._locationUrl(url, useRetUrl);
            else
                Toolkit.page.confirm(confirm, function () { Toolkit.ui._locationUrl(url, useRetUrl); });
        });
        elm.find("button[data-ajax-url],a[data-ajax-url]").click(function () {
            var obj = $(this);
            var url = obj.attr("data-ajax-url");
            if (url === undefined || url === "" || url === "#")
                return;
            var confirm = obj.attr("data-confirm");
            if (confirm === undefined || confirm === "")
                Toolkit.ui._ajaxUrl(url);
            else
                Toolkit.page.confirm(confirm, function () { Toolkit.ui._ajaxUrl(url); });
        });
        elm.find("button[data-dialog-url],a[data-dialog-url]").click(function () {
            var obj = $(this);
            var url = obj.attr("data-dialog-url");
            if (url === undefined || url === "")
                return;
            var title = obj.attr("data-title");
            var height = $("body").attr("data-dialog-height");
            if (height == 0)
                height = 400;
            var options = { "title": title, "url": url, "height": height };
            $.extend(options, obj.attrJSON('data-dialog-param'));
            Toolkit.page.dialog.pop(options);
        });
        elm.find("button[data-dialog-page],a[data-dialog-page]").click(function () {
            var obj = $(this);
            var url = obj.attr("data-dialog-page");
            if (url === undefined || url === "")
                return;
        });
        elm.find("button[data-dialog-action=close]").click(function () {
            Toolkit.page.closeDialog();
        });
    };
    // 绑定EasySearch处理
    Toolkit.ui.easySearchControl = function (elm) {
        Toolkit.load('easysearch', function () {
            elm.each(function () {
                var element = $(this);
                var inputElement = element.find('input[type=text]');
                //var fieldStr = element.attr('dataRefField') || '';
                var refFields = null;
                //if (fieldStr != '') {
                //    var fields = fieldStr.split(';');
                //    refFields = {};
                //    for (var i = 0; i < fields.length; i++) {
                //        if (fields[i].indexOf(',') < 1) continue;
                //        var field_name = fields[i].split(',')[0];
                //        var element_name = fields[i].split(',')[1];
                //        var refElement = Toolkit.data.getRefElement(element, element_name);
                //        refElement.bind('change', function () {
                //            inputElement.bindToolkitUI('EasySearchEmpty');
                //        });
                //        refFields[field_name] = refElement;
                //    }
                //}
                inputElement.bindToolkitUI('suggest', {
                    source: element.attr('data-url'),
                    refFields: refFields,
                    onBeforeSuggest: function () {
                        inputElement.trigger('beforeEasySearch');
                    },
                    onSelect: function (input, id, text) {
                        input.bindToolkitUI('easySearchChecked', { id: id, text: text });
                    }
                });
                inputElement.bindToolkitUI('easySearchChecked');
                element.find('button.btn').click(function () {
                    inputElement.trigger('beforeEasySearch');
                    var hiddenElement = element.find("input[type=hidden]");
                    inputElement.bindToolkitUI('easySearchDialog', {
                        url: element.attr("data-dialog-url"),
                        initValue: hiddenElement.val() || '',
                        title: inputElement.attr("data-title"),
                        refFields: refFields
                    });
                });
            });
        });
    };
    Toolkit.ui.EasySearchEmpty = function (input) {
        var hdinput = input.siblings('[name=hd' + input.attr('name') + ']');
        input.siblings('.checked').remove();
        hdinput.val('').trigger('change');
        input.val('').show();
    };
    // EasySearch选中后赋值
    Toolkit.ui.easySearchChecked = function (input, data) {
        var hdinput = input.siblings('[name=hd' + input.attr('name') + ']');
        if (data) {
            hdinput.val(data.id).trigger('change');
            input.val(data.text).blur();
            input.showInputValidStatus();
        }
        if (input.val() === '') return;
        input.hide();
        input.before('<span class="easysearch-checked rad3">' + input.val()
            + ' <button type="button" title="删除" class="close easysearch-close" aria-hidden="true">&times;</button></span>');
        input.siblings('.easysearch-checked').find('button').click(function () {
            $(this).parent().remove();
            hdinput.val('').trigger('change');
            input.val('').show();
        });
        input.trigger('AfterItemSelected', data);
    };
    // 打开EasySearch弹窗
    Toolkit.ui.easySearchDialog = function (input, data) {
        Toolkit.page.currentEasySearchElement = input;
        //var url = data.source.substitute(data);
        var url = Toolkit.page.addQueryString(data.url, { "InitValue": data.initValue });
        Toolkit.page.dialog.pop({ "title": "选择" + data.title + "...", "url": url });
        //if (data.refFields) {
        //    var refdata = {};
        //    refdata['REF'] = [];
        //    for (var item in data.refFields) {
        //        var itemValue = Toolkit.data.getElementValue(data.refFields[item]);
        //        refdata['REF'].push({ Field: item, RefValue: itemValue });
        //    }
        //    url += '&RefValue=' + encodeURIComponent(Toolkit.json.stringify(refdata)) + '&Format=Json';
        //}
    };
    Toolkit.ui.easySearchDialogTreeClick = function (node, selected) {
        if (selected.node) {
            var id = selected.node.id;
            var text = selected.node.text;
            parent.Toolkit.ui.setEasySearchData({ id: id, text: text });
            Toolkit.page.closeDialog();
        }
    };
    // 弹窗中返回EasySearch所选数据
    Toolkit.ui.setEasySearchData = function (data) {
        var input = Toolkit.page.currentEasySearchElement;
        var controlType = input.parents('div[data-control]').attr('data-control');
        if (controlType == 'MultiEasySearch') {
            input.bindToolkitUI('MultiEasySearchChecked', data);
        } else {
            input.siblings('span.easysearch-checked').remove();
            input.bindToolkitUI('easySearchChecked', data);
        }
    };
    // ----------------------------
    // 绑定日期控件
    Toolkit.ui.dateControl = function (elm) {
        Toolkit.load('datetimepicker', function () {
            elm.each(function () {
                var element = $(this);
                element.datetimepicker({
                    language: 'zh-CN',
                    autoclose: true,
                    todayHighlight: true,
                    todayBtn: true,
                    minView: 2,
                });
            });
        });
    };
    Toolkit.ui.dateTimeControl = function (elm) {
        Toolkit.load('datetimepicker', function () {
            elm.each(function () {
                var element = $(this);
                element.datetimepicker({
                    language: 'zh-CN',
                    todayBtn: true,
                    autoclose: true,
                    todayHighlight: true,
                    showMeridian: true
                });
            });
        });
    };
    Toolkit.ui.timeControl = function (elm) {
        Toolkit.load('datetimepicker', function () {
            elm.each(function () {
                var element = $(this);
                element.datetimepicker({
                    language: 'zh-CN',
                    todayBtn: true,
                    autoclose: true,
                    todayHighlight: true,
                    startView: 1,
                    minView: 0,
                    maxView: 1,
                    forceParse: false
                });
            });
        });
    };
    Toolkit.ui.checkBoxControl = function (elm) {
        if (elm.hasClass("switch")) {
            //var options = { "onText": elm.attr("data-on-label"), "offText": elm.attr("data-off-label") };
            Toolkit.load('switcher', function () {
                elm.find(":checkbox").bootstrapSwitch();
            });
        }
    };

    // ----------------------------
    // 绑定HTML编辑器
    // 上传HtmlUpload页面的参数说明：MaxSize：上传文件的最大长度；RelativePath：返回相对路径(true/false)
    //    UploadPath：上传文件的存储目录；VirtualPath：上传文件的虚拟目录
    Toolkit.ui.htmlEditor = function (elm) {
        Toolkit.load('kindeditor', function () {
            elm.each(function (i) {
                var textarea = $(this);
                var uploadPath = textarea.attr('data-uploadPath');
                if (uploadPath === undefined)
                    uploadPath = Toolkit.page.getAbsoluteUrl("Library/WebInitPage.tkx?Source=HtmlUpload");
                var params = { "RelativePath": false, "VirtualPath": "" };
                var useRelative = textarea.attr("data-useRelative");
                if (useRelative === "true")
                    params.RelativePath = true;
                params.VirtualPath = textarea.attr("data-virtualPath");
                uploadPath = Toolkit.page.addQueryString(uploadPath, params);

                var baseOptions = { "uploadJson": uploadPath, "readonlyMode": false, "formatUploadUrl": false };
                var isReadOnly = textarea.attr('data-control') == 'DetailHTML';
                if (isReadOnly)
                    baseOptions.readonlyMode = true;
                var editor = KindEditor.create('textarea[name="' + textarea.attr("name") + '"]', baseOptions);
                textarea.data("editor", editor);
            });
        });
    };

    // ----------------------------
    // 绑定Upload控件

    Toolkit.ui._previewImg = function (source, div) {
        var img = $("<img></img>");
        img.attr("src", source);
        div.empty().append(img);
    };

    Toolkit.ui._deleteUploaded = function () {
        var obj = $(this);
        var elm = obj.parents("div[data-control=Upload]");
        elm.data("upload", undefined);
        elm.find(".upload-status").hide();
        elm.find(".upload-info").html("");
        var input = elm.find(":file");
        input.show();
        input.replaceWith(input.val('').clone(true));
    };

    Toolkit.ui._successUploaded = function (data, elm, file, info) {
        if (data && data.Result) {
            var result = data.Result.Result;
            if (result === "Success") {
                var upload = data.UploadInfo;
                elm.data("upload", upload);
                Toolkit.ui._showUploadItem(upload, file, info);
            }
            else if (result === "Error") {
                Toolkit.page.showError(data.Result.Message);
            }
        }
        else {
            Toolkit.page.showError('上传失败，请稍后重试。');
        }
    };

    Toolkit.ui._showUploadItem = function (upload, file, info) {
        file.hide();
        info.html('<span>' + upload.FileName + '<button type="button" class="close easysearch-close" aria-hidden="true">&times;</button></span>');
        info.find("button.close").click(Toolkit.ui._deleteUploaded);
    };

    Toolkit.ui._onFileChange = function () {
        var fileInput = $(this);
        var parent = fileInput.parent("[data-control=Upload]");
        var response = fileInput.siblings(".upload-status").show();
        var responseInfo = response.find("div.upload-info").html('<p><i class="icon-spinner icon-spin mr5 ml5"></i>正在上传……</p>');

        var formdata = false;
        if (window.FormData) {
            formdata = new FormData();
        }

        var len = this.files.length;
        for (var i = 0; i < len; i++) {
            var file = this.files[i];

            if (window.FileReader) {
                var reader = new FileReader();
                reader.onloadend = function (e) {
                    //if (ctrl.attr("data-view") == "true")
                    //    Toolkit.ui._showUploadedItem(e.target.result, resDiv.find("div.responseImage"));
                };
                reader.readAsDataURL(file);
            }
            if (formdata) {
                formdata.append("Filedata", file);
            }
        }

        if (formdata) {
            var url = parent.attr("data-url");
            if (url === undefined || url === "") {
                url = Toolkit.page.getAbsoluteUrl("Library/WebInitPage.tkx?Source=WebUpload");
            }
            $.ajax({
                url: url,
                type: "Post",
                data: formdata,
                processData: false,
                contentType: false,
                success: function (res) {
                    Toolkit.ui._successUploaded(res, parent, fileInput, responseInfo);
                },
                error: function (res) {
                    Toolkit.page.showError('上传失败，请稍后重试。');
                }
            });
        }
    };

    Toolkit.ui.uploadControl = function (elm) {
        var input = elm.find(":file");
        var value = elm.attr("data-value");
        var response = elm.find(".upload-status")
        if (value === undefined) {
            response.hide();
            elm.data("upload", undefined);
        }
        else {
            response.show();
            var upload = value.parseJSON();
            elm.data("upload", upload);
            Toolkit.ui._showUploadItem(upload, input, response.find("div.upload-info"));
        }
        if (!window.FormData) {
            alert("系统不支持HTML5上传");
            input.attr("disabled", "disabled");
        }
        input.change(Toolkit.ui._onFileChange);
    };
})(jQuery);