app.controller("productController", ["$scope", "$http", function ($scope, $http) {

    $http.get("/api/values").then(function (result) {
        $scope.values = result.data;
    });

   
}]);