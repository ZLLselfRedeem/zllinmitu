// --------------------------------
// Toolkit.list
// --------------------------------
(function ($) {
    if (!$ || !window.Toolkit) return;
    // ----------------------------
    Toolkit.namespace('Toolkit.mainpage');
    Toolkit.mainpage.menuClick = function () {
        var obj = $(this);
        var url = obj.attr("data-menu");
        $("#tkFrameMain").attr("src", url);
    }

    $(document).ready(function () {
        $("li>a[data-menu]").click(Toolkit.mainpage.menuClick);
    });
})(jQuery);