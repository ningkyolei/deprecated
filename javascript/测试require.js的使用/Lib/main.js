require.config({
    baseUrl: 'Lib',
    paths: {
        'jquery': 'jquery.min',//jquery-2.0.3.min
        'math': 'math',
        'helloWorld':''
    }
});

require(['jquery', 'math'], function ($, math) {
    $(document).ready(function () {
        document.writeln(math.sub(3, 1));
    });


});