var users = [];

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


    /////

    $(".gallery").magnificPopup({
        delegate: 'a',
        type: 'image',
        gallery: {
            enabled: true
        }
    });

    ///


    //submit search
    $(".customSearch").on("click", (e) => {
        $("#searchForm").submit();
        e.preventDefault();
    });

});



function search(event) {

    event.preventDefault();
    event.stopImmediatePropagation();

    !users.length && $.ajax({
        url: '/Home/GetUsers',
        method: 'GET',
        dataType: 'json',
        success: (response) => {
            users = response;

            $("#searchInput").autocomplete({
                source: users
            });

        },
        error: () => {
            alert("Lipa");
        }
    });
};




function handleError(response) {
    console.log(response.responseText);
    alert('Something goes worng :<');
}
