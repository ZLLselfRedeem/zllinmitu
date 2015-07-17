function checkAll() {
    var panel = $(this).parents("div.panel");
    var checkboxes = panel.find(":checkbox");
    //checkboxes.attr("checked", "checked");
    checkboxes.prop("checked", true);
}

function antiCheck() {
    var panel = $(this).parents("div.panel");
    var checkboxes = panel.find(":checkbox");
    checkboxes.each(function () {
        var obj = $(this);
        var value = obj.prop("checked");
        obj.prop("checked", !value);
    });
}

function uncheckAll() {
    var panel = $(this).parents("div.panel");
    var checkboxes = panel.find(":checkbox");
    checkboxes.prop("checked", false);
    //checkboxes.removeAttr("checked");
}

function save() {
    var data = [];
    var partId = $("#PartId").val();
    var root = $("div.root");
    root.each(function (index) {
        var self = $(this);
        var boxes = self.find(":checked");
        if (boxes.length > 0) {
            var item = { "PartId": partId, "FnId": self.attr("data-id") };
            data.push(item);
            boxes.each(function () {
                var child = { "PartId": partId, "FnId": $(this).val() };
                data.push(child);
            });
        }
    });
    var postData = { "SYS_PART_FUNC": data };
    var url = document.location.href;
    $.ajax({
        type: 'post', dataType: 'text', url: url, data: Toolkit.json.stringify(postData),
        success: _successCommit,
        error: function () {
            Toolkit.page.showError('数据提交失败！请稍候重试。');
        }
    });
}

$(document).ready(function () {
    $("a.checkall").click(checkAll);
    $("a.anticheck").click(antiCheck);
    $("a.uncheckall").click(uncheckAll);
    $("button.btn-save").click(save);
});
