

var RealEstateApp = angular.module('RealEstateApp', [])

RealEstateApp.controller('PropertyController', function ($scope, PropertyService) {
    $scope.message = "List of Properties";

    getProperty(); //Function name here is getBlogs
    function getProperty() {
        PropertyService.getProperty() //Function name here is getBlogs
            .success(function (properties) {
                $scope.AllProperty = properties;  // get blogs as parameter
                console.log($scope.AllProperty);
            })
            .error(function (error) {
                $scope.status = 'Unable to load Property: ' + error.message;
                console.log($scope.status);
            });
    }



});




//Service 
RealEstateApp.factory('PropertyService', ['$http', function ($http) {

    var PropertyService = {};
    PropertyService.getProperty = function () {
        return $http.get('/SuperAdmin/Manage_Property/ListProperty');
    };
    return PropertyService;

}]);