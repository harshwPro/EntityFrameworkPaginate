$(document).ready(function () {

    var trekCardTemplate,
        trekData = {
            treks: [
                {
                    Name: "Green Lake Trek",
                    Country: "India",
                    Description: "Super easy trek",
                    ImageName: "/Assets/Header.jpg"
                },
                {
                    Name: "Green Lake Trek",
                    Country: "India",
                    Description: "Super easy trek",
                    ImageName: "/Assets/Header.jpg"
                },
                {
                    Name: "Green Lake Trek",
                    Country: "India",
                    Description: "Super easy trek",
                    ImageName: "/Assets/Header.jpg"
                }]
        };

    function appentTrekData(data) {
        $.get(
            '/Content/TrekCardTemplate.html',
            function (template) {
                trekCardTemplate = template;
            }
        );
        $(document).ajaxStop(function () {
            var renderedPage = Mustache.to_html(trekCardTemplate, data);
            $("#trekDataDiv").append(renderedPage);
        });
    }

    function addDataOnScroll() {
        
    };

    $('.mdl-layout__content').on('scroll', function () {
        if ($(this).scrollTop() + $(this).innerHeight() >= $(this)[0].scrollHeight - 1) {
            appentTrekData(trekData);
        }
    });

    // Initialise page
    var initPage = function () {
        appentTrekData(trekData);
    }();
})