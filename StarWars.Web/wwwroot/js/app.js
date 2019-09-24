(function () {
    'use strict';
    angular.module('starwars', ['ngRoute'])
        .config(configProvider)
        .controller('peopleListController', peopleListController)
        .controller('detailsController', detailsController)
        .factory('serviceFactory', serviceFactory)

    configProvider.$inject = ['$routeProvider', '$locationProvider']
    peopleListController.$inject = ['$scope', '$rootScope', 'serviceFactory', '$location']
    serviceFactory.$inject = ['$http']
    detailsController.$inject = ['$scope', '$rootScope']
    function configProvider($routeProvider, $locationProvider) {
        $routeProvider.when('/', {
            templateUrl: 'views/index.html'
        }).when('/people/:id', {
            templateUrl: 'views/details.html'
        }).otherwise('/');
        $locationProvider.html5Mode(true);
    }
    function peopleListController($scope, $rootScope, serviceFactory, $location) {
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
            var id = getPeopleId(people.url);
            $rootScope.selectedPeople = people;
            $rootScope.selectedPeople.id = id;
            $location.path(`/people/${id}`);
        }
        function getQueryString(url) {
            return url ? url.substring(url.indexOf('?')) : ''
        }
        function feedData(data) {
            vm.peopleObject = data;
            vm.peoples = data.results;
            vm.previous = vm.peopleObject.previous;
            vm.next = vm.peopleObject.next;
        }
        function getPeople(entity, page) {
            serviceFactory.getPeople(entity, page)
                .then(feedData);
        }
        getPeople(entity, '?page=1');
    }
    function serviceFactory($http) {
        return {
            getPeople: getPeople
        };
        function getPeople(entity, pageUrl) {
            // initial payload request, https://swapi.c
            return $http.get('/api/data/', {
                params: {
                    entity: entity,
                    pageUrl: pageUrl
                }
            }).then(getPeopleComplete)
                .catch(getPeopleFailed);
            function getPeopleComplete(response) {
                return response.data;
            }
            function getPeopleFailed(err) {
                console.error('XHR Failed for People request' + err)
            }
        }
    }

    function detailsController($scope, $rootScope) {
        var vm = this;
        vm.selectedPeople = {};
        vm.getPeopleDetails = getPeopleDetails;
        vm.submitForm = submitForm;
        function submitForm(person) {
            console.log(person);
        }
        function getPeopleDetails() {
            vm.selectedPeople = $rootScope.selectedPeople;
            console.log(vm.selectedPeople)
        }
        getPeopleDetails();
    }
})();