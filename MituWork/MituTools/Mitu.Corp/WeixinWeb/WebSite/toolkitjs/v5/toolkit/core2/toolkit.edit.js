// --------------------------------
// Toolkit.list
// --------------------------------
(function ($) {
    if (!$ || !window.Toolkit) return;
    // ----------------------------
    Toolkit.namespace('Toolkit.edit');

    Toolkit.edit.initPage = function (elm) {
        $("a.btn-submit").click(Toolkit.data.post).attr("href", "javascript:void(0);");
    };

    $(document).ready(function () {
        $("#WebInsertXmlPage").bind("PageInit", Toolkit.edit.initPage).trigger("PageInit");
    });
})(jQuery);