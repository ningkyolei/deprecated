var LynDateTime = (function () {
    var getDateByDateTimeString = function (pDateTimeString) {
        var checkIsIe8 = function () {
            var flag = $.browser.version === "8.0" && $.browser.msie;
            return flag;
        };

        var checkIsIe11 = function () {
            var flag = $.browser.version === "11.0" && $.browser.mozilla;
            return flag;
        };

        var aDateTimeString = pDateTimeString;
        var aDate;

        if (checkIsIe8() || checkIsIe11()) {
            var year = 1900, month = 1, day = 1, hour = 0, minute = 0, second = 0;
            var tempArray = aDate.split(/[-|: ]/gi);
            switch (tempArray.length) {
                case 5:
                    year = tempArray[0];
                    month = tempArray[1];
                    day = tempArray[2];
                    hour = tempArray[3];
                    minute = tempArray[4];
                    break;

                case 6:
                    year = tempArray[0];
                    month = tempArray[1];
                    day = tempArray[2];
                    hour = tempArray[3];
                    second = tempArray[5];
                    break;
            }

            aDate = new Date(year, month, day, hour, minute, second);
        } else {
            aDate = new Date(aDateTimeString);
        }

        return aDate;
    };

    var ctor = function (pInitParameter) {
        //_DefaultInitParameter---start
        var _DefaultInitParameter = {};
        _DefaultInitParameter.InitType = 'DateTimeString';
        _DefaultInitParameter.DateTimeString = null;
        _DefaultInitParameter.JsDateInstance = null;
        //_DefaultInitParameter---end

        //_InitParameter---start
        var _InitParameter = {};
        $.extend(_InitParameter, _DefaultInitParameter, pInitParameter);
        //_InitParameter---end

        //初始化_JsDateInstance---start
        var _JsDateInstance;
        switch (_InitParameter.InitType) {
            case 'DateTimeString':
                _JsDateInstance = getDateByDateTimeString(_InitParameter.DateTimeString);
                break;

            case 'JsDateInstance':
                _JsDateInstance = _InitParameter.JsDateInstance;
                break;
        }
        //初始化_JsDateInstance---end

        //获取Js的Date类型的实例
        var getJsDateInstance = function () {
            return _JsDateInstance;
        };

        //日期格式化
        //格式 YYYY/yyyy/YY/yy 表示年份
        //MM/M 月份
        //W/w 星期
        //dd/DD/d/D 日期
        //hh/HH/h/H 时间
        //mm/m 分钟
        //ss/SS/s/S 秒
        var format = function (pFormatString) {
            var date = _JsDateInstance;

            if (!pFormatString) {
                pFormatString = 'yyyy-MM-dd HH:mm:ss';
            }
            var str = pFormatString;


            var Week = ['日', '一', '二', '三', '四', '五', '六'];

            str = str.replace(/yyyy|YYYY/, date.getFullYear());
            str = str.replace(/yy|YY/, (date.getYear() % 100) > 9 ? (date.getYear() % 100).toString() : '0' + (date.getYear() % 100));

            var month = date.getMonth() + 1;
            str = str.replace(/MM/, month > 9 ? month.toString() : '0' + month);
            str = str.replace(/M/g, month);

            str = str.replace(/w|W/g, Week[date.getDay()]);

            str = str.replace(/dd|DD/, date.getDate() > 9 ? date.getDate().toString() : '0' + date.getDate());
            str = str.replace(/d|D/g, date.getDate());

            str = str.replace(/hh|HH/, date.getHours() > 9 ? date.getHours().toString() : '0' + date.getHours());
            str = str.replace(/h|H/g, date.getHours());
            str = str.replace(/mm/, date.getMinutes() > 9 ? date.getMinutes().toString() : '0' + date.getMinutes());
            str = str.replace(/m/g, date.getMinutes());

            str = str.replace(/ss|SS/, date.getSeconds() > 9 ? date.getSeconds().toString() : '0' + date.getSeconds());
            str = str.replace(/s|S/g, date.getSeconds());

            return str;
        };

        var addYear = function (pValue) {
            _JsDateInstance.setFullYear(_JsDateInstance.getFullYear() + pValue);
            return this;
        };

        var addMonth = function (pValue) {
            _JsDateInstance.setMonth(_JsDateInstance.getMonth() + pValue);
            return this;
        };

        var addDay = function (pValue) {
            _JsDateInstance.setDate(_JsDateInstance.getDate() + pValue);
            return this;
        };

        var addHour = function (pValue) {
            _JsDateInstance.setHours(_JsDateInstance.getHours() + pValue);
            return this;
        };

        var addMinute = function (pValue) {
            _JsDateInstance.setMinutes(_JsDateInstance.getMinutes() + pValue);
            return this;
        };

        var addSecond = function (pValue) {
            _JsDateInstance.setSeconds(_JsDateInstance.getSeconds() + pValue);
            return this;
        };

        var largerThan = function (pDateTime) {
            var x = Date.parse(_JsDateInstance);
            var y = Date.parse(pDateTime.getJsDateInstance());
            var flag = (x > y);
            return flag;
        };

        var largerThanOrEqual = function (pDateTime) {
            var x = Date.parse(_JsDateInstance);
            var y = Date.parse(pDateTime.getJsDateInstance());
            var flag = (x >= y);
            return flag;
        };

        var lessThan = function (pDateTime) {
            var x = Date.parse(_JsDateInstance);
            var y = Date.parse(pDateTime.getJsDateInstance());
            var flag = (x < y);
            return flag;
        };

        var lessThanOrEqual = function (pDateTime) {
            var x = Date.parse(_JsDateInstance);
            var y = Date.parse(pDateTime.getJsDateInstance());
            var flag = (x <= y);
            return flag;
        };

        var equal = function (pDateTime) {
            var x = Date.parse(_JsDateInstance);
            var y = Date.parse(pDateTime.getJsDateInstance());
            var flag = (x === y);
            return flag;
        };

        this.getJsDateInstance = getJsDateInstance;
        this.format = format;
        this.toString = format;

        this.addYear = addYear;
        this.addMonth = addMonth;
        this.addDay = addDay;
        this.addHour = addHour;
        this.addMinute = addMinute;
        this.addSecond = addSecond;

        this.largerThan = largerThan;
        this.largerThanOrEqual = largerThanOrEqual;
        this.lessThan = lessThan;
        this.lessThanOrEqual = lessThanOrEqual;
        this.equal = equal;

    };

    return ctor;
})();

LynDateTime.now = function () {
    var o = new LynDateTime({
        InitType: 'JsDateInstance',
        JsDateInstance: new Date()
    });
    return o;
};