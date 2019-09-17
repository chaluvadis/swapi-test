(function () {
    'use strict';
    angular.module('starwars', [])
        .controller('startWarsController', startWarsController)
        .factory('serviceFactory', serviceFactory)

    startWarsController.$inject = ['$scope', 'serviceFactory']
    function startWarsController($scope, serviceFactory) {
        var vm = this;
        vm.peopleObject = {};
        vm.peoples = [];
        vm.getPeopleId = getPeopleId;
        vm.viewPeopleProfile = viewPeopleProfile;

        function getPeopleId(url) {
            return url.split('/').reverse()[1];
        }

        function viewPeopleProfile(people) {
            console.log(people);
        }

        function getPeople() {
            serviceFactory.getPeople()
                .then(function (data) {
                    console.log(data);
                    vm.peopleObject = data;
                    vm.peoples = data.results;
                })
        }
        getPeople();
    }

    serviceFactory.$inject = ['$http']
    function serviceFactory($http) {
        return {
            getPeople: getPeople
        };
        function getPeople() {
            return $http.get('/api/data/people')
                .then(getPeopleComplete)
                .catch(getPeopleFailed);

            function getPeopleComplete(response) {
                return response.data;
            }
            function getPeopleFailed(err) {
                cosnole.error('XHR Failed for People request')
            }
        }
    }
})();