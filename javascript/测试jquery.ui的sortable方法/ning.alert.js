(function (global, $) {
    global.ning = global.ning || {};
    global.ning.alert = function (msg) {
        var $msg = $('<div></div>');
        $msg.html(msg);
        var $container = $('<div></div>');
        $container.addClass('ning-alert');
        $container.append($msg);
        $container.appendTo($('body'));

        var left = $(global).width() / 2 - $container.outerWidth() / 2;
        $container.css('left', left);

        $container
            .animate({
                bottom: '40%',
                opacity: 0.7
            }, 'slow')
            .delay(2000)
            .animate({
                bottom: '20%',
                opacity: 0
            }, 'slow', function () {
                $(this).remove();
            });

    };
})(window, $);