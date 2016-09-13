

var ThokGharApp = angular.module('ThokGharApp', [])

ThokGharApp.controller('ProductController', function ($scope, ProductService) {
    $scope.message = "List of Products";

    getProducts(); //Function name here is getBlogs
    function getProducts() {
        ProductService.getProducts() //Function name here is getBlogs
            .success(function (products) {
                $scope.AllProducts = products;  // get blogs as parameter
                console.log($scope.AllProducts);
            })
            .error(function (error) {
                $scope.status = 'Unable to load Products: ' + error.message;
                console.log($scope.status);
            });
    }



});




//Service 
ThokGharApp.factory('ProductService', ['$http', function ($http) {

    var ProductService = {};
    ProductService.getProducts = function () {
        return $http.get('/SuperAdmin/Manage_Product_Item/ListProduct');
    };
    return ProductService;

}]);