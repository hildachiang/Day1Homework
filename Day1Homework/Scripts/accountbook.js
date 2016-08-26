jQuery.validator.addMethod(
//檢核規則名稱
     'dayrange',
    //實做檢查邏輯的函數，共有三個參數
      //value=欄位內容, elem為欄位元素, params為額外參數
function (value, elem, params) {
    if (!value) return false;
    var valueDateParts = value.split('-');
    var minDate = new Date();
    var maxDate = new Date();
    var now = new Date();
    var dateValue = new Date(valueDateParts[0],
                        valueDateParts[1] - 1,
                         valueDateParts[2],
                         now.getHours(),
                         now.getMinutes(),
                         (now.getSeconds() + 5));

    return dateValue > now;
},
     ''
     );
jQuery.validator.unobtrusive.adapters.add(
    'dayrange', [],
    function (options) {
        options.rules["dayrange"] = true;
        options.messages['dayrange'] = options.message;
    }
);

jQuery.validator.addMethod('extmaxlength', function (value, element, params) {
    var remaining = (100 - (parseInt($(element).val().replace(/(\r\n|\n|\r)/gm, '').length, 10)));
    if (remaining < 0) {
        return false;
    }
    return true;
});
jQuery.validator.unobtrusive.adapters.add(
    'extmaxlength', [],
    function (options) {
        options.rules["extmaxlength"] = true;
        options.messages['extmaxlength'] = options.message;
    }
);