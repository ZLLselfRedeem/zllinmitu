﻿function checkAll() {
    var checkboxes = $(":checkbox");
    checkboxes.attr("checked", "checked");
}

function antiCheck() {
    var checkboxes = $(":checkbox");
    checkboxes.each(function () {
        var obj = $(this);
        if (obj.attr("checked"))
            obj.removeAttr("checked");
        else
            obj.attr("checked", "checked");
    });
}

function uncheckAll() {
    var checkboxes = $(":checkbox");
    checkboxes.removeAttr("checked");
}

function save() {
    var data = [];
    var userId = $("#UserId").val();
    var boxes = $(":checked");
    boxes.each(function () {
        var child = { "UserId": userId, "PartId": $(this).val() };
        data.push(child);
    });
    var postData = { "UR_USERS_PART": data };
    var url = document.location.href;
    //alert(Toolkit.json.stringify(postData));
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
