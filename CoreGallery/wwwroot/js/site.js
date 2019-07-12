var users = null;

$(document).ready(() => {

    $("#addPhoto").click(() => {
        $("#addPhotoPop").slideToggle("slow");
    });

    $('input[type=file]').change(function (e) {
        $in = $(this);
        $in.next().html($in.val().split("\\").pop());
    });



    $("#searchInput").on("click", (e) => {
        search(e);
    });


    $(function () {
        var availableTags = [
            "ActionScript",
            "AppleScript",
            "Asp",
            "BASIC",
            "C",
            "C++",
            "Clojure",
            "COBOL",
            "ColdFusion",
            "Erlang",
            "Fortran",
            "Groovy",
            "Haskell",
            "Java",
            "JavaScript",
            "Lisp",
            "Perl",
            "PHP",
            "Python",
            "Ruby",
            "Scala",
            "Scheme"
        ];
        $("#searchInput").autoomplete({
            source: availableTags
        });
    });







    /////



    ///


});



function search(event) {

    event.preventDefault();
    event.stopImmediatePropagation();

    !users && $.ajax({
        url: '/Home/GetUsers',
        method: 'GET',
        dataType: 'json',
        success: (response) => {
            users = response;
        },
        error: () => {
            alert("Lipa");
        }
    });
};


