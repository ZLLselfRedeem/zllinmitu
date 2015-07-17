// --------------------------------
// Toolkit.detail
// --------------------------------
(function ($) {
    if (!$ || !window.Toolkit) return;
    // ----------------------------
    Toolkit.namespace('Toolkit.detail');

    Toolkit.detail._loadData = function (div) {
        var data = div.clone();
        data.find("tbody").attr("id", "pageList");
        $("#listData").empty().append(data.children());
    };

    Toolkit.detail.detailList = function () {
        var elm = $(this);
        var li = elm.parent();
        li.siblings().removeClass("active");
        li.addClass("active");

        var div = $("#" + elm.data("dlist"));
        if (!div.data("loaded")) {
            var index = div.data("index");
            var style;
            if (index === 0)
                style = "CDetailList";
            else
                style = "CDetailList" + index;

            var uri = new URI(window.location.href);
            var queryParams = uri.search(true);
            queryParams = $.extend(queryParams, { "Style": style });
            var loadUrl = Toolkit.page.getAbsoluteUrl("Library/WebModuleContentPage.tkx");
            $.ajax({
                type: 'get', dataType: 'text', url: loadUrl, data: queryParams,
                success: function (req) {
                    div.html(req);
                    div.data("loaded", true);
                    Toolkit.detail._loadData(div);
                },
                error: function () {
                    Toolkit.page.showError('数据提交失败！请稍候重试。');
                }
            });
        }
        else {
        }
    };

    $(document).ready(function () {
        $("body").bind("SelfUrl", Toolkit.data.getSelfUrl);
        var detailList = $("a[data-dlist]");
        detailList.click(Toolkit.detail.detailList).attr("href", "javascript:void(0)");
        detailList.first().click();
        $("#listData").bind("PageInit", Toolkit.list._initPage);
    });
})(jQuery);