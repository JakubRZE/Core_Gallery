var users = [];

$(document).ready(() => {

    AddPhotoButtonSlideToggle();

    DisplayUploadedfileName();

    RunAutocomplete();

    RunMagnificPopupGallery();

    SearchForUsers();

    SubmitPhotoUpload();

});

function AddPhotoButtonSlideToggle() {
    $("#addPhoto").click(() => {
        $("#addPhotoPop").slideToggle("slow");
    });
}

function DisplayUploadedfileName() {
    $('input[type=file]').change(function (e) {
        $in = $(this);
        $in.next().html($in.val().split("\\").pop());
    });
}

function RunAutocomplete() {
    $("#searchInput").on("click", (e) => {
        search(e);
    });
}

function RunMagnificPopupGallery() {
    $(".gallery").magnificPopup({
        delegate: 'a',
        type: 'image',
        gallery: {
            enabled: true
        }
    });
}

function SearchForUsers() {
    $(".customSearch").on("click", (e) => {
        $("#searchForm").submit();
        e.preventDefault();
    });
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
        error: () => {
            alert("Lipa");
        }
    });
};

function handleError(response) {
    console.log(response.responseText);
    alert('Something goes worng :<');
}

function SubmitPhotoUpload() {
    $("#photoSubmitBtn").on("click", () => {
        if ($(".custom-file-input").get(0).files.length === 0) {
            $(".custom-file-label").effect("shake");
        }
        else {
            $("#photoForm").submit();
            e.preventDefault();
        }
    });
}
