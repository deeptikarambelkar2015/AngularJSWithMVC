/// <reference path="angular.js" />

var myApp = angular.module("EmployeeApp", []);

myApp.controller("UpdateEmployee", function ($scope, $http) {

    $scope.employee = {}
    $scope.message = "";

    $scope.loadrecord = function (employeeId) {
        $http({
            url: "/Employee/GetEmployee",
            method: "GET",
            params: { id: employeeId }
        }).then(
            function (successResponse) {
                $scope.employee = successResponse.data;
            },
            function (errorResponse) {
                $scope.message = "Error occured while loading the data.";
                console.log(errorResponse);
            }
        );
    };

    $scope.UpdateEmployee = function () {
        $http.post('/Employee/UpdateEmployee', $scope.employee).then(
            function (successResponse) {
                console.log('success');
                $scope.newEmployee = {};
                $scope.message = "Saved Successfully.";

                //If you want to redirect user to the Index page, un-comment the code below
                //window.location.pathname = 'Employee/Index';
            },
            function (errorResponse) {
                // handle errors here
            });
    }
});

myApp.controller("EmployeeDetails", function ($scope, $http) {
    $scope.searchBy = "Enter keyword..";
    $scope.employee = {}
    $scope.message = "";
    $scope.getEmployee = function () {
        $http({
            url: "/Employee/GetEmployee",
            method: "GET",
            params: { id: $scope.searchBy }
        }).then(
            function (successResponse) {
                $scope.employee = successResponse.data;
            },
            function (errorResponse) {
                $scope.message = "Incorrect Input / User does not exist";
                console.log(errorResponse);
            }
        );
    }
});

myApp.controller("EmployeeIndex", function ($scope, $http) {

    $scope.employeeList = [];
    $scope.message = "";

    //Called on load
    $http({
        url: "/Employee/GetEmployees",
        method: "GET"
    }).then
        (
            function (successResponse) {
                $scope.employeeList = successResponse.data;
            },
            function (errorResponse) {
                $scope.message = "Error occured while fetching data.";
                console.log(errorResponse);
            }
    );

    $scope.DeleteEmployee = function(employeeID) {

        var URL = '/Employee/DeleteEmployee/' + employeeID
        alert(URL);
        $http.post(URL).then(
            function (successResponse) {
                $scope.employeeList = successResponse.data;
            },
            function (errorResponse) {
                alert(errorResponse);
            });
          
    };

    $scope.DeleteEmployeeTest = function (employeeID) {
        alert("deleted - " + employeeID);
    }
});


myApp.controller("EmployeePost", function ($scope, $http) {
    $scope.message = "";
    $scope.newEmployee = {};
    //Posting employee data
    $scope.addEmployee = function () {
        $scope.message = "Saving...";
        $http.post('/Employee/AddEmployee', $scope.newEmployee).then(
            function (successResponse) {
                console.log('success');
                $scope.newEmployee = {};
                $scope.message = "Saved Successfully.";

                //If you want to redirect user to the Index page, un-comment the code below
                //window.location.pathname = 'Employee/Index';
            },
            function (errorResponse) {
                // handle errors here
            });
    };
});

