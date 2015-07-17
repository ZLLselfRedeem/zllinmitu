/**
 * 
 * @authors ccHotaru zy qq (1518265554@qq.com)
 * @date    2015-07-17 09:50:25
 * @version $Id$
 */

// from http://blog.csdn.net/kongjiea/article/details/25060857
function outputmoney(number) {
    if (isNaN(number) || number == "") return // number.replace(/[^-1234567890.]/g, '')

    number = Math.round(number * 100) / 100

    if (number < 0) {
        return '-' + outputdollars(Math.floor(Math.abs(number) - 0) + '') + outputcents(Math.abs(number) - 0);
    } else {
        return outputdollars(Math.floor(number - 0) + '') + outputcents(number - 0);
    }
}

//格式化金额   
function outputdollars(number) {
    if (number.length <= 3) {
        return (number == '' ? '0' : number);
    } else {
        var mod = number.length % 3;
        var output = (mod == 0 ? '' : (number.substring(0, mod)));
        for (i = 0; i < Math.floor(number.length / 3); i++) {
            if ((mod == 0) && (i == 0)) {
                output += number.substring(mod + 3 * i, mod + 3 * i + 3);
            } else {
                output += ',' + number.substring(mod + 3 * i, mod + 3 * i + 3);
            }
        }
        return (output);
    }
}

function outputcents(amount) {
    amount = Math.round(((amount) - Math.floor(amount)) * 100);
    return (amount < 10 ? '.0' + amount : '.' + amount);
}

// 使用 outputmoney() 转换格式
$('input[data-formatMoney]').blur(function() {
    var thisVal = $(this).val()
    thisVal = outputmoney(thisVal)
    $(this).val(thisVal)
}).focus(function() {
    var thisVal = $(this).val()
    thisVal = thisVal.replace(/,/g, '')
    $(this).val(thisVal)
})