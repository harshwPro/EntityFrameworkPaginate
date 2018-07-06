var my = my || {};

$(document).ready(function () {
    my.rootUrl = $("#linkRootUrl").attr("href");
    if (my.rootUrl === "/") {
        my.rootUrl = "";
    }

    my.ajaxGetJson = function (method, jsonIn, callback) {
        $.ajax({
            url: my.rootUrl + method,
            type: "GET",
            data: ko.toJSON(jsonIn),
            dataType: "json",
            contentType: "application/json",
            success: function (json) {
                callback(json);
            },
            error: function () {
            }
        });
    }

    my.employeesVm = function () {
        var vm = {
            employees: ko.observableArray([]),
            currentPage: ko.observable(1),
            pageCount: ko.observable(0),
            pageSize: ko.observable(10),
            recordCount: ko.observable(0),
            sortBy: ko.observable(3),
            searchText: ko.observable(""),
            jobTitle: ko.observable("")
        },
            getEmployeesCallback = function (response) {
                my.employeesVm.vm.employees([]);
                my.employeesVm.vm.currentPage(response.CurrentPage);
                my.employeesVm.vm.pageCount(response.PageCount);
                my.employeesVm.vm.pageSize(response.PageSize);
                my.employeesVm.vm.recordCount(response.RecordCount);
                $.each(response.Results, function (arrayId, item) {
                    my.employeesVm.vm.employees.push(item);
                });
            },
            getEmployees = function () {
                var pageSize = my.employeesVm.vm.pageSize();
                var currentPage = my.employeesVm.vm.currentPage();
                var searchText = my.employeesVm.vm.searchText();
                var sortBy = my.employeesVm.vm.sortBy();
                var jobTitle = my.employeesVm.vm.jobTitle();
                var method = "Employees/GetFilteredPaged?pageSize=" + pageSize + "&currentPage=" + currentPage
                    + "&searchText=" + searchText + "&sortBy=" + sortBy + "&jobTitle=" + jobTitle;
                my.ajaxGetJson(method, null, my.employeesVm.getEmployeesCallback);
            };
        return {
            vm: vm,
            getEmployeesCallback: getEmployeesCallback,
            getEmployees: getEmployees
        }
    }();

    $.material.init();
    $.material.ripples();
    ko.applyBindings(my.employeesVm);
    my.employeesVm.getEmployees();
});