function getModalContent(url, title) {
    $.get(url, function (data) {
        $(".modal-body").html(data);
        $(".modal-title").html(title);
    });
}

function success() {
    closeModal();
}

function closeModal() {
    $("button[data-dismiss='modal']").click();
    $(".modal-body").html("");
    $(".modal-body").html("");
}