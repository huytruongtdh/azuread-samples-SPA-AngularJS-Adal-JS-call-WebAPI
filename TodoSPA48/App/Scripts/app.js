'use strict';
angular.module('todoApp', ['ngRoute','AdalAngular'])
.config(['$routeProvider', '$httpProvider', 'adalAuthenticationServiceProvider', function ($routeProvider, $httpProvider, adalProvider) {

    $routeProvider.when("/Home", {
        controller: "homeCtrl",
        templateUrl: "/App/Views/Home.html",
    }).when("/TodoList", {
        controller: "todoListCtrl",
        templateUrl: "/App/Views/TodoList.html",
        requireADLogin: true,
    }).when("/UserData", {
        controller: "userDataCtrl",
        templateUrl: "/App/Views/UserData.html",
    }).otherwise({ redirectTo: "/Home" });

    adalProvider.init(
        {
            instance: 'https://login.microsoftonline.com/', 
            tenant: 'f7f1996f-3fe9-468c-8aa4-718eb57ba1d8',
            clientId: '3eda60ac-be77-4605-b1cf-82de40e4495c',
            extraQueryParameter: 'nux=1',
            // #1 For OAuth2 Authrization Endpoint v1.0 ONLY:
            //responseType: 'id_token token', // enable if working with the latest version of Azure Appliation Object

            // #2 For OAuth2 Authrization Endpoint v2.0 ONLY:
            v2EndpointScope: 'openid',
            //cacheLocation: 'localStorage', // enable this for IE, as sessionStorage does not work for localhost.
        },
        $httpProvider
        );
   
}]);
