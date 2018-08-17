// math.js(使用到helloWorld.js)
define(['helloWorld'], function (helloWorld) {
    var add = function (x, y) {
        return x + y;
    };
    var sub = function (x, y) {
        document.writeln(helloWorld.sayHello());
        return x - y;
    };
    return {
        add: add,
        sub: sub
    };
});