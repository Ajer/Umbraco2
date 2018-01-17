app = angular.module("umbraco");

app.controller("InvestorDashboardController",['$scope', '$http','operations',
    function($scope, $http,operations) {

        var vm = this;


        function loadData() {

           
            //$scope.persons = [
            //{
            //    "Firstname": "Gunnar",
            //    "Lastname": "Svensson",
            //    "Yrke":"Läkare",
            //    "Address": "Solarisvägen 345",
            //    "Zip": "70332",
            //    "City": "Malmö"
            //},
            //{
            //    "Firstname": "Norbert",
            //    "Lastname": "Heribertsson",
            //    "Yrke":"Byggkonsult",
            //    "Address": "Stjärnstadsvägen 111",
            //    "Zip": "29971",
            //    "City": "Lund"
            //},
            //{
            //    "Firstname": "Robert",
            //    "Lastname": "Gustafsson",
            //    "Yrke":"Komiker",
            //    "Address": "Komedivägen 34",
            //    "Zip": "27971",
            //    "City": "Stockholm"
            //}

            //];



            var url = 'api/InvestorPerson/GetPersons';

            operations.ReadAll(url).success(function (data)
            {
                if (data != null) {
                    $scope.persons = data;
                    $scope.ok = true;
                }
                else {
                    $scope.ok = false;
                }

            }).error(function () {

                $scope.ok = false;
                //alert('Error loadData');

           });


            //$http({  This is it
            //    method: 'GET',
            //    url: 'api/InvestorPerson/GetPersons',
            //    contentType: 'application/json'
            //}).success(function(data) {

            //    $scope.persons = data;

            //}).error(function() {

            //    alert('Error loadData');
            //});


            //$.ajax({
            //    type: 'GET',
            //    url: 'api/Investor/GetPersons',
            //    dataType: 'json',
            //    contentType: 'application/json',
            //    success: function(result) {
            //         alert(result[0]);
            //    },

            //    error: function() {
            //        alert('');
            //    }
            //});



        }

        loadData();
       
    }
]);


app.factory('operations',
    function($http) {
        return{
            Create: function(url, data) {
                return $http({
                    method: 'POST',
                    url:url,
                    data:data
                });
            },
            ReadAll: function(url) {
                return $http({
                    method: 'GET',
                    contentType: 'application/json',
                    url: url
                });
            },
            Read: function(url,parameters) {
                return $http({
                    method: 'GET',
                    url: url,
                    contentType: 'application/json',
                    params:parameters
                });
            },
            Update: function (url, parameters,data) {
                return $http({
                    method: 'PUT',
                    url: url,
                    params: parameters,
                    data: data

                });
            },
            Delete: function(id) {
                return $http.delete(url + id);
            }
        }
    }
);