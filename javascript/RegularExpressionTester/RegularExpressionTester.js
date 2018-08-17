var helper = (function () {
    var obj = {};
    obj.getGroupInfoList = function (reg, text) {
        var checkResult = function (result) {
            var isOk = false;
            if (result != null) {
                isOk = true;
                if (result.length === 1 && result[0] === '') {
                    //解决输入$时会出现死循环的问题
                    isOk = false;
                }
            }
            return isOk;
        }

        var groupInfoList = [];
        var result;
        while (checkResult(result = reg.exec(text))) {
            var groupInfo = {};
            groupInfo.sourceText = result[0];
            groupInfo.groupText = result[1];
            groupInfo.startIndex = result.index;
            groupInfo.endIndex = groupInfo.startIndex + groupInfo.sourceText.length - 1;
            groupInfoList.push(groupInfo);
        }
        return groupInfoList;
    };
    obj.outputToMatchResult = function (text, groupInfoList) {
        var $result = $('<div></div>');
        for (var i = 0; i < text.length; i++) {
            var c = text[i];
            $result.append('<label>' + c + '</label>');
        }

        for (var i = 0; i < groupInfoList.length; i++) {
            var groupInfo = groupInfoList[i];
            for (var j = groupInfo.startIndex; j <= groupInfo.endIndex; j++) {
                var $label = $($result.find('label')[j]);
                if (i % 2 === 0) {
                    $label.css('background-color', 'red')
                } else {
                    $label.css('background-color', 'yellow')
                }
            }
        }

        $('.panel-match-result').html($result.html());
    };
    obj.outputToMatchGroups = function (groupInfoList) {
        var $result = $('<div></div>');
        for (var i = 0; i < groupInfoList.length; i++) {
            var groupInfo = groupInfoList[i];
            var $row = $('<div class="row"></div>');
            var $col1 = $('<div class="col-md-2"><label></label></div>');
            $col1.find('label').html('group' + (i + 1));
            var $col2 = $('<div class="col-md-10"><label></label></div>');
            $col2.find('label').html(groupInfo.groupText);
            $row.append($col1);
            $row.append($col2);
            $result.append($row);
        }

        $('.panel-match-groups').html($result.html());
    };
    obj.clearMathResultAndMatchGroups = function () {
        $('.panel-match-result').html('');
        $('.panel-match-groups').html('');
    };
    obj.runRegExec = function () {
        helper.clearMathResultAndMatchGroups();

        var regText = $('.reg-text').val();
        var regAttributes = $('.reg-attr').val();
        var text = $('.input-text').val();

        try {
            var reg = new RegExp(regText, regAttributes);
        } catch (e) {
            return;
        }

        var groupInfoList = helper.getGroupInfoList(reg, text);
        helper.outputToMatchResult(text, groupInfoList);
        helper.outputToMatchGroups(groupInfoList);
    }
    return obj;
})();

$(document).ready(function () {
    $('.btnRegExec').click(helper.runRegExec);
    $('.reg-text').keyup(helper.runRegExec);
    $('.reg-attr').keyup(helper.runRegExec);
    $('.input-text').keyup(helper.runRegExec);
});