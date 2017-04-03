$(document).ready(function () {

    var trekCardTemplate,
        isLoading = false,
        pageNumber = 0,
        trekData = {
            treks: []
        };

    function appendTrekData(data) {
        $.get(
            '/Content/TrekCardTemplate.html',
            function (template) {
                trekCardTemplate = template;
            }
        );
        $(document).ajaxStop(function () {
            var renderedPage = Mustache.to_html(trekCardTemplate, data);
            $("#trekDataDiv").append(renderedPage);
            data.treks = [];
        });
    }

    function getTrekData(country, sortBy) {
        if (!isLoading) {
            $("#loader").show();
            isLoading = true;
            pageNumber++;
            $.get("/JqueryExample/GetTreks?pageSize=2&currentPage=" +
                pageNumber + "&countryName=" + country + "&sortBy=" + sortBy,
                function (data) {
                    if (data != '') {
                        trekData.treks = data.Results;
                        appendTrekData(trekData);
                    }
                    isLoading = false;
                    $("#loader").hide();
                });
        }
    };

    $('.mdl-layout__content').on('scroll', function () {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight - 1) {
            getTrekData("", 1);
        }
    });

    // Initialise page
    var initPage = function () {
        getTrekData("", 1);
    }();
})