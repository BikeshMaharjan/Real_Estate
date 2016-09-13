

var BlogApp = angular.module('BlogApp', [])

BlogApp.controller('BlogController', function ($scope, BlogService) {
    $scope.message = "List of Blogs";

    getBlogs(); //Function name here is getBlogs
    function getBlogs() {
        BlogService.getBlogs() //Function name here is getBlogs
            .success(function (blogs) {
                $scope.AllBlogs = blogs;  // get blogs as parameter
                console.log($scope.AllBlogs);
            })
            .error(function (error) {
                $scope.status = 'Unable to load Blog data: ' + error.message;
                console.log($scope.status);
            });
    }



});




//Service 
BlogApp.factory('BlogService', ['$http', function ($http) {

    var BlogService = {};
    BlogService.getBlogs = function () {
        return $http.get('/Blogs/Index');
    };
    return BlogService;

}]);