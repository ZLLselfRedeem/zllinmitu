// --------------------------------
// Toolkit.list
// --------------------------------
(function ($) {
    if (!$ || !window.Toolkit) return;
    // ----------------------------
    Toolkit.namespace('Toolkit.list');

    Toolkit.list.getQueryJson = function (frm) {
        var postObj = frm.attr("data-post");
        if (!postObj)
            return undefined;

        var fields = postObj.parseJSON().Fields;
        var postData = { "Condition": {}, "IsEqual": false };
        for (var i = 0; i < fields.length; i++) {
            var field = fields[i];
            var elm = Toolkit.data.getElement(frm, field);
            var fieldValue = Toolkit.data.getElementValue(elm, field.Type);
            if (fieldValue !== "")
                postData.Condition[field.Name] = fieldValue;
        }

        return postData;
    };

    _queryResult = function (req) {
        $("#listData").replaceWith(req);
        $("#WebListXmlPage").trigger("PageInit");
    };

    Toolkit.list.query = function (frmId) {
        var currentObj = $(this);
        var frm = Toolkit.data._getForm(frmId, currentObj, "QueryForm");
        if (!frm)
            return;
        var listView = $("#pageList");
        if (listView.length === 0)
            return;

        var postData = Toolkit.list.getQueryJson(frm);
        var url = listView.attr("data-url");
        //var path = url.getPathName();
        //var param = url.getQueryJson();
        //var data = {
        //    "Page": listView.attr("data-page"), "GetData": "Page", "Tab": listView.attr("data-tab")
        //};
        //$.extend(param, data);
        //url = path + "?" + $.param(param);
        var response = currentObj.attr("data-response");
        var func = response ? window[response] : _queryResult;
        if (func)
            if (postData) {
                //alert(Toolkit.json.stringify(postData));
                $.ajax({
                    type: 'post', dataType: 'text', url: url, data: Toolkit.json.stringify(postData),
                    success: func,
                    error: function () {
                        Toolkit.page.showError('数据提交失败！请稍候重试。');
                    }
                });
            }
        return false;

    };

    Toolkit.list.selectTab = function () {
        var tab = $("#tabSheets");
        if (tab.length === 0)
            return;

        var obj = $(this);
        tab.find("li").attr("class", "");
        obj.closest("li").attr("class", "active");
        var tabId = obj.attr("data-tab");
        $("#pageList").attr("data-tab", tabId);
        Toolkit.list.loadPage({ "Tab": tabId, "Page": 0 });
    };

    Toolkit.list.loadPageByPage = function (page) {
        Toolkit.list.loadPage({ "Page": page });
    };

    Toolkit.list.loadPage = function (options) {
        var listView = $("#pageList");
        if (listView.length === 0)
            return;

        var url = listView.attr("data-url");
        var path = url.getPathName();
        var param = url.getQueryJson();
        var condition = listView.attr("data-condition");
        var data = {
            "Page": listView.attr("data-page"), "GetData": "Page", "Condition": condition,
            "Tab": listView.attr("data-tab"), "TotalCount": listView.attr("data-totalcount"), 
            "TotalPage": listView.attr("data-totalpage")
        };
        $.extend(param, data);
        $.extend(param, options);
        $.ajax({
            type: 'get', dataType: 'text', url: path, data: param,
            success: _queryResult,
            error: function () {
                Toolkit.page.showError('数据提交失败！请稍候重试。');
            }
        });
    };

    Toolkit.list.initSearch = function (elm) {
        $("a.btn-search").click(Toolkit.list.query).attr("href", "javascript:void(0);");
        $("select.auto-search").change(Toolkit.list.query);
        $("a[data-tab]").click(Toolkit.list.selectTab).attr("href", "javascript:void(0);");
        $("#QueryForm").bind("submit", function () { return false; });
    };

    Toolkit.list.initPage = function (elm) {
        $("a[data-page]").click(function () {
            Toolkit.list.loadPageByPage(parseInt($(this).attr("data-page")) - 1);
        }).attr("href", "javascript:void(0);");
    };

    $(document).ready(function () {
        $("#WebListXmlPage").bind("SearchInit", Toolkit.list.initSearch).bind("PageInit", Toolkit.list.initPage);
        $("#WebListXmlPage").trigger("SearchInit").trigger("PageInit");
    });
})(jQuery);