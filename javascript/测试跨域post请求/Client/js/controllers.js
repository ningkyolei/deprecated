angular.module('starter.controllers', [])

    .controller('DashCtrl', function ($scope, $http) {
        $http({
            url: 'http://192.168.8.36/test/action.ashx',
            method: "POST",
            //headers: {
            //    'Content-Type': 'application/x-www-form-urlencoded'
            //},
            data: {
                email: 'root@qq.com',
                password: '123456'
            }
        })
        .success(function (data) {
            debugger;
        })
        ;


    })

    .controller('ChatsCtrl', function ($scope, Chats) {
        $scope.chats = Chats.all();
        $scope.remove = function (chat) {
            Chats.remove(chat);
        };
    })

    .controller('ChatDetailCtrl', function ($scope, $stateParams, Chats) {
        $scope.chat = Chats.get($stateParams.chatId);
    })

    .controller('AccountCtrl', function ($scope) {
        $scope.settings = {
            enableFriends: true
        };
    });
