var lyn = (function () {
    var _this = {};

    var isNumeric = function (obj) {//代码复制自JQuery
        return !isNaN(parseFloat(obj)) && isFinite(obj);
    };

    //<editor-fold desc="string">
    var trimBeginExpression = /^\s\s*/g;
    var trimEndExpression = /\s\s*$/g;

    _this.string = {
        format: function () {
            if (!arguments[0]) {
                return "";
            }
            if (arguments.length == 1) {
                return arguments[0];
            }
            else if (arguments.length >= 2) {
                for (var i = 1; i < arguments.length; i++) {
                    arguments[0] = arguments[0].replace(new RegExp("\\{" + (i - 1) + "\\}", "gm"), arguments[i]);
                }
                return arguments[0].replace(new RegExp("\\{", "gm"), "{").replace(new RegExp("\\}", "gm"), "}");
            }
        },

        trimStart: function (value) {
            return String(value).replace(trimBeginExpression, "");
        },

        trimEnd: function (value) {
            return String(value).replace(trimEndExpression, "");
        },

        trim: function (value) {
            var s = this.trimStart(value);
            s = this.trimEnd(s);
            return s;
        }
    };
    //</editor-fold>

    //<editor-fold desc="convert">
    _this.convert = {
        toInt: function (obj, defaultValue) {
            var value;
            if (defaultValue === null || defaultValue === undefined || !isNumeric(defaultValue)) {
                value = 0;
            } else {
                value = defaultValue;
            }
            if (isNumeric(obj)) {
                value = parseInt(obj);
            }
            return value;
        },
        toBool: function (obj, defaultValue) {
            var value;
            if (defaultValue === null || defaultValue === undefined) {
                value = false;
            } else {
                value = defaultValue;
            }
            if (obj != null && obj != undefined) {
                var temp = _this.string.trim(obj.toString()).toLocaleLowerCase();
                if (temp === "true") value = true;
                else if (temp === "false") value = false;
            }
            return value;
        }
    };
    //</editor-fold>

    //<editor-fold desc="url">
    _this.url = {
        getQueryString: function getQueryString(name) {
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
            var r = location.search.substr(1).match(reg);
            if (r != null) return unescape(decodeURI(r[2]));
            return null;
        }
    }
    //</editor-fold>

    return _this;
})();

