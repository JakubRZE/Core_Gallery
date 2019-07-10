$(document).ready(() => {

    $("#addPhoto").click(() => {
        $("#addPhotoPop").slideToggle("slow");
    });

    $('input[type=file]').change(() => {
        $in = $(this);
        $in.next().html($in.val().split("\\").pop());
    });

});


