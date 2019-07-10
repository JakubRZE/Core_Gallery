$(document).ready(() => {

    $("#addPhoto").click(() => {
        $("#addPhotoPop").slideToggle("slow");
    });

    $('input[type=file]').change(function (e) {
        $in = $(this);
        $in.next().html($in.val().split("\\").pop());
    });

});


