﻿app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "/App/views/product.html",
            controller: "productController"
        })
        .when("/login",
        {
            templateUrl: "/App/views/login.html",
            controller: "loginController"
        })

        .otherwise("/"
        );
}]);


app.run(["$rootScope", "$http", "$location", function ($rootScope, $http, $location) {

    $rootScope.isLoggedIn = function () {
        return !!sessionStorage.getItem("token")
    }

    $rootScope.$on("$routeChangeStart", function (event, currRoute) {
        var anonymousPage = false;
        var originalPath = currRoute.originalPath;

        console.log("originalpath:", originalPath);

        if (originalPath) {
            anonymousPage = originalPath.indexOf("/login") !== -1 ||
                            originalPath == "/";
        }

        if (!anonymousPage && !$rootScope.isLoggedIn()) {
            event.preventDefault();
            $location.path("/");
        }
    });

    var token = sessionStorage.getItem("token");

    if (token)
        $http.defaults.headers.common["Authorization"] = `bearer ${token}`;
}])