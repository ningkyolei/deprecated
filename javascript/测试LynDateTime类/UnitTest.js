var UnitTest = (function () {
    var testCaseNumber = 1;

    var testCaseCollection = {};

    testCaseCollection.testCase1 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-09-01 23:11:00')
        });

        var aDateTimeString = aDateTime.toString('yyyy年MM月dd日 HH时mm分ss秒');

        var respectValue = '2014年09月01日 23时11分00秒';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase2 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-09-01 23:11:55')
        });

        var aDateTimeString = aDateTime.toString();

        var respectValue = '2014-09-01 23:11:55';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase3 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var aDateTimeString = aDateTime.addYear(10).toString();

        var respectValue = '2024-10-01 23:11:55';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase4 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var aDateTimeString = aDateTime.addYear(-10).toString();

        var respectValue = '2004-10-01 23:11:55';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase5 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var aDateTimeString = aDateTime.addMonth(10).toString();

        var respectValue = '2015-08-01 23:11:55';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase6 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var aDateTimeString = aDateTime.addDay(31).toString();

        var respectValue = '2014-11-01 23:11:55';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase7 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var aDateTimeString = aDateTime.addHour(2).toString();

        var respectValue = '2014-10-02 01:11:55';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase8 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var aDateTimeString = aDateTime.addMinute(50).toString();

        var respectValue = '2014-10-02 00:01:55';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase9 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var aDateTimeString = aDateTime.addSecond(10).toString();

        var respectValue = '2014-10-01 23:12:05';
        if (aDateTimeString === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }

    };

    testCaseCollection.testCase10 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-02 23:11:55')
        });

        var bDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-01 23:11:55')
        });

        var flag = aDateTime.largerThan(bDateTime);
        var respectValue = true;
        if (flag === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }
    };

    testCaseCollection.testCase11 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-02 23:11:55')
        });

        var bDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-02 23:11:55')
        });

        var flag = aDateTime.largerThanOrEqual(bDateTime);
        var respectValue = true;
        if (flag === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }
    };

    testCaseCollection.testCase12 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2012-10-02 23:11:55')
        });

        var bDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2014-10-02 23:11:55')
        });

        var flag = aDateTime.lessThan(bDateTime);
        var respectValue = true;
        if (flag === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }
    };

    testCaseCollection.testCase13 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2012-10-02 23:11:55')
        });

        var bDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2012-10-02 23:11:55')
        });

        var flag = aDateTime.lessThanOrEqual(bDateTime);
        var respectValue = true;
        if (flag === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }
    };

    testCaseCollection.testCase14 = function () {
        var aDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2012-10-02 23:11:55')
        });

        var bDateTime = new LynDateTime({
            InitType: 'JsDateInstance',
            JsDateInstance: new Date('2012-10-02 23:11:55')
        });

        var flag = aDateTime.equal(bDateTime);
        var respectValue = true;
        if (flag === respectValue) {
            console.log(testCaseNumber++ + ':ok!');
        } else {
            console.log(testCaseNumber++ + ':not ok!!!');
        }
    };

    var run = function () {
        _.each(testCaseCollection, function (propertyValue, propertyName) {
            var func = propertyValue;
            func();
        });
    };

    var o = {};
    o.run = run;
    return o;
})();