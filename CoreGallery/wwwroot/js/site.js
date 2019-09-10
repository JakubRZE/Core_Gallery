var users = [];

$(document).ready(() => {

    eventHandler();
    runMagnificPopupGallery();

});

function runMagnificPopupGallery() {
    $(".gallery").magnificPopup({
        delegate: 'a',
        type: 'image',
        gallery: {
            enabled: true
        }
    });
}

function eventHandler() {

    $("#addPhoto").click(() => { $("#addPhotoPop").slideToggle("slow") });
    $('input[type=file]').change(displayUploadedfileName);
    $("#searchInput").on("click", search);
    $(".customSearch").on("click", (e) => {
        $("#searchForm").submit();
        e.preventDefault();
    });
    $("#photoSubmitBtn").on("click", submitPhotoUpload);
}
function displayUploadedfileName() {
    $in = $(this);
    $in.next().html($in.val().split("\\").pop());
}
function submitPhotoUpload() {
    if ($(".custom-file-input").get(0).files.length === 0) {
        $(".custom-file-label").effect("shake");
    }
    else {
        $("#photoForm").submit();
        e.preventDefault();
    }
}

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
        error: (response) => {
            handleError(response);
        }
    });
};

function handleError(response) {
    console.log(response.responseText);
    alert('Something goes worng :<');
}