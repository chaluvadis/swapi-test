(function () {
    'use strict';
    angular.module('starwars', [])
        .controller('StartWarsController', StartWarsController);

    StartWarsController.$inject = ['$scope']
    function StartWarsController($scope) {
        var vm = this;
        this.message = "Angular Js Awesome"
    }
})();