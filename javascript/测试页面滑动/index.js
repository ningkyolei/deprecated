//ViewId不能用Dom的Id，应该Dom的Id会被当作锚点
Zepto(function ($) {
    var page1 = controller.createView({
        ViewId: 'page-1'
    });

    var page2 = controller.createView({
        ViewId: 'page-2'
    });

    var page3 = controller.createView({
        ViewId: 'page-3'
    });

    page1.on('click', '.btn-next', function (e) {
        controller.nav({
            ViewId: page2.ViewId
        })
    });

    page2.on('click', '.btn-back', function (e) {
        controller.nav({
            ViewId: page1.ViewId
        })
    });

    page2.on('click', '.btn-next', function (e) {
        controller.nav({
            ViewId: page3.ViewId
        })
    });

    page3.on('click', '.btn-back', function (e) {
        controller.nav({
            ViewId: page2.ViewId
        })
    });

    controller.nav();
});

var controller = (function () {
    var initParameter = {};
    initParameter.IndexViewId = 'page-1';

    var _controller = new Lyn.Mobile.Page.Controller({
        IndexViewId: initParameter.IndexViewId
    });

    var createView = function (pParameter) {
        var viewId = pParameter.ViewId;
        var $e = $('.' + viewId);
        var activeClass = viewId + '-active';

        var view = _controller.createView({
            $: $e,
            ViewId: viewId,
            ActiveClass: activeClass
        });
        return view;
    };

    var nav = function (pParameter) {
        _controller.nav(pParameter);
    };

    var o = {};
    o.createView = createView;
    o.nav = nav;
    return o;
})();