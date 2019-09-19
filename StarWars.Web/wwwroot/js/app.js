(function () {
    'use strict';
    angular.module('starwars', ['ngRoute'])
        .config(configProvider)
        .controller('startWarsController', startWarsController)
        .factory('serviceFactory', serviceFactory)

    configProvider.$inject = ['$routeProvider', '$locationProvider']
    function configProvider($routeProvider,$locationProvider) {
        $routeProvider.when('/', {
            templateUrl:'views/index.html'
        }).
        when('/people/:id', {

        }).
        otherwise('/');
        $locationProvider.html5Mode(true);
    }

    startWarsController.$inject = ['$scope', 'serviceFactory']
    function startWarsController($scope, serviceFactory) {
        var vm = this;
        vm.peopleObject = {};
        vm.peoples = [];
        vm.next = ''
        vm.previous = ''
        vm.getPeopleId = getPeopleId;
        vm.getQueryString = getQueryString;
        vm.viewPeopleProfile = viewPeopleProfile;
        vm.handlePageChange = handlePageChange;
        const entity = 'people';

        function handlePageChange(page) {
            console.log(page)
            serviceFactory.getPeople(entity, page)
                .then(feedData);
        }
        function getPeopleId(url) {
            return url.split('/').reverse()[1];
        }

        function viewPeopleProfile(people) {
            console.log(people);
        }

        function getQueryString(url) {
            return url ? url.substring(url.indexOf('?')) : ''
        }

        function feedData(data) {
            console.log(data);
            vm.peopleObject = data;
            vm.peoples = data.results;
            vm.previous = vm.peopleObject.previous;
            vm.next = vm.peopleObject.next;
        }
        function getPeople(entity, page) {
            serviceFactory.getPeople(entity, page)
                .then(feedData);
        }
        getPeople('people','?page=1');
    }

    serviceFactory.$inject = ['$http']
    function serviceFactory($http) {
        return {
            getPeople: getPeople
        };
        function getPeople(entity, pageUrl) {
            // initial payload request, https://swapi.c
            var queryString = `/entity=${entity}/?=page=${pageUrl}`;
            console.log(queryString);
            var url = `/api/data/?=queryString=${queryString}`;
            console.log(url);
            return $http.get('/api/data/?='+ entity +'/' + pageUrl)
                .then(getPeopleComplete)
                .catch(getPeopleFailed);

            function getPeopleComplete(response) {
                return response.data;
            }
            function getPeopleFailed(err) {
                console.error('XHR Failed for People request' + err)
            }
        }
    }
})();