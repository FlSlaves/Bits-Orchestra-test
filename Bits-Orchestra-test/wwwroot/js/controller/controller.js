var app = angular.module("myApp", []);

app.controller("myCtrl", function ($scope, $http) {

    $scope.GetAllData = function () {
        $http({
            method: "get",
            url: "https://localhost:7105/api/excel/get"
        }).then(function (response) {
            $scope.records = response.data;
        });
    }
    $scope.hideform = true;
    //Create New User
    $scope.AddRecord = function (name, dateOfBirth, isMarried, phone, salary) {
        let married = (isMarried == 'true' ? true : false);
        $http({
            method: 'POST',
            url: 'https://localhost:7105/api/excel/createrecord',
            data: {
                Name: name,
                DateOfBirth: dateOfBirth,
                isMarried: married,
                Phone: phone,
                Salary: salary
            }
        }).then(function successCallback(response) {
            $scope.records.push(response.data);
            $scope.GetAllData();
            alert("Record has created Successfully")
        }, function errorCallback(response) {
            alert("Error. while created record Try Again!");
        });

    };

    $scope.UpdateRecord = function (name, dateOfBirth, isMarried, phone, salary) {
        let married = (isMarried == 'true' ? true : false);
        $http({
            method: "put",
            url: "https://localhost:7105/api/excel/updaterecord/" + $scope.record.id,
            data: {
                Name: name,
                DateOfBirth: dateOfBirth,
                isMarried: married,
                Phone: phone,
                Salary: salary
            }
        }).then(function successCallback(response) {
            alert("User has updated Successfully")
            $scope.GetAllData();
        }, function errorCallback(response) {
            alert("Error. while updating user Try Again!");
        });
    }
    $scope.DeleteRecord = function (record) {
        //$http DELETE function
        $http({

            method: 'DELETE',
            url: 'https://localhost:7105/api/excel/deleteitem/' + record.id

        }).then(function successCallback(response) {

            alert("User has deleted Successfully");
            var index = $scope.records.indexOf(record);
            $scope.records.splice(index, 1);

        }, function errorCallback(response) {

            alert("Error. while deleting user Try Again!");

        });
    };
    $scope.update = false;
    $scope.create = false;
    //Set $scope on Edit button click
    $scope.editRecord = function (record) {
        $scope.record = record;
        $scope.name = $scope.record.name;
        $scope.isMarried = '';
        $scope.phone = $scope.record.phone;
        $scope.salary = '';
        $scope.hideform = false;
        $scope.create = false;
        $scope.update = true;
    };
    $scope.createRecord = function () {
        $scope.name = '';
        $scope.isMarried = '';
        $scope.phone = '';
        $scope.salary = '';
        $scope.hideform = false;
        $scope.create = true;
        $scope.update = false;
    };
    $scope.cancelRecord = function () {
        $scope.hideform = true;
    }
    $scope.propertyName = 'id';
    $scope.reverse = false;

     $scope.sortBy = function (propertyName) {
        $scope.reverse = ($scope.propertyName === propertyName) ? !$scope.reverse : false;
        $scope.propertyName = propertyName;
    };
});

app.directive('myCustomer', function () {
    return {
        restrict: 'E',
        templateUrl: '/js/templates/my-customer.html'
    };
});