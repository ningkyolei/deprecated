var lynLoading = (function () {

    var getHtml = function () {
        var html = '';
        html += '<div id="lyn-loading-container">';
        html += '<div id="lyn-loading">';
        html += '    <span class="item-1"></span>';
        html += '    <span class="item-2"></span>';
        html += '    <span class="item-3"></span>';
        html += '    <span class="item-4"></span>';
        html += '    <span class="item-5"></span>';
        html += '    <span class="item-6"></span>';
        html += '    <span class="item-7"></span>';
        html += '</div>';
        html += '</div>';
        return html;
    };

    var $container = null;
    var get$Container = function () {
        if (!$container) {
            var html = getHtml();
            $container = $(html);
            $('body').append($container);
        }
        return $container;
    };

    var show = function () {
        var $c = get$Container();
        $c.show();
    };

    var hide = function () {
        var $c = get$Container();
        $c.hide();
    };

    var o = {};
    o.show = show;
    o.hide = hide;
    return o;
})();
