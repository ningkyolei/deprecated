var Lyn = window.Lyn;
if (!Lyn)  Lyn = {};

Lyn.Mobile = (function () {
    var _Mobile = {};

    var Page = {};

    Page.View = (function () {
        var ctor = function (pViewInitParameter) {
            var defaultInitParameter = {};
            defaultInitParameter.$ = null;
            defaultInitParameter.ViewId = null;
            defaultInitParameter.ActiveClass = null;
            var initParameter = {};
            $.extend(initParameter, defaultInitParameter, pViewInitParameter);
            $.extend(this, initParameter);

            var $c = initParameter.$;

            var on = function (eventName, selector, handler) {
                $c.off(eventName, selector).on(eventName, selector, handler);
            };

            this.$ = $c;
            this.on = on;
        };
        return ctor;
    })();

    Page.Controller = (function () {
        var ctor = function (pControllerInitParameter) {
            //初始化initParameter---start
            var defaultInitParameter = {};
            defaultInitParameter.IndexViewId = '';
            defaultInitParameter.ViewCollection = {};
            var initParameter = {};
            $.extend(initParameter, defaultInitParameter, pControllerInitParameter);
            $.extend(this, initParameter);
            //初始化initParameter---end

            //事件绑定---start
            $(window).on('hashchange', function () {
                refresh();
            });
            //事件绑定---end

            //私有方法---start
            var viewList = [];
            var getViewList = function () {
                return viewList;
            };

            var createView = function (pViewInitParameter) {
                var view = new Lyn.Mobile.Page.View(pViewInitParameter);
                viewList.push(view);
                this.ViewCollection[view.ViewId] = view;
                return view;
            };

            var refresh = function () {
                var viewList = getViewList();
                var activeClassList = _.map(viewList, function (m) {
                    return m.ActiveClass;
                });
                var activeClassString = activeClassList.join(' ');
                var $body = $('body');
                $body.removeClass(activeClassString);

                var viewId = window.location.hash.replace('#', '');
                if (!viewId) {
                    viewId = initParameter.IndexViewId;
                }
                var view = _.find(viewList, function (m) {
                    return m.ViewId === viewId;
                });
                $body.addClass(view.ActiveClass);
            };

            var nav = function (pNavParameter) {
                if (!pNavParameter) pNavParameter = {};

                var defaultNavParameter = {};
                var navParameter = {};
                $.extend(navParameter, defaultNavParameter, pNavParameter);

                if (!navParameter.ViewId) {
                    if (!initParameter.IndexViewId) {
                        console.error('没有设置IndexViewId！');
                        return;
                    }

                    navParameter.ViewId = initParameter.IndexViewId;
                }

                window.location.hash = navParameter.ViewId;
            };

            //私有方法---end

            //公有方法---start
            this.createView = createView;
            this.nav = nav;
            //公有方法---end
        };
        return ctor;
    })();

    _Mobile.Page = Page;

    return _Mobile;
})();